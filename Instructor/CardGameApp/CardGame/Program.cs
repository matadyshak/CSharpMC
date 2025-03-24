using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackjackDeck deck = new BlackjackDeck();

            var hand = deck.DealCards();

            foreach (var card in hand)
            {
                Console.WriteLine($"{card.Value.ToString()} of {card.Suit.ToString()}");
            }

            Console.ReadLine();
        }
    }
}
