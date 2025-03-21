using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameApp
{
    class Program
    {
        public static void Main()
        {
            Deck deck = new Deck();
            //Create the FullDeck in sequential order
            deck.CreateDeck();
            deck.PrintDeck(DeckTypes.Full);
            //Shuffle the draw pile
            deck.ShuffleDeck();
            deck.PrintDeck(DeckTypes.Draw);
        }
    }

    public class Deck
    {
        protected Random Rand = null;
        protected List<PlayingCard> FullDeck = new List<PlayingCard>();
        protected List<PlayingCard> DrawPile = new List<PlayingCard>();
        protected List<PlayingCard> DiscardPile = new List<PlayingCard>();

        public void CreateDeck()
        {
            FullDeck.Clear();

            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 0; value < 13; value++)
                {
                    FullDeck.Add(new PlayingCard((CardSuits)suit, (CardValues)value));
                }
            }
            return;
        }

        public void ShuffleDeck()
        {
            if (Rand == null)
            {
                // Do this only once
                Rand = new Random();
            }
            DrawPile.Clear();
            DrawPile = FullDeck.OrderBy(x => Rand.Next()).ToList();
        }

        public void PrintDeck(DeckTypes deck)
        {
            List<PlayingCard> cards = null;

            switch (deck)
            {
                case DeckTypes.Full:
                    cards = FullDeck;
                    break;
                case DeckTypes.Draw:
                    cards = DrawPile;
                    break;
                case DeckTypes.Discard:
                    cards = DiscardPile;
                    break;
            }

            foreach (PlayingCard card in cards)
            {
                Console.WriteLine($"{card.Suits} of {card.Values}");
            }
        }
    }

    public class PlayingCard
    {
        public CardSuits Suits { get; set; }
        public CardValues Values { get; set; }

        public PlayingCard(CardSuits suits, CardValues values)
        {
            Suits = suits;
            Values = values;
        }
    }
}