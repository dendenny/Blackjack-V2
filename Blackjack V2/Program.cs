using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            //loop game to play again
            while (true)
            {
                Console.WriteLine("Welcome to Blackjack!");
                Console.WriteLine(" ");//blank line

                PauseScreen();//pause the screen for a second

                PlayBlackjack();

                PauseScreen();

                Console.WriteLine(" ");//blank line

                Console.WriteLine("Do you want to play again? - Y / N");//display mnessage to play again
                if (Console.ReadLine().ToLower() != "y")
                    break;

                //clear screen for next game
                Console.Clear();

            }


            //play blackjack game method
            void PlayBlackjack()
            {

                //create deck
                Deck deck = new Deck();

                //create player
                Player player1 = new Player();

                //create dealer
                Dealer dealer1 = new Dealer();


                //declare constants
                const int BLACKJACK = 21;
                const int DEALERSMINIMUM = 16;




                //deal first 2 cards to player and display
                Console.WriteLine("Cards being dealt to the player");

                player1.playerScore += DealCardToPlayer();

                player1.playerScore += DealCardToPlayer();

                //pause screen and display score
                PauseScreen();
                Console.WriteLine(player1);



                //deal first card to dealer and display
                PauseScreen();
                Console.WriteLine(" ");//blank line
                Console.WriteLine("Cards being Dealt to the dealer");


                dealer1.dealerScore += DealCardToDealer();


                PauseScreen();
                Console.WriteLine(dealer1);


                //player sticks or twists
                int finalPlayerScore = player1.playerScore + StickOrTwist();


                //get the winner
                GetWinner();


                // Game Finished



                /*
                 check for aces
                 Console.WriteLine(player1.playerAces);
                 Console.WriteLine(dealer1.dealerAces);
                */




                //Game Methods 


                //take card from deck, deal to player or dealer and display
                int DealCardToPlayer()
                {
                    int cardValue = 0;//initialise card value to zero

                    var card1 = deck.TakeCard();//take a card from the deck

                    cardValue += deck.checkValue(card1);//check the cards value and add to cardvalue


                    Console.WriteLine(card1);

                    player1.PlayerAceInTheHand(card1);//check if the card is an ace, add to player hand if it is

                    return cardValue;

                }


                // offer player the choice to stick or twist, display cards dealt and return value of cards dealt

                int StickOrTwist()
                {
                    int twistvalue = 0;

                    //continue stick or twist loop until player is bust or decides to stick

                    bool twist = true; //while twist is true, stick or twist option will be offered

                    while (twist)
                    {

                        //ask user to stick or twist
                        PauseScreen();
                        Console.WriteLine(" ");
                        Console.WriteLine("Do You want to Stick or Twist? - T to Twist, Any key to stick.");

                        if (Console.ReadLine().ToLower() == "t")
                        {
                            var card1 = deck.TakeCard();

                            twistvalue += deck.checkValue(card1);
                            player1.PlayerAceInTheHand(card1); //check if the card is an ace and put in players hand


                            Console.WriteLine(card1);

                            // if the player has an ace and is over 21, this statement will take 10 off, changing ACE from 11 to 1
                            if (player1.playerAces > 0 && player1.playerScore + twistvalue > 21)
                            {
                                twistvalue -= 10;

                            }


                            if (player1.playerScore + twistvalue <= BLACKJACK)//if players score is les than 21, offer to twist again
                            {
                                twist = true;
                            }


                            else twist = false;//player is over 21 and breaks loop. 
                            PauseScreen();
                            Console.WriteLine("your Score is {0}", player1.playerScore + twistvalue);
                        }

                        else
                        {

                            Console.WriteLine("You decided to stick.");//stick option to break loop
                            twist = false;

                        }


                    }


                    return twistvalue;//return twistvalue to player total score


                }



                //deals the first card to dealer, then displays this card to player 
                int DealCardToDealer()
                {
                    int cardValue = 0;

                    var card1 = deck.TakeCard();

                    cardValue += deck.checkValue(card1);

                    Console.WriteLine(card1);

                    dealer1.DealerAceInTheHand(card1);//check if the card is an ace
                    return cardValue;



                }


                //deal second card to dealer and hit if 16 or under
                int DealerHit(int _dealerscore)//pass in current dealer score after the first card
                {
                    int newdealerscore = _dealerscore;


                    while (newdealerscore <= DEALERSMINIMUM)//continue loop while dealer score is 16 or under
                    {

                        PauseScreen();

                        Console.WriteLine("Cards being Dealt to the dealer");

                        var card1 = deck.TakeCard();//deal card
                        newdealerscore += deck.checkValue(card1);// check card value and add it to dealerscore

                        dealer1.DealerAceInTheHand(card1);//check if the card is an ace


                        if (dealer1.dealerAces > 0 && newdealerscore > 21)// if dealer is over 21 but has an ace, take 10 off score to change ace to 1
                        {
                            newdealerscore -= 10;
                        }


                        Console.WriteLine(card1);

                        PauseScreen();

                        Console.WriteLine("Dealer Score is {0}", newdealerscore);

                    }


                    return newdealerscore;

                }




                void GetWinner() //if  player under 21 play rest of game, if player over 21 finish game
                {

                    PauseScreen();

                    if (finalPlayerScore <= BLACKJACK) //if the player is 21 or under then deal cards to dealer
                    {
                        //deal second card and following cards to dealer and display
                        int finalDealerScore = DealerHit(dealer1.dealerScore);

                        if (finalDealerScore > BLACKJACK)//if dealer goes over 21 dealer is bust, display Player win
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Dealer Bust! Congratulations! You Win!");
                        }


                        else//if both players 21 or under, call compare scores method to compare and  get winner
                        {
                            Console.WriteLine(" ");
                            CompareScores(finalPlayerScore, finalDealerScore);
                        }


                    }
                    else // if player is over 21 display bust
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Final Score: {0}. Bust! Sorry, you Lose!", finalPlayerScore);
                    }

                }




                // compare scores
                void CompareScores(int _playerScore, int _dealerscore)
                {
                    if (_playerScore > _dealerscore)//if player score is higher
                    {
                        Console.WriteLine("Congratulations, You Win!");
                    }
                    else if (_playerScore < _dealerscore)//if dealer score is higher
                    {
                        Console.WriteLine("Sorry, You Lose");
                    }
                    else if (_playerScore == _dealerscore)//if scores are equal
                    {
                        Console.WriteLine("Draw");
                    }
                }



            }



            //method to pause screen
            void PauseScreen()
            {
                System.Threading.Thread.Sleep(1000);//pause screen for a second

            }

        }
    }
}
