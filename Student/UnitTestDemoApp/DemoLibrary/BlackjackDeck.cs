namespace DemoLibrary
{
    public class BlackjackDeck
    {
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
            }

            // Aces can count as 1 or 11 
            while (aceCount > 0)
            {
                if (sum + 10 <= 21)
                {
                    // Convert aces from 10 to eleven if they fit within 21 points total
                    sum += 10;
                }
                aceCount--;
            }

            return sum;
        }
    }
}
