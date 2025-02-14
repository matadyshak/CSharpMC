namespace BowlingGame
{
    public static class BowlingSimulator
    {
        public static void RunBowlingGame()
        {
            int[] Game = new int[3];
            int series;
            bool gameOver = false;
            string playAgain;

            while (!gameOver)
            {
                // Bowl a 3-game series
                Game[0] = PlayBowlingGame();
                Game[1] = PlayBowlingGame();
                Game[2] = PlayBowlingGame();
                series = Game[0] + Game[1] + Game[2];
                // Update statistics
                BowlingPlayer.UpdatePlayerStats(series, Game, 3);

                gameCount += 3;
                totalPins += series;
                average = totalPins / gameCount;
                highestSeries = Math.Max(highestSeries, series);
                highestGame = Math.Max(Math.Max(highestGame, Game[0]), Math.Max(Game[1], Game[2]));
                Console.WriteLine($"\n\nSeries: {series}  Total Pins: {totalPins}  Games: {gameCount}  Average: {average}  High Series: {highestSeries}  High Game: {highestGame}");
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

