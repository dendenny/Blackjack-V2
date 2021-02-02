using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_V2
{
    class Dealer
    {
        //dealer properties, score and aces
        public int dealerScore { get; set; }

        public int dealerAces { get; set; }


        //initialise dealer score and aces to zero
        public Dealer()
        {
            dealerScore = 0;
            dealerAces = 0;
        }


        //add aces to dealer hand
        public void DealerAceInTheHand(Card card)
        {

            if (card.CardNumber == CardNumber.Ace)
            {
                dealerAces += 1;
            }

        }


        //method to diplay dealer score
        public override string ToString() => string.Format("Dealer Score is {0}", dealerScore);
    }
}
