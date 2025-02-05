namespace SwitchDemo
{
    internal class Program
    {
        static void Main()
        {
            bool isValid = false;
            string textMaxGamePrice;
            decimal maxGamePrice = 0.0M;

            Console.Write("What kind of game console do you have? (Xbox / Xbox One / PS4 / PS5 / Switch / Switch S2): ");
            string? console = Console.ReadLine().ToLower();
            string? vendor = null;

            switch (console)
            {
                case "xbox" or "xbox one":
                    vendor = "Microsoft";
                    Console.WriteLine($"You have a console made by {vendor}");
                    break;

                case "ps4" or "ps5":
                    vendor = "SONY";
                    Console.WriteLine($"You have a console made by {vendor}");
                    break;

                case "switch" or "switch s2":
                    vendor = "Nintendo";
                    Console.WriteLine($"You have a console made by {vendor}");
                    break;

                default:
                    Console.WriteLine($"I do not recognize that kind of game console: {console}");
                    vendor = null;
                    console = null;
                    break;
            }


            if (vendor == null || console == null)
            {
                Console.WriteLine("Bye!");
                return;
            }

            isValid = false;
            while (!isValid)
            {
                Console.Write("What is the most you have paid for a gaming software title ? ");
                textMaxGamePrice = Console.ReadLine();
                isValid = decimal.TryParse(textMaxGamePrice, out maxGamePrice);
                if (!isValid)
                {
                    Console.WriteLine($"Amount entered is invalid: {textMaxGamePrice}");
                }
            }

            switch (maxGamePrice)
            {
                case < 0.0m:
                    Console.WriteLine("Ha!  They paid YOU to take the game!");
                    break;
                case 0.0m:
                    Console.WriteLine("You have not bought any games.");
                    break;

                case <= 25.00m:
                    Console.WriteLine("You got a great deal!");
                    break;

                case <= 50.00m:
                    Console.WriteLine("You got a fair deal!");
                    break;

                case <= 100.00m:
                    Console.WriteLine("This is a very expensive hobby!");
                    break;

                default: // > 100.00
                    Console.WriteLine("Wow! Call the BBB and file a report.");
                    break;
            }

            Console.WriteLine("Let me try the same thing using the \'and\' function");
            Console.ReadLine();

            switch (maxGamePrice)
            {
                case < 0.0m:
                    Console.WriteLine("Ha!  They paid YOU to take the game!");
                    break;

                case 0.0m:
                    Console.WriteLine("You have not bought any games.");
                    break;

                case > 0.0m and <= 25.00m:
                    Console.WriteLine("You got a great deal!");
                    break;

                case (> 25.0m and <= 50.00m) or (> 50.0m and <= 100.00m):
                    Console.WriteLine("This is a very expensive hobby!");
                    break;

                default: // > 100.00
                    Console.WriteLine("Wow! Call the BBB and file a report!");
                    break;
            }

            Console.WriteLine("Setting maxGamePrice to $100.00 / 3");
            maxGamePrice = 100.0m / 3.0m;

            switch (maxGamePrice)
            {
                case < 33.33m:
                    Console.Write($"maxGamePrice: {maxGamePrice} is less than $33.33");
                    break;

                case 33.33m:
                    Console.Write($"maxGamePrice: {maxGamePrice} is equal to $33.33");
                    break;

                case > 33.33m:
                    Console.Write($"maxGamePrice: {maxGamePrice} is greater than $33.33");
                    break;
            }

            return;
        }
    }
}