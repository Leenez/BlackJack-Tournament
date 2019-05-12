using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackTounamentClasses
{
    /// <summary>
    /// Simulates the dealer in Blackjack game.
    /// </summary>
    public class CDealer
    {
        /// <summary>
        /// List of current dealer cards.
        /// </summary>
        public List<CCard> DealerCards { get; set; } = new List<CCard>();

        /// <summary>
        /// Dealer takes a new card and returns all current cards as a list.
        /// </summary>
        /// <param name="deck">Deck of cards dealer uses.</param>
        /// <returns>Current dealer cards as a list</returns>
        public List<CCard> GetDealerCard(CDeck deck)
        {
            DealerCards.Add(deck.GetCard());
            return DealerCards;
        }

        /// <summary>
        /// Resets dealer cards to an empty list.
        /// </summary>
        public void ResetDealerCards()
        {
            DealerCards = new List<CCard>();
        }

        /// <summary>
        /// Method for counting the sum of cards in a list.
        /// </summary>
        /// <param name="list">List of cards</param>
        /// <returns>The sum of cards in a list</returns>
        public static int CountResult(List<CCard> list)
        {
            int sum = 0;
            int acecount = 0;

            foreach(CCard c in list)
            {
                if(c.Type == CEnums.ECardType.Ace)
                {
                    acecount += 1;
                }
            }

            if (acecount == 2 && list.Count == 2)
            {
                return 21;
            }

            foreach (CCard c in list)
            {
                int bjvalue = c.Value;
                if(bjvalue > 10)
                {
                    bjvalue = 10;
                }
                sum += bjvalue;
            }

            if (acecount >= 1)
            {
                sum += 10*acecount;
            }

            if (sum > 21)
            {
                sum -= acecount;
            }

            return sum;
        }


        /// <summary>
        /// Check if player gets two of the same valued cards.
        /// </summary>
        /// <param name="list">List of cards</param>
        /// <returns>True if there are two same valued cards.</returns>
        public bool SplitChange(List<CCard> list)
        {
            if (list.Count == 2)
            {
                if (list[0].Value == list[1].Value)
                {
                    return true;
                } 
            }
            return false;
        }

        /// <summary>
        /// Method for checking if player or dealer gets BlackJack.
        /// </summary>
        /// <param name="list">List of cards</param>
        /// <returns>True if there is a BlackJack. False if not.</returns>
        public bool CheckBlackJack(List<CCard> list)
        {
            if (list.Count == 2)
            {
                if ((list[0].Type == CEnums.ECardType.Ace && list[1].Value >= 10) || (list[1].Type == CEnums.ECardType.Ace && list[0].Value >= 10))
                {
                    return true;
                }

            }
            return false;
           
        }
    }
}
