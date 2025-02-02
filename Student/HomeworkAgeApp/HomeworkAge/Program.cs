namespace HomeworkAge
{
    internal class Program
    {
        static void Main()
        {
            string? ageText = null;
            int age = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter your age: "  );
                ageText = Console.ReadLine();
                isValid = int.TryParse(ageText, out age);

                if (isValid && age < 0)
                {
                    isValid = false;
                }

                if(!isValid)
                {
                    Console.WriteLine($"Invalid input: \'{ageText}\' Please enter a whole number for your age in years.");
                }
            }

            int futureAge = age + 25;
            int pastAge = age - 25;
            Console.WriteLine($"25 years from now you will be {futureAge} years old");
            if (pastAge >= 0)
            {
                Console.WriteLine($"25 years ago you were {pastAge} years old");
            }
            else
            {
                Console.WriteLine($"25 years ago it was {Math.Abs(pastAge)} years before you were born");
            }

            return;
        }
    }
}
