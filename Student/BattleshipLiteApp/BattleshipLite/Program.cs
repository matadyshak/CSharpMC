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
        static void Main()
        {
            WelcomeMessage();

            PlayerInfoModel activePlayer = CreatePlayer(1);
            PlayerInfoModel opponent = CreatePlayer(2);
            PlayerInfoModel winner = null;

            // activePlayer's ship locations get hidden in opponent's ShotGrid
            GameLogic.ApplyShipLocations(activePlayer, opponent);

            // opponent's ship locations get hidden in activePlayer's ShotGrid
            GameLogic.ApplyShipLocations(opponent, activePlayer);

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

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Battleship Lite Game.");
        }

        private static PlayerInfoModel CreatePlayer(int playerNumber)
        {
            PlayerInfoModel player = new PlayerInfoModel();
            GameLogic.InitializeShotGrids(player);
            GetUserName(player, playerNumber);
            DisplayShotGrid(player);
            GetShipPlacements(player);
            return player;
        }

        static void GetUserName(PlayerInfoModel player, int playerNumber)
        {
            Console.Write($"Player {playerNumber} please enter your name: ");
            player.UsersName = Console.ReadLine();
            //Todo:Add validation
            return;
        }

        static void GetShipPlacements(PlayerInfoModel player)
        {
            bool isValid;
            int returnCode;
            int returnCode1;
            int returnCode2;
            string entry;
            string row;
            int column;
            string coordinates;

            (row, column, coordinates) = GameLogic.IndexToRowColCoords(GameLogic.GridSize * GameLogic.GridSize - 1);

            Console.WriteLine("Have your opponent turn around or leave the room while you enter your secret ship locations into your opponent's grid.");
            Console.WriteLine($"Enter your secret ship locations using grid coordinates from A1 to {coordinates}.");

            for (int i = 0; i < GameLogic.GridSize; i++)
            {
                isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter ship location #{i+1}: ");
                    entry = Console.ReadLine();

                    // ReturnCode1 = 0=success, 1=nothing entered or whitespace, 2=wrong format
                    (returnCode1, row, column) = GameLogic.IsValidSpotForShip(entry);
                    // ReturnCode2 = 0=success, 4=repeated entry
                    returnCode2 = GameLogic.IsRepeatEntry(player, row, column);
                    // Bitwize OR function
                    returnCode = returnCode1 | returnCode2;

                    switch (returnCode)
                    {
                        case 0: // success
                            isValid = true;
                            GridSpotModel spot = new GridSpotModel(row, column, GridSpotStatus.Ship);
                            player.ShipLocations.Add(spot);
                            break;

                        case 1: // Nothing or whitespace only
                            Console.WriteLine($"Invalid entry: \'{entry}\'.  Please try again.");
                            break;

                        case 2:
                            // Not A1..E5 format
                            Console.WriteLine($"Invalid entry: \'{entry}\'.  Enter coordinates as \'A1\' ... \'{coordinates}\'");
                            break;

                        case 4: // Repeated entry
                            Console.WriteLine($"Invalid entry: \'{entry}\'. Repeated entry not allowed.");
                            break;
                    } // switch
                } // while (!isValid)
            } // for loop

            Console.Clear();
            return;
        }

        /*

                A1 A2 A3 A4 A5
                B1 B2 B3 B4 B5
                C1 C2 C3 C4 C5
                D1 D2 D3 D4 D5
                E1 E2 E3 E4 E5

                 O  O  O  O  O
                 X  X  X  X  X
                 O  O  O  O  O
                D1 D2 D3 D4 D5
                 O  O  O  O  O

        */
        static void DisplayShotGrid(PlayerInfoModel player)
        {
            // Start with a blank line
            // Start each line with 8 space chars
            // Grid Coords use 2 char + 1 space
            // X & O take 1 space + 1 char + 1 space
            // Ship   => A1
            // Empty  => A1
            // Miss   =>  O
            // Hit    =>  X
            // Sunk   =>  X

            string eightSpaces = "        ";
            string textRow;
            string row;
            int column;
            string coordinates;
            int index = 0;

            Console.WriteLine();
            for (int i = 0; i < GameLogic.GridSize; i++)
            {
                textRow = eightSpaces;
                for (int j = 0; j < GameLogic.GridSize; j++)
                {
                    GridSpotStatus status = player.ShotGrid[i*GameLogic.GridSize+j].Status;
                    (row, column, coordinates) = GameLogic.IndexToRowColCoords(index);
                    switch (status)
                    {
                        case GridSpotStatus.Empty:
                        case GridSpotStatus.Ship:
                            textRow += coordinates + " ";
                            break;

                        case GridSpotStatus.Hit:
                        case GridSpotStatus.Sunk:
                            textRow += " X ";
                            break;

                        case GridSpotStatus.Miss:
                            textRow += " O ";
                            break;
                    }

                    index++;
                }
                Console.WriteLine(textRow);
            }

            Console.WriteLine();
            return;
        }

        // UI but validity check can be lib
        static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            // Get grid location to fire at on opponents grid


            // Check if valid location
            // A..E, 1..5
            // Not prev missed or hit
            //IsValidSpotForShot();
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
