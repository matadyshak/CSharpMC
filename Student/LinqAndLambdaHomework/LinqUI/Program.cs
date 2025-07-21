using LinqUI.Models;

namespace LinqUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinqTests();
            LambdaTests();
        }

        private static void LinqTests()
        {
            var players = SampleData.GetPlayerData();
            var stats = SampleData.GetStatsData();
            int rank = 1;

            // This is known as query syntax and is similar to SQL queries and also known as Linq syntax
            // from p in players: Begin iterating over the players collection.
            // join s in stats on p.PlayerId equals s.PlayerId: Perform an inner join, matching each player with their stats using PlayerId.
            // where s.Points > 0: Only include entries where the player scored at least 1 point.
            // orderby s.Points descending: Sort results by point totals from highest to lowest.
            // select new { p.Name, s.Points }: Project just the player’s name and their points into a new anonymous object.
            // foreach ...: Loop through the sorted results and display them.

            Console.WriteLine("Show list of top scorers (10000 or more points)");
            var scoringList = from p in players
                              join s in stats on p.PlayerId equals s.PlayerId
                              where s.Points > 10000
                              orderby s.Points descending
                              select new { p.Name, s.Points, p.Team };

            foreach (var player in scoringList)
            {
                Console.WriteLine($"{rank++}. {player.Name} - {player.Points} {player.Team}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            // This is known as query syntax and is similar to SQL queries and also known as Linq syntax
            Console.WriteLine("Show list of top average points per game (10000 or more points)");
            var avgPPGList = from s in stats
                             join p in players on s.PlayerId equals p.PlayerId
                             where s.Points > 10000
                             orderby (double)s.Points / s.GamesPlayed descending
                             select new { p.Name, PPG = (double)s.Points / s.GamesPlayed, p.Team };

            rank = 1;
            foreach (var player in avgPPGList)
            {
                Console.WriteLine($"{rank++}. {player.Name} {player.PPG.ToString("F2")} PPG {player.Team}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();
        }
        private static void LambdaTests()
        {
            var players = SampleData.GetPlayerData();
            var stats = SampleData.GetStatsData();
            int rank = 1;

            //This is known as method syntax and also Linq syntax
            Console.WriteLine("Show list of top 20 rebounders");
            //Results in anonymous objects
            var reboundList = players.Join(stats, p => p.PlayerId, s => s.PlayerId, (p, s) => new { Player = p, Stats = s });
            // Filters out data where rebounds == 0
            var List2 = reboundList.Where(ps => ps.Stats.Rebounds > 0);
            // Stores simple objects having only Name and Rebounds
            var List3 = List2.Select(ps => new { ps.Player.Name, ps.Stats.Rebounds, ps.Player.Team });
            // Orders the list in descending order of Rebounds
            var List4 = List3.OrderByDescending(po => po.Rebounds);
            var List5 = List4.Take(20);
            foreach (var player in List5)
            {
                Console.WriteLine($"{rank++}. {player.Name} - {player.Rebounds} {player.Team}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            Console.WriteLine("Show list of top average rebounds per game");
            var avgRPGList = stats
                .Join(players,
                      stat => stat.PlayerId,
                      player => player.PlayerId,
                      (stat, player) => new
                      {
                          player.Name,
                          player.Team,
                          RPG = (double)stat.Rebounds / stat.GamesPlayed
                      })
                .OrderByDescending(p => p.RPG);

            rank = 1;
            foreach (var player in avgRPGList)
            {
                Console.WriteLine($"{rank++}. {player.Name} {player.RPG.ToString("F2")} RPG {player.Team}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            Console.WriteLine("Show list of top 3PT shooters (made 500 or more)");
            var made3PtList = stats
                .Join(players, s => s.PlayerId, p => p.PlayerId, (s, p) => new { Stats = s, Player = p })
                .Where(ps => ps.Stats.Made3Pt > 500)
                .Select(ps => new { ps.Player.Name, ps.Stats.Made3Pt, ps.Player.Team })
                .OrderByDescending(po => po.Made3Pt);
            rank = 1;
            foreach (var player in made3PtList)
            {
                Console.WriteLine($"{rank++}. {player.Name} - {player.Made3Pt} {player.Team}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            Console.WriteLine("Show list of top average 3PT FG made per game (500 made minimum)");
            var avg3PtList = stats
                .Join(players,
                      s => s.PlayerId,
                      p => p.PlayerId,
                      (s, p) => new { Stats = s, Player = p })
                .Where(ps => ps.Stats.Made3Pt > 500)
                .Select(ps => new { ps.Player.Name, Made3PPG = (double)ps.Stats.Made3Pt / ps.Stats.GamesPlayed, ps.Player.Team })
                .OrderByDescending(ps => ps.Made3PPG);

            rank = 1;
            foreach (var player in avg3PtList)
            {
                Console.WriteLine($"{rank++}. {player.Name} {player.Made3PPG.ToString("F2")} 3P PG {player.Team}");

            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();
        }
    }
}
