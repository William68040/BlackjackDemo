using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackDemo
{
    public class Game
    {
        private Deck deck;
        private Hand playerHand;
        private Hand dealerHand;
        public void Play()
        {
            Console.WriteLine("The game is starting...");

            bool continuePlaying = true;

            while (continuePlaying)
            {
                PlayRound();
            }

        private void PlayRound()
        {
            ResetHands();
        }

        public void ResetHands()
        {
            playerHand = new Hand(); // Reset player hand for a new round
            dealerHand = new Hand();  // Reset dealer hand for a new round
        }

        public void EnsureDeckReady()
        {
            if (deck == null || deck.CardsRemaining < 15) // If the deck is null or has less than 15 cards, create and shuffle a new deck
            {
                deck = new Deck();
                deck.Shuffle();
            }
        }

        public void DealInitial()
        {
            playerHand.AddCard(deck.Draw()); // Deal the first card to the player
            dealerHand.AddCard(deck.Draw()); // Deal the first card to the dealer
            playerHand.AddCard(deck.Draw()); // Deal the second card to the player
            dealerHand.AddCard(deck.Draw()); // Deal the second card to the dealer

        }

        public bool CheckInitialBlackjack()
        {
            bool playerBlackjack = playerHand.IsBlackjack();
            bool dealerBlackjack = dealerHand.IsBlackjack();
            if (playerBlackjack || dealerBlackjack)
            {
                if (playerBlackjack && dealerBlackjack)
                {
                    Console.WriteLine("Both player and dealer have Blackjack! It's a push.");
                }
                else if (playerBlackjack)
                {
                    Console.WriteLine("Player has Blackjack! Player wins!");
                }
                else
                {
                    Console.WriteLine("Dealer has Blackjack! Dealer wins!");
                }
                return true; // Indicate that the round is over due to initial blackjack
            }
            return false; // No initial blackjack, continue the round
        }


        public void PlayerTurn()
        {
            while (true)
            {
                ShowHands();
                string action = AskAction(); 
                if (action == "hit")
                {
                    playerHand.AddCard(deck.Draw());
                    if (playerHand.IsBusted())
                    {
                        Console.WriteLine("Player busts! Dealer wins.");
                        return; // End player's turn if busted
                    }
                }
                else if (action == "stand")
                {
                    break; // End player's turn
                }
            }
        }

        public void DealerTurn()
        {
            RevealDealerHole(); // Reveal the dealer's hole card
            while (dealerHand.GetValue() < 17 || (dealerHand.GetValue() == 17 && dealerHand.IsSoft()))
            {
                dealerHand.AddCard(deck.Draw());
                Console.WriteLine("Dealer hits.");
                ShowHands(); // Show hands after each dealer action
                if (dealerHand.IsBusted())
                {
                    Console.WriteLine("Dealer busts! Player wins.");
                    return; // End dealer's turn if busted
                }
            }
            Console.WriteLine("Dealer stands.");
        }

        public string CompareHands()
        {
            int playerValue = playerHand.GetValue();
            int dealerValue = dealerHand.GetValue();
            if (playerValue > dealerValue)
            {
                return "Player wins!";
            }
            else if (playerValue < dealerValue)
            {
                return "Dealer wins!";
            }
            else
            {
                return "It's a push!";
            }
        }

        public void ShowHands()
        {
            Console.WriteLine($"Player's hand: {playerHand.ToString()} (Value: {playerHand.GetValue()})");
            Console.WriteLine($"Dealer's visible card: {dealerHand.ToString()} (Value: {dealerHand.GetValue()})");
        }

        public void RevealDealerHole()
        {
            Console.WriteLine($"Dealer's hole card is: {dealerHand.ToString()}"); // Reveal the dealer's hole card
        }

        public string AskAction() 
        {
            Console.WriteLine("Would you like to 'hit' or 'stand'?");
            string action = Console.ReadLine().ToLower();
            while (action != "hit" && action != "stand") // Validate input
            {
                Console.WriteLine("Invalid input. Please enter 'hit' or 'stand'.");
                action = Console.ReadLine().ToLower();
            }
            return action;
        }


        public bool AskPlayAgain()
        {
            Console.WriteLine("Would you like to play another round? (yes/no)");
            string response = Console.ReadLine().ToLower();
            while (response != "yes" && response != "no") // Validate input
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                response = Console.ReadLine().ToLower();
            }
            return response == "yes"; // Return true if the player wants to play again
        }

        public void AnnounceResult(string result)
        {
            Console.WriteLine(result); // Announce the result of the round
        }



    }
}
