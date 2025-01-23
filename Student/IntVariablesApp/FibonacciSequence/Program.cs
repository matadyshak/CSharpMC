namespace FibonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of terms: ");
            int terms = int.Parse(Console.ReadLine());

            int first = 0, second = 1;

            Console.WriteLine("Fibonacci Sequence:");
            for (int i = 0; i < terms; i++)
            {
                Console.WriteLine($"{first} {(double)second / (double)first}");
                int next = first + second;
                first = second;
                second = next;
            }
        }
    }
}
