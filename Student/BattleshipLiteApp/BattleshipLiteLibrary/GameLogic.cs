using BattleshipLiteLibrary.Models;
using System.Text.RegularExpressions;

namespace BattleshipLiteLibrary
{
    public class GameLogic
    {
        private static readonly Regex rowColRegex = new Regex(@"^[A-E][1-5]$");

        // Lib
        static void InitializeGame()
        {
            // Initialize shot grids to all empty status
            // Initialize all cells to the <row><col> format
            // Initialize shot count to 0
            // Initialize hit count to 0
        }

        static (int valid, string row, int column) IsValidSpotForShip(PlayerInfoModel player, string entry)
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
                        valid = 2;
                        return (valid, row, column);
                    }
                }
                else
                {
                    // Invalid entry
                    valid = 1;
                    return (valid, row, column);
                }
            }
            valid = 3;  //Received white space or nothing
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




        //Lib
        static bool IsValidSpotForShot()
        {
            // Check first char is A-E
            // Check 2nd char is 1-5
            // Check that not already ship hit or miss
            return false;
        }
    }
}
