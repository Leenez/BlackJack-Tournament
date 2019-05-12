using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackTounamentClasses
{
    public class CPlayer
    {   
        /// <summary>
        /// Player name and amount of chips player currently has with initial default values.
        /// Variables for if player has doubled during the current round, current bet, list for current player cards and for splitted cards.
        /// </summary>
        public string Name { get; set; } = "Test Player";
        public int Chips { get; set; } = 100;
        public bool Doubled { get; set; } = false;
        public int Bet { get; set; } = 0;
        private List<CCard> CardList1 { get; set; } = new List<CCard>();
        private List<CCard> CardList2 { get; set; } = new List<CCard>();

        /// <summary>
        /// Constructors for default values and user defined values.
        /// </summary>
        public CPlayer()
        {

        }

        public CPlayer(string Name, int Chips)
        {
            this.Name = Name;
            this.Chips = Chips;
        }

        /// <summary>
        /// If player splits cards are arranged in two lists and returned as a list.
        /// </summary>
        /// <returns>List of two cards used in split.</returns>
        public List<CCard> SetSplit()
        {
            CCard Movable = CardList1[1];
            CCard Staying = CardList1[0];
            CardList2.Add(Movable);
            CardList1 = new List<CCard>() { Staying };
            List<CCard> SplittedList = new List<CCard>() { CardList1[0], CardList2[0] };
            return SplittedList;
        }

        /// <summary>
        /// Player takes a card which is added to CardList1
        /// </summary>
        /// <param name="deck">CDeck object used for the game</param>
        /// <returns>CCard object</returns>
        public List<CCard> GetCard1(CDeck deck)
        {   
            CardList1.Add(deck.GetCard());
            return CardList1;
        }

        /// <summary>
        /// Player takes a card which is added to CardList2. This is used if player decides to split cards.
        /// </summary>
        /// <param name="deck">CDeck object used for the game</param>
        /// <returns>CCard object</returns>
        public List<CCard> GetCard2(CDeck deck)
        {
            CardList2.Add(deck.GetCard());
            return CardList2;
        }

        public List<CCard> GetCardList1()
        {
            return CardList1;
        }

        public List<CCard> GetCardList2()
        {
            return CardList2;
        }

        public void ResetPlayerCards()
        {
            CardList1 = new List<CCard>();
            CardList2 = new List<CCard>();
        }

        /// <summary>
        /// Update the amount of chips player has and return updated amount.
        /// If player has doubled the amount is two times the bet.
        /// </summary>
        /// <param name="add">Defines if chips are added (true) or subtracted (false)</param>
        /// <returns>Current amount of chips that player has.</returns>
        public int ChangeChips(bool add)
        {
            if (this.Doubled)
            {
                if (add)
                {
                    this.Chips += 2 * this.Bet;
                }
                else
                {
                    this.Chips -= 2 * this.Bet;
                }
            }
            else
            {
                if (add)
                {
                    this.Chips += this.Bet;
                }
                else
                {
                    this.Chips -= this.Bet;
                }
            }

            return this.Chips;
        }
    }
}
