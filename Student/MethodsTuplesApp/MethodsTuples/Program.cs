using MethodsTuples;

int[] games = new int[] { 150, 175, 160 };
int series = games[0] + games[1] + games[2];
int gamesPlayed = 3;
BowlingPlayer.UpdatePlayerStats(series, games, gamesPlayed);

games = new int[] { 200, 225, 210 };
series = games[0] + games[1] + games[2];
gamesPlayed += 3;
BowlingPlayer.UpdatePlayerStats(series, games, gamesPlayed);

games = new int[] { 242, 180, 150 };
series = games[0] + games[1] + games[2];
gamesPlayed += 3;
BowlingPlayer.UpdatePlayerStats(series, games, gamesPlayed);

//tuple
(int hiSeries, int hiGame) = BowlingPlayer.GetPlayerHiScores();
Console.WriteLine($"\nHigh Series: {hiSeries}, High Game: {hiGame}");

games = new int[] { 250, 199, 210 };
series = games[0] + games[1] + games[2];
gamesPlayed += 3;
//tuple IN, tuple OUT
(hiSeries, hiGame) = BowlingPlayer.UpdatePlayerStats((series, games, gamesPlayed));
Console.WriteLine($"\nHigh Series: {hiSeries}, High Game: {hiGame}");


games = new int[] { 180, 220, 300 };
series = games[0] + games[1] + games[2];
gamesPlayed += 3;

// Don't care about returned hiSeries value
(_, hiGame) = BowlingPlayer.UpdatePlayerStats((series, games, gamesPlayed));
Console.WriteLine($"\nHigh Game: {hiGame}");

(hiSeries, hiGame) = BowlingPlayer.GetPlayerHiScores();
Console.WriteLine($"\nHigh Series: {hiSeries}, High Game: {hiGame}");
