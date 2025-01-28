namespace NullVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // null - lack of value

            // Haven't asked for the age yet
            int? age = null;
            bool? birthday = null;
            double? battingAverage = null;
            decimal? accountBalance = null;
            string? firstName = null;

            printAge(age);
            printBirthday(birthday);
            printBattingAverage(battingAverage);
            printAccountBalance(accountBalance);
            printFirstName(firstName);

            // We have asked for the age now
            age = 62;
            birthday = false;
            battingAverage = 0.300D;
            accountBalance = 100700.00M;
            firstName = "Michael";
            printAge(age);
            printBirthday(birthday);
            printBattingAverage(battingAverage);
            printAccountBalance(accountBalance);
            printFirstName(firstName);

            age = null;
            birthday = null;
            battingAverage = null;
            accountBalance = null;
            firstName = null;
            printAge(age);
            printBirthday(birthday);
            printBattingAverage(battingAverage);
            printAccountBalance(accountBalance);
            printFirstName(firstName);

            age = 99;
            birthday = true;
            battingAverage = 0.425D;
            accountBalance = 3100700.00M;
            firstName = "Anthony";
            printAge(age);
            printBirthday(birthday);
            printBattingAverage(battingAverage);
            printAccountBalance(accountBalance);
            printFirstName(firstName);
        }

        static void printAge(int? age)
        {
            if (age == null)
            {
                Console.WriteLine($"Age is null.");
            }
            else
            {
                Console.WriteLine($"Age is {age}.");
            }
        }
        static void printBirthday(bool? isBirthday)
        {
            if (isBirthday == null)
            {
                Console.WriteLine($"isBirthday is null.");
            }
            else
            {
                Console.WriteLine($"isBirthDay is {isBirthday}.");
            }
        }
        static void printBattingAverage(double? battingAverage)
        {
            if (battingAverage == null)
            {
                Console.WriteLine($"battingAverage is null.");
            }
            else
            {
                Console.WriteLine($"battingAverage is {battingAverage}.");
            }
        }
        static void printAccountBalance(decimal? accountBalance)
        {
            if (accountBalance == null)
            {
                Console.WriteLine($"accountBalance is null.");
            }
            else
            {
                Console.WriteLine($"accountBalance is {accountBalance}.");
            }
        }
        static void printFirstName(string? firstName)
        {
            if (firstName == null)
            {
                Console.WriteLine($"firstName is null.");
            }
            else
            {
                Console.WriteLine($"firstName is {firstName}.");
            }
        }
    }
}
