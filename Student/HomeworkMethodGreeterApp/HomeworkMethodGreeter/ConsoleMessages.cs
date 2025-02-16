using System.Text.RegularExpressions;

namespace HomeworkMethodGreeter
{
    internal class ConsoleMessages
    {
        public static string Name { get; private set; }
        public static string RegexString { get; private set; }
        public static Regex RegexObj { get; private set; }

        static ConsoleMessages()
        {
            RegexString = @"^[a-zA-Z ]+$";
            RegexObj = new Regex(RegexString);
            Name = string.Empty;
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Allen Bowl!");
            return;
        }

        public static string GetUserName()
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("What is your name? ");
                Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Name) || (RegexObj.IsMatch(Name) == false))
                {
                    Console.WriteLine($"The name: \'{Name}\' is invalid.");
                }
                else
                {
                    isValid = true;
                    Name = StringConversions.ConvertToTitleCase(Name);
                }
            }
            return Name;
        }

        public static void PersonalWelcomeMessage(string name)
        {
            Console.WriteLine($"Hello, {name}!");
            return;
        }
    }
}
