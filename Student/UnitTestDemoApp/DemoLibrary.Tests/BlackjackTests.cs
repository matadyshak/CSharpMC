// Arrange, Act, Assert
// Expected, Actual
namespace DemoLibrary.Tests
{
    public class BlackjackTests
    {
        [Fact]
        public void CalculateSumOfCards_AH_10D_ShouldReturn21()
        {
            // Arrange
            Random random = new Random(12345);
            BlackjackDeck blackjack = new BlackjackDeck(random);
            List<PlayingCard> hand = new List<PlayingCard>
            {
                new PlayingCard(CardSuits.Hearts, CardValues.Ace),
                new PlayingCard(CardSuits.Diamonds, CardValues.Ten)
            };

            // Act
            int actual = blackjack.CalculateSumOfCards(hand);
            int expected = 21;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateSumOfCards_AD_KS_ShouldReturn21()
        {
            Random random = new Random(12345);
            BlackjackDeck blackjack = new BlackjackDeck(random);
            // Arrange
            List<PlayingCard> hand = new List<PlayingCard>
            { new PlayingCard(CardSuits.Diamonds, CardValues.Ace),
              new PlayingCard(CardSuits.Spades, CardValues.King)
            };

            // Act
            int actual = blackjack.CalculateSumOfCards(hand);
            int expected = 21;

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> HandData =>
        new List<object[]>
        {
            new object[]
            {
                new List<PlayingCard>
                {
                    new PlayingCard(CardSuits.Diamonds, CardValues.Ace),
                    new PlayingCard(CardSuits.Spades, CardValues.King)
                },
                21
            }
        };

        [Theory]
        [MemberData(nameof(HandData))]
        public void CalculateSumOfCards_Inline(
            List<PlayingCard> hand,
            int expected)
        {
            Random random = new Random(12345);
            BlackjackDeck blackjack = new BlackjackDeck(random);
            int actual = blackjack.CalculateSumOfCards(hand);
            Assert.Equal(expected, actual);
        }
    }
}