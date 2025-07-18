using LinqUI.Models;

namespace LinqUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LambdaTests();
            LinqTests();
            Console.WriteLine("Press return key to continue");
            Console.ReadLine();
        }

        private static void LambdaTests()
        {
            var players = SampleData.GetPlayerData();
            var stats = SampleData.GetStatsData();


            Console.WriteLine("Test#1: Show list of top rebounders");
            var reboundList = players
                .Join(stats, p => p.PlayerId, s => s.PlayerId, (p, s) => new { Player = p, Stats = s })
                .Where(ps => ps.Stats.Rebounds > 0)
                .Select(ps => new { ps.Player.Name, ps.Stats.Rebounds })
                .OrderByDescending(po => po.Rebounds);

            foreach (var player in reboundList)
            {
                Console.WriteLine($"{player.Name} - {player.Rebounds}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            Console.WriteLine("Test#2 Show list of top scorers");
            var scoringList = players
                .Join(stats, p => p.PlayerId, s => s.PlayerId, (p, s) => new { Player = p, Stats = s })
                .Where(ps => ps.Stats.Points > 0)
                .Select(ps => new { ps.Player.Name, ps.Stats.Points })
                .OrderByDescending(po => po.Points);

            foreach (var player in scoringList)
            {
                Console.WriteLine($"{player.Name} - {player.Points}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



            Console.WriteLine("Test#3 Show list of top 3PT shooters");
            var made3PtList = players
                .Join(stats, p => p.PlayerId, s => s.PlayerId, (p, s) => new { Player = p, Stats = s })
                .Where(ps => ps.Stats.Made3Pt > 0)
                .Select(ps => new { ps.Player.Name, ps.Stats.Made3Pt })
                .OrderByDescending(po => po.Made3Pt);

            foreach (var player in made3PtList)
            {
                Console.WriteLine($"{player.Name} - {player.Made3Pt}");
            }
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();



        }
        private static void LinqTests()
        {
            var players = SampleData.GetPlayerData();
            var stats = SampleData.GetStatsData();


            Console.WriteLine("Linq Tests completed");
        }
    }
}
