using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameApp
{
    class Program
    {
        public static void Main()
        {
            // Set pseudo-random number generator seed one-time
            Random random = new Random();

            BlackjackDeck blackjack = new BlackjackDeck(random);

            int status = PlayBlackjack(blackjack);
        }

        public static int PlayBlackjack(BlackjackDeck blackjack)
        {
            bool quit = false;
            int score = 0;
            string entry;
            List<PlayingCard> hand = new List<PlayingCard>();


            while (!quit)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear(); // Apply the background color change
                Console.ForegroundColor = ConsoleColor.Black; // Set text color for better visibility
                Console.WriteLine("Welcome to the BlackJack game!");
                Console.WriteLine("Hit H <enter> for 'Hit me' or S <enter> to stand");
                // status: 1-21=score, 22=Bust
                (hand, score) = blackjack.StartBlackjackHand();
                PrintBlackjackHand(hand, score);
                Console.Write("Play again? (y/n): ");
                entry = Console.ReadLine();
                if (entry.ToLower() != "y")
                {
                    quit = true;
                }
            }
            return 0;
        }

        public static void PrintBlackjackHand(List<PlayingCard> cards, int score)
        {
            string output = "";

            foreach (PlayingCard card in cards)
            {
                output += $"{card.Value} {Symbol(card.Suit)}  ";
            }

            //Console.WriteLine(output);

            //char heart = '\u2665';

            //char diamond = '\u2666';

            //char spade = '\u2660';

            //char club = '\u2663';

            //Console.WriteLine("Heart: " + heart);

            //Console.WriteLine("Diamond: " + diamond);

            //Console.WriteLine("Spade: " + spade);

            //Console.WriteLine("Club: " + club);

        }

        public static char Symbol(CardSuits suit)
        {
            char symbol = '\u2665';

            switch (suit)
            {
                case CardSuits.Hearts:
                    symbol = '\u2665';
                    break;

                case CardSuits.Diamonds:
                    symbol = '\u2666';
                    break;

                case CardSuits.Spades:
                    symbol = '\u2660';
                    break;

                case CardSuits.Clubs:
                    symbol = '\u2663';
                    break;
            }

            return symbol;

        }
    }

    public class Deck
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
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }

        public List<PlayingCard> DrawCards(int number)
        {
            if (DrawPile.Count < number)
            {
                //Error
            }

            List<PlayingCard> drawnCards = DrawPile.Take(number).ToList();
            DrawPile.RemoveRange(0, number);
            return drawnCards;
        }

    }

    public class PlayingCard
    {
        public CardSuits Suit { get; set; }
        public CardValues Value { get; set; }

        public PlayingCard(CardSuits suit, CardValues value)
        {
            Suit = suit;
            Value = value;
        }
    }

    public class BlackjackDeck : Deck
    {
        public BlackjackDeck(Random random) : base(random)
        {
            CreateDeck();
            ShuffleDeck();
        }

        public List<PlayingCard> Deal(int Number)
        {
            return base.DrawCards(2);
        }

        public int CalculateSumOfCards(List<PlayingCard> cards)
        {
            int sum = 0;
            int aceCount = 0;

            foreach (PlayingCard card in cards)
            {
                switch (card.Value)
                {
                    case CardValues.Ace:
                        sum += 1;
                        aceCount++;
                        break;

                    case CardValues.Two:
                    case CardValues.Three:
                    case CardValues.Four:
                    case CardValues.Five:
                    case CardValues.Six:
                    case CardValues.Seven:
                    case CardValues.Eight:
                    case CardValues.Nine:
                    case CardValues.Ten:
                        sum += (int)(card.Value) + 1;
                        break;

                    case CardValues.Jack:
                    case CardValues.Queen:
                    case CardValues.King:
                        sum += 10;
                        break;
                }

                while (aceCount > 0)
                {
                    if (sum + 10 <= 21)
                    {
                        sum += 10;
                    }
                    aceCount--;
                }
            }

            return sum;
        }

        public (List<PlayingCard>, int) StartBlackjackHand()
        {
            List<PlayingCard> cards = new List<PlayingCard>();
            int score = 0;

            cards = Deal(2);
            score = CalculateSumOfCards(cards);
            if (score > 21)
            {
                score = 22; //Busted
            }
            return (cards, score);
        }
    }
}

/*
Blackjack Game

Objective: The goal is to have a hand value closer to 21 than the dealer's hand without exceeding 21.

Card Values:

Number cards (2-10) are worth their face value.
Face cards (Jack, Queen, King) are worth 10 points.
Aces can be worth 1 or 11 points, depending on which value benefits the hand more.
Gameplay:

Each player is dealt two cards, and the dealer also gets two cards (one face up, one face down).
Players can choose to "hit" (take another card) or "stand" (keep their current hand).
Players can continue to hit until they either stand or their hand value exceeds 21 (bust).
Dealer's Turn:

After all players have finished their turns, the dealer reveals their face-down card.
The dealer must hit until their hand value is at least 17.
If the dealer busts, all remaining players win.
Winning:

If your hand value is closer to 21 than the dealer's without busting, you win.
If you bust, you lose regardless of the dealer's hand.
If both you and the dealer have the same hand value, it's a push (tie), and your bet is returned.
Blackjack:

A hand with an Ace and a 10-point card (10, Jack, Queen, King) is called a "Blackjack" and usually pays out at 3:2 odds.

	1. Single player
	2. Deal out 2 cards from draw pile
        3. Compute sum.
*	4. Player decides to either draw 1 card from draw pile or stop
        5. If "stop" chosen, compute sum
        6. If "hit me" chosen, draw 1 card from draw pile
        7. Compute sum
        8. If over 21 player loses
        9. If not over 21, go back to step 3

        Ace counts as 1 or 11.
        Ten-Jack-Queen-King count as 10.

        UI could ask player if they want to play Blackjack
        Explain to hit 'H' for "Hit Me", or 'S' for "Stand"
        UI Then asks to play again
*/


