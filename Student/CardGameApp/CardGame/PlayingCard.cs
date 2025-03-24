namespace CardGameApp
{
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


