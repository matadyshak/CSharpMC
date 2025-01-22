using System;
using System.Net;

namespace BabyNamePicker
{

    internal class Program
    {
        static void Main(string[] args)
        {
            BabyNamePicker();
            while (true)
            {
                Console.Write("Do you want to pick more names? (yes/no) ");
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    BabyNamePicker();
                }
                else
                {
                    break;
                }
            }
        }

        static void BabyNamePicker()
        { 
            int[] boyTallies = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            int[] girlTallies = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            string[] girlNames =
            {  
                "Mary Catherine",
                "Penelope Grace",
                "Janet Marie",
                "Danielle Rose",
                "Luz Maria",
                "Elizabeth Anne",
                "Christine Mary",
                "Lourdes Maria",
                "Melania Knavs",
                "Anna Sofia"
            };

            string[] boyNames = new string[]
            { 
                "Michael Anthony",
                "Philip James",
                "Thomas Philip",
                "Gregory Steven",
                "Joseph Michael",
                "Matthew James",
                "Daniel Stephen",
                "John Paul",
                "Juan Diego",
                "Giovanni Giuseppi"
            };

            string response = string.Empty;
            string names = string.Empty;

            // Prompt for boy names or girl names
            bool genderValid = false;
    
            while (!genderValid)
            {
                Console.Write("Pick girl or boy names? ");
                response = Console.ReadLine().ToLower();
                if (response == "girl" || response == "boy")
                {
                    genderValid = true;
                }
                else
                {
                    Console.WriteLine("Please try again.  Enter 'girl' or 'boy'.");
                }
            }

            Random random = new Random();

            if (response=="boy")
            {
                ResetTallies(boyTallies);
                for (int i = 0; i < 1000; i++)
                {
                    int index = random.Next(0, boyNames.Length);
                    boyTallies[index]++;
                }
                
                // Display the results
                // Find the index of the highest value in the boyTallies array
                // Set that tally to -1
                int highestValue = 0;
                int highestIndex = -1;
                
                for (int k = 0; k<boyNames.Length; k++)
                {
                    // Run the inner loop 10 times
                    highestValue = 0;
                    highestIndex = -1;

                    for (int j = 0; j<boyTallies.Length; j++)
                    {
                        if (boyTallies[j] > highestValue)
                        {
                            highestValue = boyTallies[j];
                            highestIndex = j;
                        }
                    }

                    names = boyNames[highestIndex];
                    Console.WriteLine($"Popularity: {highestValue}% Name: {names}");
                    boyTallies[highestIndex] = -1;
                }
            }
            else
            {
                ResetTallies(girlTallies);
                for (int i = 0; i < 100; i++)
                {
                    int index = random.Next(0, girlNames.Length);
                    girlTallies[index]++;
                }

                // Display the results
                // Find the index of the highest value in the boyTallies array
                // Set that tally to -1
                int highestValue = 0;
                int highestIndex = -1;

                for (int k = 0; k<girlNames.Length; k++)
                {
                    // Run the inner loop 10 times
                    highestValue = 0;
                    highestIndex = -1;

                    for (int j = 0; j<girlTallies.Length; j++)
                    {
                        if (girlTallies[j] > highestValue)
                        {
                            highestValue = girlTallies[j];
                            highestIndex = j;
                        }
                    }

                    names = girlNames[highestIndex];
                    Console.WriteLine($"Popularity: {highestValue}% Name: {names}");
                    girlTallies[highestIndex] = -1;
                }
            }
            return;
        }

        static void ResetTallies(int[] tallies)
        {
            for (int i = 0; i < tallies.Length; i++)
            {
                tallies[i] = 0;
            }
        }
    }
}
