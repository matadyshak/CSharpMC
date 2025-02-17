﻿using System.Text.RegularExpressions;

namespace MiniProjectGuestBook
{
    internal static class GuestBook
    {
        private static Dictionary<string, int> Book { get; set; }
        private static string PartyName { get; set; }
        private static int PartySize { get; set; }
        private static int TotalGuests { get; set; }
        private static int RoomCapacity { get; set; }
        private static string RegexName { get; set; }
        private static string RegexSize { get; set; }
        private static Regex RegexNameObj { get; set; }
        private static Regex RegexSizeObj { get; set; }

        //REGEX
        // * = 0 or more
        // ? = 0 or 1
        // + = 1 or more
        // (){0,} = 0 or more groups of what is in parens

        static GuestBook()
        {
            GuestBook.Book = new Dictionary<string, int>();
            GuestBook.PartyName = "Party";
            GuestBook.PartySize = 0;
            GuestBook.RegexName = @"^[a-zA-Z'-]+$";
            GuestBook.RegexNameObj = new Regex(RegexName);
            GuestBook.RegexSize = @"^[0-9]+$";
            GuestBook.RegexSizeObj = new Regex(RegexSize);
            GuestBook.RoomCapacity = 100;
            GuestBook.TotalGuests = 0;
        }

        public static void GreetUser()
        {
            Console.WriteLine("Welcome to the Guest Book!");
            Console.WriteLine("You will be prompted to enter a last name for each party as they arrive and the number of guests.");
            Console.WriteLine("Enter 'done' when finished entering names.");
            return;
        }

        public static string GetPartyName()
        {
            bool isValid = false;
            string name = "";

            do
            {
                Console.Write("Please enter a last name for the party (or enter 'done' if finished): ");
                name = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(name) || (RegexNameObj.IsMatch(name) == false))
                {
                    Console.WriteLine($"The name: \'{name}\' is invalid.");
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            GuestBook.PartyName = StringConversions.ConvertToTitleCase(name);
            return GuestBook.PartyName;
        }
        public static int GetPartySize()
        {
            bool isValid = false;
            int size = 0;
            string sizeString = "";
            while (!isValid)
            {
                Console.Write("Please enter the number of guests in the party: ");
                sizeString = Console.ReadLine().Trim();
                try
                {
                    isValid = (int.TryParse(sizeString, out size) &&
                    !string.IsNullOrWhiteSpace(sizeString) &&
                    RegexSizeObj.IsMatch(sizeString) &&
                    size > 0);
                    if (!isValid)
                    {
                        Console.WriteLine($"The party size: \'{sizeString}\' is invalid.");
                    }
                }
                catch (Exception)
                {
                    isValid = false;
                    size = 0;
                    Console.WriteLine($"The party size: \'{sizeString}\' is invalid.");
                }
            } while (!isValid) ;

            GuestBook.PartySize = size;
            return GuestBook.PartySize;
        }

        public static bool AddPartyToBook(string name, int size)
        {
            if ((GuestBook.TotalGuests + size) <= GuestBook.RoomCapacity)
            {
                if (IsPartyInBook(name))
                {
                    Console.WriteLine("The party is already in the book.");
                    GuestBook.AddGuestsToParty(name, size);
                    return true;
                }

                try
                {
                    Book.Add(name, size);
                    GuestBook.TotalGuests += size;
                    Console.WriteLine($"The \'{name}\' party of {size} guests was added to the guest list.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to add name: \'{name}\' and size: \'{size}\' to guest book.");
                    Console.WriteLine($"Exception: {ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The party cannot be added to the book because the room capacity would be exceeded.");
                return false;
            }
        }

        public static bool IsPartyInBook(string name)
        {
            if (GuestBook.Book.ContainsKey(name))
            {
                return true;
            }
            return false;
        }
        public static bool AddGuestsToParty(string name, int guests)
        {
            if (GuestBook.TotalGuests + guests <= GuestBook.RoomCapacity)
            {
                if (GuestBook.Book.ContainsKey(name))
                {
                    GuestBook.Book[name] += guests;
                    GuestBook.TotalGuests += guests;
                    Console.WriteLine($"{guests} guests were added to the \'{name}\' party.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"The party: \'{name}\' is not in the book.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The party cannot be added to the book because the room capacity would be exceeded.");
                return false;
            }
            return false;
        }

        public static void PrintGuestBook()
        {
            Console.WriteLine("Guest Book:");
            foreach (KeyValuePair<string, int> entry in GuestBook.Book)
            {
                Console.WriteLine($"Party: {entry.Key} Guests: {entry.Value}");
            }
            Console.WriteLine($"Total Guests: {GuestBook.TotalGuests}");
            return;
        }
    }
}