using DemoGuestLibrary.Models;
using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    class Program
    {
        public static List<GuestModel> guests = new List<GuestModel>();

        static void Main()
        {
            // Get guest info
            GetGuestsInfo();

            // Print guest info
            PrintGuestsInfo();
        }

        static void GetGuestsInfo()
        {
            string Continue;

            do
            {
                GuestModel guest = new GuestModel();

                // Prompt user for name
                Console.WriteLine();
                guest.FirstName = GetUserInput("Enter first name: ");
                guest.LastName = GetUserInput("Enter last name: ");
                guest.City = GetUserInput("Enter your home city: ");
                guest.State = GetUserInput("Enter your home state: ");
                guest.MessageForStaff = GetUserInput("Enter a message for our staff: ");
                guests.Add(guest);

                Continue = GetUserInput("Are any more guests coming? (yes/no) ");
            } while (Continue.ToLower() == "yes");

            return;
        }

        static string GetUserInput(string prompt)
        {
            Console.Write($"{prompt}");
            string output = Console.ReadLine();

            return output;
        }
        static void PrintGuestsInfo()
        {
            Console.WriteLine();
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine(guest.GuestInfo);
            }

            return;
        }
    }
}
