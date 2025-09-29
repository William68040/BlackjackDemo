using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackDemo
{
    public class Hand
    {
        private List<Card> cards; // List to hold the cards in the hand

        public Hand()
        {
            cards = new List<Card>(); // Initialize the list of cards
        }

        public void AddCard(Card card)
        {
            cards.Add(card); // Add a card to the hand
        }

        public int GetValue()
        {
            int value = 0;
            int aceCount = 0;
            foreach (Card card in cards)
            {
                if (card.Rank == Enums.Rank.Ace)
                {
                    value++; // Initially count Ace as 1
                    aceCount++; // Keep track of the number of Aces
                }
                else
                {
                    value += (int)card.Rank; // Add the value of the card to the total
                }

                while (value > 21 && aceCount > 0)
                {
                    value -= 10; // Convert an Ace from 11 to 1 if the total value exceeds 21
                    aceCount--; // Decrease the count of Aces that can be converted
                }
            }
            return value; // Return the total value of the hand

        }

        public bool IsBusted()
        {
            return GetValue() > 21; // Check if the hand's value exceeds 21
        }

        public bool IsBlackjack()
        {
            return cards.Count == 2 && GetValue() == 21; // Check if the hand is a blackjack (two cards totaling 21)
        }

        public bool IsSoft()
        {
            return cards.Any(card => card.Rank == Enums.Rank.Ace) && GetValue() <= 21; // Check if the hand contains an Ace counted as 11 without busting
        }

    }

}