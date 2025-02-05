namespace HomeworkSwitch
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine().ToLower();

            switch(name)
            {
                case "tim":
                case "timothy":
                    Console.WriteLine("Welcome, Professor");
                    break;
                default:
                    Console.WriteLine("Welcome, Student");
                    break;
            }
            return;
        }
    }
}
