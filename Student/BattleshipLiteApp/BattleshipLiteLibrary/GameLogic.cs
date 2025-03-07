﻿using BattleshipLiteLibrary.Models;
using System;
using System.Text.RegularExpressions;

namespace BattleshipLiteLibrary
{
    public class GameLogic
    {
        public static readonly int GridSize = 6;
        private static readonly Regex rowColRegex = BuildRegexString();

        public static Regex BuildRegexString()
        {
            //private static readonly Regex rowColRegex = new Regex(@"^[A-E][1-5]$");

            (string row, int column, string coordinates) = IndexToRowColCoords(GridSize * GridSize - 1);
            string regexString = $@"^[A-{row}][1-{column}]$";
            Regex rowColRegex = new Regex(regexString);
            return rowColRegex;
        }

        public static void InitializeShotGrids(PlayerInfoModel player)
        {
            string[] rows = new string[GridSize];
            int[] columns = new int[GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                rows[i] = ((char)('A' + i)).ToString();
                columns[i] = i + 1;
            }

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

        public static (int valid, string row, int column) IsValidSpotForShip(string entry)
        {
            int valid; //0=success, 1=failure
            string row = "";
            int column = 0;

            string result = entry.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(result))
            {
                if (rowColRegex.IsMatch(result))
                {
                    valid = 0; // Success
                    row = result[0].ToString();
                    column = int.Parse(result[1].ToString());
                    return (valid, row, column);
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

        public static int IsRepeatEntry(PlayerInfoModel player, string row, int column)
        {
            foreach (GridSpotModel shipLocation in player.ShipLocations)
            {
                if ((shipLocation.SpotLetter == row) && (shipLocation.SpotNumber == column))
                {
                    return 4;  //Error message: duplicate entry
                }
            }

            return 0;
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

        public static int RowColumnToIndex(string row, int column)
        {
            //Rows are "A", "B", "C",...,"GridSize"
            //columns are 1, 2, 3,...,"GridSize"
            // Converting that to a zero-based index

            //In actual Lists the indices are 0, 1, 2,...,GridSize-1

            int rowIndex = (int)((char)(row[0]) - 'A');
            int columnIndex = column - 1;
            return rowIndex * GameLogic.GridSize + columnIndex;
        }

        public static (string row, int column, string coordinates) IndexToRowColCoords(int index)
        {
            //Index = 0, 1, 2,...,GridSize * GridSize - 1
            //Rows are "A", "B", "C",...,"GridSize"
            //columns are 1, 2, 3,...,"GridSize"

            //In actual Lists the indices are 0, 1, 2,...,GridSize-1

            int rowIndex = index / GameLogic.GridSize;
            int columnIndex = index % GameLogic.GridSize;

            string row = ((char)('A' + rowIndex)).ToString();
            int column = columnIndex + 1;
            string coordinates = ((char)(row[0])).ToString()  + column.ToString();

            return (row, column, coordinates);
        }
    }
}
