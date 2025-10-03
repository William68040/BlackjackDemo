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

        // EnsureDeckReady
        public void EnsureDeckReady()
        {
            if (deck == null || deck.CardsRemaining < 15) // If the deck is null or has less than 15 cards, create and shuffle a new deck
            {
                deck = new Deck();
                deck.Shuffle();
            }
        }

        //DealInitial
        public void DealInitial()
        {
            playerHand.AddCard(deck.Draw()); // Deal the first card to the player
            dealerHand.AddCard(deck.Draw()); // Deal the first card to the dealer
            playerHand.AddCard(deck.Draw()); // Deal the second card to the player
            dealerHand.AddCard(deck.Draw()); // Deal the second card to the dealer

        }

        //CheckInitialBlackjack
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



        //PlayerTurn

        //DealerTurn

        //CompareHands

        //ShowHands
        public void ShowHands()
        {
            Console.WriteLine($"Player's hand: {playerHand.ToString()} (Value: {playerHand.GetValue()})");
            Console.WriteLine($"Dealer's visible card: {dealerHand.ToString()} (Value: {dealerHand.GetValue()})");
        }

        //RevealDealerHole
        public void RevealDealerHole()
        {
            Console.WriteLine($"Dealer's hole card is: {dealerHand.ToString()}"); // Reveal the dealer's hole card
        }

        //AskAction


        //AskPlayAgain

        //AnnounceResult(resultat)



    }
}
