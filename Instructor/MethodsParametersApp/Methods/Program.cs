using Methods;

//for (int i = 0; i < 10; i++)
//{
//    SampleMethods.SayHi();
//}

// DRY - Don't Repeat Yourself
// SOLID - SRP - Single Responsibility Principle

Console.Write("What is your name: ");
string name = Console.ReadLine();

ConsoleMessages.SayHi(name);

MathShortcuts.Add(5,3);

double[] vals = new double[] { 2, 5, 6, 21, 52, 98 };
MathShortcuts.AddAll(vals);

ConsoleMessages.SayGoodbye();