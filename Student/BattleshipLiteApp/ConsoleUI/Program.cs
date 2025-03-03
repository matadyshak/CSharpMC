namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // UI
            WelcomeMessage();

            for (int i = 0; i < 2; i++)
            {
                // Lib
                InitializeGame();

                // UI
                GetUserName();


                // UI
                GetShipPlacements();
            }

            do
            {
                // UI
                DisplayGrids();

                // UI
                GameOver = TakeATurn();
            } while (!GameOver);

            //UI
            ShowWinnerAndStats();
        }

        //UI
        static void WelcomeMessage()
        {
            //Print welcome message to user
        }

        // UI
        static void GetUserName()
        {
            //Prompt for user name
        }

        // UI
        static void GetShipPlacements()
        {
            // Is a valid spot?
            IsValidSpotForShip();
            // If not, prompt again
            // If yes, Update ship info list
            // Set status of cells with ship placed status
        }

        // UI
        static void DisplayGrids()
        {
            //Go to a specific screen location
            // Print either the <row><col> or X or O
        }

        // UI but validity check can be lib
        static void TakeATurn()
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
