using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_V2
{
    class Card
    {
        //Card Properties

        public CardNumber CardNumber { get; set; }

        public Suit Suit { get; set; }


        //display card details

        public override string ToString() => string.Format("Card dealt is the {0} of {1}", CardNumber, Suit);


    }
}
