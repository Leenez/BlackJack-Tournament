using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackTounamentClasses
{
    public class CCard : CEnums
    {   
        /// <summary>
        /// Types: Face, Ace and Common. 
        /// Suits: C (clubs), D (diamonds), H (hears) and S (spades).
        /// Values in Black Jack 1 - 11. Face cars are 10 and Ace can be either 10 or 11.
        /// </summary>
        public ECardType Type { get; set; }
        public ECardSuit Suit { get; set; }
        //public ECardValue Value { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// Card properties have their specifick enumerated values.
        /// </summary>
        /// <param name="Type">face, ace and common. </param>
        /// <param name="Value">1 - 11. Face cars are 10 and Ace can be either 10 or 11</param>
        /// <param name="Suit">C (clubs), D (diamonds), H (hears) and S (spades)</param>
        public CCard(ECardType Type, int Value, ECardSuit Suit)
        {
            this.Type = Type;
            this.Suit = Suit;
            this.Value = Value;
        }

        /// <summary>
        /// Returns filename for the card. Example: "1A.jpg"
        /// </summary>
        /// <returns></returns>
        public string CardName()
        {
            return this.Value.ToString() + this.Suit.ToString() + ".jpg";
        }
    }
}

