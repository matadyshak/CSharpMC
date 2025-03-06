using BattleshipLiteLibrary.Models;
using System;
using System.Text.RegularExpressions;

namespace BattleshipLiteLibrary
{
    public class GameLogic
    {
        private static readonly Regex rowColRegex = new Regex(@"^[A-E][1-5]$");
        public static readonly int numberOfGridRows = 5;
        public static readonly int numberOfGridColumns = 5;

        public static void InitializeShotGrids(PlayerInfoModel player)
        {
            // Initialize shot grids to all empty status
            string[] rows = { "A", "B", "C", "D", "E" };
            int[] columns = { 1, 2, 3, 4, 5 };

            foreach (string row in rows)
            {
                foreach (int column in columns)
                {
                    GridSpotModel spot = new GridSpotModel(row, column, GridSpotStatus.Empty);
                    player.ShotGrid.Add(spot);
                }
            }

            player.ShotCount = 0;
            player.HitCount = 0;

            return;
        }

        public static (int valid, string row, int column) IsValidSpotForShip(PlayerInfoModel player, string entry)
        {
            int valid = 1; //0=success, 1=failure
            string row = "";
            int column = 0;

            string result = entry.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(result))
            {
                if (rowColRegex.IsMatch(result))
                {
                    row = result[0].ToString();
                    column = int.Parse(result[1].ToString());
                    if (!IsRepeatEntry(player, row, column))
                    {
                        // Success
                        valid = 0; // success
                        return (valid, row, column);
                    }
                    else
                    {
                        // Repeated entry
                        valid = 3;
                        return (valid, row, column);
                    }
                }
                else
                {
                    // Invalid entry
                    valid = 2;
                    return (valid, row, column);
                }
            }
            valid = 1;  //Received white space or nothing
            return (valid, row, column);
        }

        private static bool IsRepeatEntry(PlayerInfoModel player, string row, int column)
        {
            foreach (GridSpotModel shipLocation in player.ShipLocations)
            {
                if ((shipLocation.SpotLetter == row) && (shipLocation.SpotNumber == column))
                {
                    return true;  //Error message: duplicate entry
                }
            }

            return false;
        }

        public static int ApplyShipLocations(PlayerInfoModel player1, PlayerInfoModel player2)
        {
            string row;
            int column;
            int index;

            // This will get called with player1, player2
            // Then with player2, player1

            //Apply player 1 ship locations to player 2 grid
            foreach (GridSpotModel shipLocation1 in player1.ShipLocations)
            {
                //Get details of the spot from player1
                row = shipLocation1.SpotLetter;
                column = shipLocation1.SpotNumber;
                GridSpotModel spot = new GridSpotModel(row, column, GridSpotStatus.Ship);

                // Placing player1's hidden ships into player 2's grid
                // Need to change status to Ship in same row, column of Player2
                index = player2.ShotGrid.FindIndex(item => item.SpotLetter == row && item.SpotNumber == column);
                if (index == -1)
                {
                    return 1; // Failed to find an item
                }
                player2.ShotGrid[index] = spot;
            }

            return 0;
        }



        //Lib
        static bool IsValidSpotForShot()
        {
            // Check first char is A-E
            // Check 2nd char is 1-5
            // Check that not already ship hit or miss
            return false;
        }

        public static bool PlayerStillActive(PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }
    }
}
