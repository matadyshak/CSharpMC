using System.Collections;

// Arrange, Act, Assert
// Expected, Actual
namespace DemoLibrary.Tests
{
    public class BlackjackTests
    {
        /////////////////////////////////////////////////////////////////
        // [Fact] - Individual Tests
        /////////////////////////////////////////////////////////////////
        [Fact]
        public void CalculateSumOfCards_4A_42_33_ShouldReturn21()
        {
            // Arrange
            Random random = new Random(12345);
            BlackjackDeck blackjack = new BlackjackDeck(random);
            List<PlayingCard> hand = new List<PlayingCard>
            {
                new PlayingCard(CardSuits.Hearts, CardValues.Ace),
                new PlayingCard(CardSuits.Diamonds, CardValues.Ace),
                new PlayingCard(CardSuits.Spades, CardValues.Ace),
                new PlayingCard(CardSuits.Clubs, CardValues.Ace),
                new PlayingCard(CardSuits.Hearts, CardValues.Two),
                new PlayingCard(CardSuits.Diamonds, CardValues.Two),
                new PlayingCard(CardSuits.Spades, CardValues.Two),
                new PlayingCard(CardSuits.Clubs, CardValues.Two),
                new PlayingCard(CardSuits.Spades, CardValues.Three),
                new PlayingCard(CardSuits.Clubs, CardValues.Three),
                new PlayingCard(CardSuits.Hearts, CardValues.Three)
            };

            // Act
            int actual = blackjack.CalculateSumOfCards(hand);
            int expected = 21;

            // Assert
            Assert.Equal(expected, actual);
        }

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
            {
              new PlayingCard(CardSuits.Diamonds, CardValues.Ace),
              new PlayingCard(CardSuits.Spades, CardValues.King)
            };

            // Act
            int actual = blackjack.CalculateSumOfCards(hand);
            int expected = 21;

            // Assert
            Assert.Equal(expected, actual);
        }

        /////////////////////////////////////////////////////////////////
        // IEnumerable <object> - Specify data for a suite of tests
        // [Theory]
        // [MemberData(nameof(HandData))
        /////////////////////////////////////////////////////////////////
        public static IEnumerable<object[]> HandData => new List<object[]>
        {
            new object[]
            {
                new List<PlayingCard>
                {
                    new PlayingCard(CardSuits.Diamonds, CardValues.Ace),
                    new PlayingCard(CardSuits.Spades, CardValues.Ace),
                    new PlayingCard(CardSuits.Clubs, CardValues.Ace),
                    new PlayingCard(CardSuits.Hearts, CardValues.Two),
                    new PlayingCard(CardSuits.Diamonds, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Two),
                    new PlayingCard(CardSuits.Clubs, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Three),
                    new PlayingCard(CardSuits.Clubs, CardValues.Three),
                    new PlayingCard(CardSuits.Hearts, CardValues.Three)
                },
                20
            },
            new object[]
            {
                new List<PlayingCard>
                {
                    new PlayingCard(CardSuits.Spades, CardValues.Ace),
                    new PlayingCard(CardSuits.Clubs, CardValues.Ace),
                    new PlayingCard(CardSuits.Hearts, CardValues.Two),
                    new PlayingCard(CardSuits.Diamonds, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Two),
                    new PlayingCard(CardSuits.Clubs, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Three),
                    new PlayingCard(CardSuits.Clubs, CardValues.Three),
                    new PlayingCard(CardSuits.Hearts, CardValues.Three)
                },
                19
            },
            new object[]
            {
                new List<PlayingCard>
                {
                    new PlayingCard(CardSuits.Clubs, CardValues.Ace),
                    new PlayingCard(CardSuits.Hearts, CardValues.Two),
                    new PlayingCard(CardSuits.Diamonds, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Two),
                    new PlayingCard(CardSuits.Clubs, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Three),
                    new PlayingCard(CardSuits.Clubs, CardValues.Three),
                    new PlayingCard(CardSuits.Hearts, CardValues.Three)
                },
                18
            },
            new object[]
            {
                new List<PlayingCard>
                {
                    new PlayingCard(CardSuits.Hearts, CardValues.Two),
                    new PlayingCard(CardSuits.Diamonds, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Two),
                    new PlayingCard(CardSuits.Clubs, CardValues.Two),
                    new PlayingCard(CardSuits.Spades, CardValues.Three),
                    new PlayingCard(CardSuits.Clubs, CardValues.Three),
                    new PlayingCard(CardSuits.Hearts, CardValues.Three)
                },
                17
            }
            // Add more test cases as needed
        };

        [Theory]
        [MemberData(nameof(HandData))]
        public void CalculateSumOfCards_MemberData(List<PlayingCard> hand, int expected)
        {
            Random random = new Random(12345);
            BlackjackDeck blackjack = new BlackjackDeck(random);
            int actual = blackjack.CalculateSumOfCards(hand);
            Assert.Equal(expected, actual);
        }

        /////////////////////////////////////////////////////////////////
        // Using ClassData with Parameterized Constructor
        // [Theory]
        // [ClassData(typeof(HandDataClass))]
        /////////////////////////////////////////////////////////////////

        public class HandDataClass : IEnumerable<object[]>
        {
            private readonly List<object[]> _data;

            // Constructer
            public HandDataClass()
            {
                _data = new List<object[]>
                {
                    new object[]
                    {
                        new List<PlayingCard>
                        {
                            new PlayingCard(CardSuits.Diamonds, CardValues.Five),
                            new PlayingCard(CardSuits.Spades, CardValues.Queen)
                        },
                        15
                    },
                    new object[]
                    {
                        new List<PlayingCard>
                        {
                            new PlayingCard(CardSuits.Hearts, CardValues.Jack),
                            new PlayingCard(CardSuits.Diamonds, CardValues.Seven)
                        },
                        17
                    },
                    new object[]
                    {
                        new List<PlayingCard>
                        {
                            new PlayingCard(CardSuits.Hearts, CardValues.Seven),
                            new PlayingCard(CardSuits.Diamonds, CardValues.Seven),
                            new PlayingCard(CardSuits.Diamonds, CardValues.Eight)
                        },
                        22
                    },
                    new object[]
                    {
                        new List<PlayingCard>
                        {
                            new PlayingCard(CardSuits.Hearts, CardValues.Jack),
                            new PlayingCard(CardSuits.Diamonds, CardValues.Queen),
                            new PlayingCard(CardSuits.Diamonds, CardValues.King)
                        },
                        30
                    }
                    // Add more test cases as needed
                };
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class BlackjackTestsHandDataClass
        {
            [Theory]
            [ClassData(typeof(HandDataClass))]
            public void CalculateSumOfCards_ClassData(List<PlayingCard> hand, int expected)
            {
                Random random = new Random(12345);
                BlackjackDeck blackjack = new BlackjackDeck(random);
                int actual = blackjack.CalculateSumOfCards(hand);
                Assert.Equal(expected, actual);
            }
        }
    }
}
