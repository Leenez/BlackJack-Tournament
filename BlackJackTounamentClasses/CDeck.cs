using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackTounamentClasses
{
    public class CDeck : CEnums
    {
        private List<CCard> Deck { get; set; }
        private int Number_of_base_decks { get; set; }

        public CDeck(int Number_of_base_decks)
        {
            this.Number_of_base_decks = Number_of_base_decks;
            CreateDeck();
        }

        /// <summary>
        /// Creates the deck of cards. Total number of cards is 52 times Number_of_base_decks.
        /// </summary>
        private void CreateDeck()
        {
            Deck = new List<CCard>();
            List<int> Values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            for (int i = 0; i < Number_of_base_decks; i++)
            {

                //foreach (int n in Enum.GetValues(typeof(ECardValue)))
                foreach (int n in Values)
                {
                    foreach (ECardSuit s in Enum.GetValues(typeof(ECardSuit)))
                    {
                        ECardType Type;

                        if(n == 1) { Type = ECardType.Ace; }
                        else if(n < 11) { Type = ECardType.Common; }
                        else { Type = ECardType.Face; }

                        Deck.Add(new CCard(Type, n, s));
                    }
                }
            }
            ShuffleDeck();
        }

        /// <summary>
        /// Put the deck of cards list in random order.
        /// </summary>
        private void ShuffleDeck()
        {
            Random rnd = new Random();
            for (int i = 0; i < Deck.Count; i++)
            {
                int rndNumber = rnd.Next(0, Deck.Count - 1);
                CCard listItem = Deck[rndNumber];
                Deck[rndNumber] = Deck[i];
                Deck[i] = listItem;
            }
        }
        
        /// <summary>
        /// Takes and returns the next card from the deck. Used card is removed from the deck just like in a physical card game.
        /// </summary>
        /// <returns>CCard object</returns>
        public CCard GetCard()
        {
            if (Deck.Count < 30)
            {
                CreateDeck();
            }

            CCard NextCard = Deck[0];
            Deck.RemoveAt(0);

            return NextCard;
        }

    }
}
