using System;

namespace ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            string name = "";

            try
            {
                Console.Write("What is your name: ");
                name = Console.ReadLine().ToLower();
                if (name == "michael")
                {
                    DivideByZeroMethod();
                }
                else if (name == "mike")
                {
                    IndexOutOfRangeMethod();
                }
                else if (name == "mickey")
                {
                    NotImplementedMethod();
                }
                else if (name == "tgd")
                {
                    InsufficientMemoryException();
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("A divide by zero exception has occurred in Main()");
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index out of range exception has occurred in Main().");
                Console.WriteLine(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("You did not implement code for a method.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) when (name.ToLower() == "tgd")
            {
                Console.WriteLine("Michael, An exception has occurred in Main()");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block always runs.");
            }
            Console.WriteLine("End of Main program.");
        }

        public static void DivideByZeroMethod()
        {
            int constant = 25;
            int quotient = 0;
            int i;

            for (i=-5; i<5; i++)
            {
                try
                {
                    quotient = constant / i;
                    Console.WriteLine($"quotient: {quotient}, i: {i}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("A divide by zero exception has occurred in DivideByZeroMethod()");
                    Console.WriteLine(ex.Message);
                    throw new DivideByZeroException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception has occurred in DivideByZeroMethod().");
                    Console.WriteLine(ex.Message);
                }
            }
            return;
        }

        public static void NotImplementedMethod()
        {
            throw new NotImplementedException();
        }
        public static void IndexOutOfRangeMethod()
        {
            int[] Array = { 5, 6, 7 };

            try
            {
                for (int i = 0; i<=Array.Length; i++)
                {
                    Console.WriteLine($"Array[i] = {Array[i]}");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception occurred in IndexOutOfRangeMethod.");
                Console.WriteLine(ex.Message);
                throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred in IndexOutOfRangeMethod.");
                Console.WriteLine(ex.Message);
            }
            return;
        }

        public static void InsufficientMemoryException()
        {
            throw new InsufficientMemoryException();
        }
    }
}

