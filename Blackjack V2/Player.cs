using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_V2
{
    class Player
    {
        //properties of player
        public int playerScore { get; set; }

        //property to count aces
        public int playerAces { get; set; }

        //initialise properties to zero
        public Player()
        {
            playerScore = 0;
            playerAces = 0;
        }

        //method to add aces to player hand
        public void PlayerAceInTheHand(Card card)
        {
           
            if (card.CardNumber == CardNumber.Ace)
            {
                playerAces += 1;
            }
            
        }

        //diplay player score
        public override string ToString() => string.Format("Your Score is {0}", playerScore);
    }



}
