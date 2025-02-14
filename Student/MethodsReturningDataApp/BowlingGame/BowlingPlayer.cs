namespace BowlingGame
{
    public static class BowlingPlayer
    {
        // Static properties to store player statistics
        public static int TotalPins { get; private set; }
        public static int TotalGames { get; private set; }
        public static int Average { get; private set; }
        public static int HighestGame { get; private set; }
        public static int HighestSeries { get; private set; }

        // Static constructor to initialize properties
        static BowlingPlayer()
        {
            TotalPins = 0;
            TotalGames = 0;
            Average = 0;
            HighestGame = 0;
            HighestSeries = 0;
        }
        public static void UpdatePlayerStats(int series, int[] games, int gamesPlayed, )
        {
            TotalPins += series;
            TotalGames += gamesPlayed;
            Average = TotalPins / TotalGames;
            HighestSeries = Math.Max(HighestSeries, series);
            HighestGame = Math.Max(Math.Max(HighestGame, games[0]), Math.Max(games[1], games[2]));
        }

        public static void PrintPlayerStats(int series, int[] games)
        {
            Console.WriteLine($"\n\n{games[0]}+{games[1]}+{games[2]}={series}  Total Pins: {TotalPins}  Games: {TotalGames}  Average: {Average}  High Series: {HighestSeries}  High Game: {HighestGame}");
        }









        bool gameOver = false;
        string playAgain;
            while (!gameOver)
            {
                // Update statistics
                Console.Write("\n\nPlay Another Game? (Y/N): ");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain != "y")
                {
                    gameOver = true;
                }
}
return;
        }
    }
}
