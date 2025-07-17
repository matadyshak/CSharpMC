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


            Console.WriteLine("Lambda Tests");
        }
        private static void LinqTests()
        {
            var players = SampleData.GetPlayerData();
            var stats = SampleData.GetStatsData();


            Console.WriteLine("Linq Tests");
        }
    }
}
