namespace HomeworkIfSwitch
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine().ToLower();

            if (name == "tim" || name == "timothy")
            {
                Console.WriteLine("Welcome, Professor");
            }
            else
            {
                Console.WriteLine("Welcome, Student");
            }
        }
    }
}
