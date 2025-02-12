using System.Text.RegularExpressions;

namespace MethodsReturningData
{
    public static class ConsoleValidation
    {
        public static string GetUserName()
        {
            //REGEX
            // * = 0 or more
            // ? = 0 or 1
            // + = 1 or more
            // (){0,} = 0 or more groups of what is in parens

            Regex regexFirstName = new Regex(@"^[A-Za-z- ]+$");
            bool isValid = false;
            string? input = null;
            string? output = null;

            while (!isValid)
            {
                Console.Write("What is your name? ");
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input) || (regexFirstName.IsMatch(input) == false))
                {
                    Console.WriteLine($"Name entered: \'{input}\' is invalid.");
                    isValid = false;
                }
                else
                {
                    isValid = true;
                    output = StringConversions.ConvertToTitleCase(input);
                }
            }
            return output;
        }
    }
}
