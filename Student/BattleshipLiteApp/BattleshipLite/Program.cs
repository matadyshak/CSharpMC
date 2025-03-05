using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System;


//Battleship by Mattel
// Each player has his own grid at bottom showing his ship placements and hits and misses made by opponent
//    Bottom grid is hidden from opponent so ship placements remain a secret
// Each player has his opponents grid at top showing his own hits and misses
//    This is needed to know where empty grid spots are that can be shot at
//    As hits are made the opponents ships become known

//BattleshipLite
// Ship placements are entered at keyboard
//   Opponent needs to leave the room during entry
// Now ship placements are hidden from both players until hits occur
// Player 1 just needs to see a grid which records his hits and misses
// Player 2 needs to store his ship locations in Player 1's grid
//    These change the status of spots from Empty to Ship
// Player 1 has no need to see opponent's grid but it will be shown during opponent's turns
// Could show both grids side-by-side or just one at a time

namespace BattleshipLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();


            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                DisplayShotGrid(activePlayer);

                RecordPlayerShot(activePlayer, opponent);

                bool DoesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (DoesGameContinue == true)
                {
                    (activePlayer, opponent) = (opponent, activePlayer);
                }
                else
                {
                    winner = activePlayer;
                }

            } while (winner == null);

            ShowWinnerAndStats();
        }

        private static PlayerInfoModel CreatePlayer(string v)
        {
            PlayerInfoModel player = new PlayerInfoModel();
            GetUserName(player);
            GetShipPlacements(player);
            output = GameLogic.InitializeGame(player);
            //            GetShipPlacements();
            return player;
        }

        //UI
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Battleship Lite Game.");
        }

        // UI
        static void GetUserName(PlayerInfoModel player)
        {
            Console.Write("Player 1 please enter your name: ");
            player.UsersName = Console.ReadLine();
            return;
        }

        static void GetShipPlacements(PlayerInfoModel player)
        {
            bool isValid = false;
            int returnCode = 0;
            string entry = "";
            string row = "";
            int column = 0;

            Console.WriteLine("Enter your ship locations using \'Letter\' \'Number\' grid coordinates as A1-A5, B1-B5,..., E1-E5");
            for (int i = 0; i<5; i++)
            {
                while (!isValid)
                {
                    Console.WriteLine("Enter ship location #{i+1}: ");
                    entry = Console.ReadLine();
                    (returnCode, row, column) = GameLogic.IsValidSpotForShip(player, entry);
                }
            }

            // Is a valid spot?
            // If not, prompt again
            // If yes, Update ship info list
            // Set status of cells with ship placed status
        }

        // UI
        static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            //Go to a specific screen location
            // Print either the <row><col> or X or O
        }

        // UI but validity check can be lib
        static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            // Get grid location to fire at on opponents grid


            // Check if valid location
            // A..E, 1..5
            // Not prev missed or hit
            IsValidSpotForShot();
            // If miss update cell to miss
            // If hit update cell to hit
            //Redraw grids
            // if 5 hits return GameOver

        }

        // UI
        static void ShowWinnerAndStats()
        {
            // Print {UserName1} or {UserName2} is the winner.
            // Print number of shots to winn
        }
    }
}
