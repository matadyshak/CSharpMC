using System;
using System.Collections.Generic;

namespace CardGameApp
{
    class Program
    {
        public static void Main()
        {
            bool gameOver = false;
            int status;
            int winLossStatus;
            int wins1 = 0;
            int losses1 = 0;
            int ties1 = 0;
            int wins2 = 0;
            int losses2 = 0;
            int ties2 = 0;

            SetupConsole();

            WelcomeMessage();

            // Use a fixed seed for debugging - sequence will be exactly the same
            // Random random = new Random(12345);

            // Normal operation based on clock tick
            Random random = new Random();

            BlackjackDeck blackjack = new BlackjackDeck(random);

            while (!gameOver)
            {
                status = PlayBlackjack(blackjack);

                winLossStatus = ReportStatus(status);
                if (winLossStatus == 10)
                {
                    wins1++;
                    losses2++;
                }
                else if (winLossStatus == 20)
                {
                    wins2++;
                    losses1++;
                }
                else
                {
                    ties1++;
                    ties2++;
                }
                Console.WriteLine($"Player 1 -> {wins1} wins, {losses1} losses, {ties1} ties");
                Console.WriteLine($"Player 2 -> {wins2} wins, {losses2} losses, {ties2} ties");
                gameOver = PromptEndOfGame();
            }
        }

        public static void SetupConsole()
        {
            //ProgramFontControl.FontControl("Lucida Console");
            //ProgramFontControl.FontControl("Consolas");
            //ProgramFontControl.FontControl("Segoe UI Symbol");
            ProgramFontControl.FontControl("Courier New");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            // Apply the background color change
            Console.Clear();
            // Set text color for better visibility
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("+==================================+");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|  Welcome to the BlackJack game!  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("+==================================+");
            Console.WriteLine();
        }

        public static int PlayBlackjack(BlackjackDeck blackjack)
        {
            bool standPlayer1 = true;
            bool standPlayer2 = true;
            int scorePlayer1;
            int scorePlayer2;
            int status1;
            int status2;
            List<PlayingCard> handPlayer1;
            List<PlayingCard> handPlayer2;

            (handPlayer1, scorePlayer1, status1) = HandleNewHand(blackjack, 1);

            if (handPlayer1 == null)
            {
                //Out of cards
                return (0);
            }

            // IF BUST OR 21 - Player 1
            if ((status1 == -1) || (status1 == 1))
            {
                return status1;
            }

            // What about scorePlayer1?

            (handPlayer2, scorePlayer2, status2) = HandleNewHand(blackjack, 2);

            if (handPlayer2 == null)
            {
                //Out of cards
                return (0);
            }

            // IF BUST OR 21 - Player 2
            if ((status2 == -2) || (status2 == 2))
            {
                return status2;
            }

            // If neither bust nor 21 continue and ask to Hit or Stand

            do
            {
                (scorePlayer1, status1, standPlayer1) = HandleHitMe(blackjack, handPlayer1, scorePlayer1, 1);
                if ((status1 == -1) || (status1 == 1))
                {
                    break;
                }

                (scorePlayer2, status2, standPlayer2) = HandleHitMe(blackjack, handPlayer2, scorePlayer2, 2);
                if ((status2 == -2) || (status2 == 2))
                {
                    break;
                }

            } while (!standPlayer1 || !standPlayer2);

            return DecodeScoresAndStatus(scorePlayer1, scorePlayer2, status1, status2);
        }

        public static (List<PlayingCard> hand, int score, int status) HandleNewHand(BlackjackDeck blackjack, int player)
        {
            int score;
            int status = 0;
            List<PlayingCard> hand = new List<PlayingCard>();

            (hand, score) = blackjack.StartBlackjackHand();

            if (hand == null)
            {
                //Out of cards
                return (hand, score, 0);
            }

            // Appends msg about 21 or bust
            status = PrintBlackjackHand(hand, score, player);

            return (hand, score, status);
        }

        public static (int score, int status, bool stand) HandleHitMe(BlackjackDeck blackjack, List<PlayingCard> hand, int score, int player)
        {
            bool stand = true;
            int status = 0;

            if (PromptForHitMe(player, score))
            {
                hand.Add(blackjack.DrawOneCard());
                score = blackjack.CalculateSumOfCards(hand);
                status = PrintBlackjackHand(hand, score, player);
                if ((status == -1) || (status == 1) || (status == -2) || (status == 2))
                {
                    // 21 or bust so stand is true
                    return (score, status, stand);
                }
                stand = false; //We just did a hit, and have neither 21 or bust
            }

            return (score, 0, stand);
        }

        public static int DecodeScoresAndStatus(int score1, int score2, int status1, int status2)
        {
            //Console.WriteLine($"\nScore 1: {score1}, Score 2: {score2}");
            //Console.WriteLine($"Status 1: {status1}, Status 2: {status2}\n");

            // Both players standing - compare scores
            if ((status1 == 1) || (status2 == -2)) // Player 1 21 or Player 2 bust
            {
                return 10; // Win for Player 1
            }
            else if ((status2 == 2) || (status1 == -1)) // Player 2 21 or Player 1 bust
            {
                return 20; // Win for Player 2
            }

            if (score1 > score2)
            {
                return 10; // Win for Player 1
            }
            else if (score2 > score1)
            {
                return 20; // Win for Player 2
            }

            return 15; //Tie
        }

        public static bool PromptEndOfGame()
        {
            string entry;
            string entryLow;

            while (true)
            {
                Console.Write("\nPlay again? (y/n): ");
                entry = Console.ReadLine();
                entryLow = entry.ToLower();
                if ((entryLow == "y") || (entryLow == "n"))
                {
                    return (entryLow == "n");
                }
                else
                {
                    Console.WriteLine($"The entry: \'{entry}\' was invalid.  Try again.");
                }
            }
        }

        public static bool PromptForHitMe(int player, int score)
        {
            string entry;
            string entryLow;

            while (true)
            {
                Console.Write($"\nPlayer {player} Score: {score} -> Type \'H <enter>\' for \'Hit Me\' or \'S <enter>\' for \'Stand\': ");
                entry = Console.ReadLine();
                entryLow = entry.ToLower();
                if ((entryLow == "h") || (entryLow == "s"))
                {
                    return (entryLow == "h");
                }
                else
                {
                    Console.WriteLine($"The entry: \'{entry}\' was invalid.  Try again.");
                }
            }
        }

        public static int PrintBlackjackHand(List<PlayingCard> cards, int score, int player)
        {
            char symbol;
            string number;
            string output = $"Player {player} -> ";
            int rtn = 0; // -1=Bust, +1=21, 0=0-20

            if (cards == null)
            {
                return 0;
            }

            foreach (PlayingCard card in cards)
            {
                switch (card.Suit)
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
                    default:
                        symbol = '\0';
                        break;
                }


                switch (card.Value)
                {
                    case CardValues.Ace:
                        number = "A";
                        break;
                    case CardValues.Two:
                    case CardValues.Three:
                    case CardValues.Four:
                    case CardValues.Five:
                    case CardValues.Six:
                    case CardValues.Seven:
                    case CardValues.Eight:
                    case CardValues.Nine:
                        number = ((int)(card.Value) + 1).ToString();
                        break;
                    case CardValues.Ten:
                        number = "10";
                        break;
                    case CardValues.Jack:
                        number = "J";
                        break;
                    case CardValues.Queen:
                        number = "Q";
                        break;
                    case CardValues.King:
                        number = "K";
                        break;
                    default:
                        number = "";
                        break;
                }

                output += $"{number} {symbol}  ";
            }

            output += $"Score: {score}";
            if (score == 21)
            {
                rtn = player;
                output += $"  BLACK JACK! YOU WIN!";
            }
            else if (score > 21)
            {
                rtn = -1 * player;
                output += $"  YOU ARE BUSTED! YOU LOSE!";
            }
            Console.WriteLine(output);
            //Player 1 returns -1, 0, or 1
            //Player 2 returns -2, 0, or 2
            return rtn;
        }
        public static int ReportStatus(int status)
        {
            int rtn = 0;

            switch (status)
            {
                case 1:
                case -2:
                case 10:
                    rtn = 10;
                    Console.WriteLine("Player 1 Wins!");
                    break;
                case 2:
                case -1:
                case 20:
                    rtn = 20;
                    Console.WriteLine("Player 2 Wins!");
                    break;

                case 15:
                    rtn = 15;
                    Console.WriteLine("Player 1 and Player 2 are tied!");
                    break;
            }
            return rtn;
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
    10. Ace counts as 1 or 11.
    11. Ten-Jack-Queen-King count as 10.

    UI could ask player if they want to play Blackjack
    Explain to hit 'H' for "Hit Me", or 'S' for "Stand"
    UI Then asks to play again


    Mixing regular characters with Unicode characters should work, but sometimes the console settings or font might not support certain Unicode symbols.
    Here are a few things you can try:

    Ensure Console Font Supports Unicode: Make sure the console font supports Unicode characters. You can change the console font to one that supports 
    Unicode, such as "Consolas" or "Lucida Console".

    Use Unicode Escape Sequences: You can use Unicode escape sequences directly in your string. For example, instead of using Symbol(card.Suit),
    you can directly include the Unicode escape sequences in your string.

*/


