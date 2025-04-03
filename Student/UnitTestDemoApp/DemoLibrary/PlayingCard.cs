namespace DemoLibrary
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
