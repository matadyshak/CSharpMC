namespace MethodsTuples
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
        public static void UpdatePlayerStats(int series, int[] games, int gamesPlayed)
        {
            TotalPins += series;
            TotalGames += gamesPlayed;
            Average = TotalPins / TotalGames;
            HighestSeries = Math.Max(HighestSeries, series);
            HighestGame = Math.Max(Math.Max(HighestGame, games[0]), Math.Max(games[1], games[2]));
        }

        public static (int hiSeries, int hiGame) UpdatePlayerStats((int series, int[] games, int gamesPlayed) data)
        {
            TotalPins += data.series;
            TotalGames += data.gamesPlayed;
            Average = TotalPins / TotalGames;
            HighestSeries = Math.Max(HighestSeries, data.series);
            HighestGame = Math.Max(Math.Max(HighestGame, data.games[0]), Math.Max(data.games[1], data.games[2]));
            return (HighestSeries, HighestGame);
        }

        public static void PrintPlayerStats(int series, int[] games)
        {
            Console.WriteLine($"\n\n{games[0]}+{games[1]}+{games[2]}={series}  Total Pins: {TotalPins}  Games: {TotalGames}  Average: {Average}  High Series: {HighestSeries}  High Game: {HighestGame}");
        }

        public static (int hiSeries, int hiGame) GetPlayerHiScores()
        {
            return (HighestSeries, HighestGame);
        }
    }
}
