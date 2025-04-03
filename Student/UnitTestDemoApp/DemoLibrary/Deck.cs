﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace DemoLibrary
{
    public abstract class Deck
    {
        protected Random Rand = null;
        protected List<PlayingCard> FullDeck = new List<PlayingCard>();
        protected List<PlayingCard> DrawPile = new List<PlayingCard>();
        protected List<PlayingCard> DiscardPile = new List<PlayingCard>();

        // Constructor with one-time Random object
        public Deck(Random random)
        {
            Rand = random;
        }

        protected void CreateDeck()
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

        protected void ShuffleDeck()
        {
            DrawPile.Clear();

            // Even though DrawPile gets OrderBy random numbers it can still be zero-based indexed 
            DrawPile = FullDeck.OrderBy(x => Rand.Next(12345)).ToList();
            return;
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
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }

        internal virtual PlayingCard DrawOneCard()
        {
            if (DrawPile.Count == 0)
            {
                // Out of cards
                return (null);
            }

            //PlayingCard output = DrawPile.Take(1).First();
            PlayingCard output = DrawPile.First();
            DrawPile.Remove(output);
            return output;
        }

        public abstract List<PlayingCard> DealCards();

        public int GetDrawPileCount()
        {
            return DrawPile.Count;
        }
    }
}
