using System.Collections.Generic;

namespace BattleshipLibrary.Models
{
    class PlayerInfoModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShipLocations { get; set; }
        public List<GridSpotModel> ShotGrid { get; set; }
        public int TotalShots { get; set; }
        public int TotalHits { get; set; }

        // Lib
        static void InitializeGame()
        {
            // Initialize shot grids to all empty status
            // Initialize all cells to the <row><col> format
            // Initialize shot count to 0
            // Initialize hit count to 0
        }

        // Lib
        static bool IsValidSpotForShip()
        {
            // Check first char is A-E
            // Check 2nd char is 1-5
            // Check that not already ship status

        }

        //Lib
        static bool IsValidSpotForShot()
        {
            // Check first char is A-E
            // Check 2nd char is 1-5
            // Check that not already ship hit or miss

        }
    }
}
