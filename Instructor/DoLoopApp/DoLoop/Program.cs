
bool isValidAge;
int age;
//int testNumber = 0;

//do
//{
//    Console.WriteLine(testNumber);
//    testNumber += 3;
//} while (testNumber < 10);

do
{
    Console.Write("What is your age: ");
    string ageText = Console.ReadLine();

    isValidAge = int.TryParse(ageText, out age);

    if (isValidAge == false)
    {
        Console.WriteLine("That was an invalid age.");
    }
} while (isValidAge == false);

Console.WriteLine($"Your age is {age}");

//do
//{
//    // Run the code at least once
//} while (true);

//while (true)
//{
//    // Runs the code 0 or more times
//}
