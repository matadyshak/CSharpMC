namespace HomeworkVariables
{
    internal class Program
    {
        static void Main()
        {
            /*
             * Create a console application that has variables to hold a person's name, age,
             * if they are alive, and their phone number.  You do not need to capture these
             * values from the user.
             * 
            */
            bool isAlive = true;
            string? name = null;
            int? age = null;
            long? phoneNumber = null;

            isAlive = false;
            name = "John Doe";
            PrintInfo(isAlive, name, null, null);

            isAlive = true;
            name = "Jane Doe";
            age = 67;
            phoneNumber = parsePhoneNumber("(555)666-7777");
            PrintInfo(isAlive, name, age, phoneNumber);
        }

        static long parsePhoneNumber(string phoneString)
        {
            long phoneNumber = 0;
            for (int i = 0; i < phoneString.Length; i++)
            {
                if (char.IsDigit(phoneString[i]))
                {
                    phoneNumber = phoneNumber * 10 + (phoneString[i] - '0');
                }
            }
            return phoneNumber;
        }

        static void PrintInfo(bool isAlive, string name, int? age, long? phoneNumber)
        {
            if (!isAlive)
            {
                Console.WriteLine($"{name} is deceased.");
            }
            else
            {
                Console.WriteLine($"{name} is {age} years old and can be reached at {phoneNumber}.");
            }
            return;
        }
    }
}