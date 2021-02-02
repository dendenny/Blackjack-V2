using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_V2
{
    class Deck
    {
        //create list of cards
        public List<Card> Cards { get; set; }


        //deck properties: fill the deckk with the list of cards and call shuffle method to randomize the order
        public Deck()
        {
            FillDeck();
            Shuffle();
        }

        //fill the deck with cards using suit and cardnumber enums
        public void FillDeck()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(suit => Enumerable.Range(1, 13)
                                    .Select(card => new Card()
                                    {
                                        Suit = (Suit)suit,
                                        CardNumber = (CardNumber)card
                                    }
                                            )
                            )
                   .ToList();
        }


        //method to shuffle the cards
        public void Shuffle()
        {
            Random rand = new Random();
            Cards = Cards.OrderBy(c => rand.Next())
                         .ToList();
        }



        //take the first card and remove it from the deck
        public Card TakeCard()
        {
            System.Threading.Thread.Sleep(1000);//pause screen between cards

            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }



        //assign a value to each cardnumber enum
        public int checkValue(Card card)
        {
            
            switch (card.CardNumber)
            {
                case CardNumber.Ace:
                    return 11;
                case CardNumber.Two:
                    return 2;
                case CardNumber.Three:
                    return 3;
                case CardNumber.Four:
                    return 4;
                case CardNumber.Five:
                    return 5;
                case CardNumber.Six:
                    return 6;
                case CardNumber.Seven:
                    return 7;
                case CardNumber.Eight:
                    return 8;
                case CardNumber.Nine:
                    return 9;
                default:
                    return 10;
            }

        }


    }
}
