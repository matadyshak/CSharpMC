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
            return;
        }

        static void BabyNamePicker()
        {
            int[] boyTallies = new int[10];
            int[] girlTallies = new int[10];

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
                Console.Write("Pick boy or girl names (boy/girl)? ");
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

            if (response=="boy")
            {
		        VoteForNames(boyNames, boyTallies);
                CalculateResults(boyNames, boyTallies);                
            }
            else
            {
		        VoteForNames(girlNames, girlTallies);
                CalculateResults(girlNames, girlTallies);                
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

        static void VoteForNames(string[] names, int[] tallies )
        {
            Random random = new Random();

            ResetTallies(tallies);

            for (int i = 0; i < 100; i++)
            {
	        	// Generate pseudo randum numbers from 0..9
                int index = random.Next(0, names.Length);
                tallies[index]++;
            }

            return;
         }

        static void CalculateResults(string[] names, int[] tallies)
        {
            // Find the index of the highest value in the tallies array
            // Set that tally to -
           
            int highestValue = 0;
            int highestIndex = -1;
            string theName = string.Empty;
                
    	    // Find the highest tally remaining in the tallies array
            for (int i = 0; i<names.Length; i++)
            {
                // Run the inner loop 10 times to check each tally
                highestValue = 0;
                highestIndex = -1;

                for (int j = 0; j<tallies.Length; j++)
                {
                    if (tallies[j] > highestValue)
                    {
                        // Save the value and index
                        highestValue = tallies[j];
                        highestIndex = j;
                    }
                }

                // Display the results
                theName = names[highestIndex];
                Console.WriteLine($"Popularity: {highestValue}% Name: {theName}");
                // Change this tally value to -1 so it will be skipped over
                tallies[highestIndex] = -1;
            }

             return;
        }
    }
}
