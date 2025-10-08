using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackDemo
{
    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>(); // Initialize the list of cards
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetValue()
        {
            int value = 0;
            int aceCount = 0;
            foreach (Card card in cards)
            {
                if (card.Rank == Enums.Rank.Ace)
                {
                    value++; 
                    aceCount++; 
                }
                else
                {
                    value += (int)card.Rank;
                }

                while (value > 21 && aceCount > 0)
                {
                    value -= 10; // Convert an Ace from 11 to 1 if the total value exceeds 21
                    aceCount--; // Decrease the count of Aces that can be converted
                }
            }
            return value;

        }

        public bool IsBusted()
        {
            return GetValue() > 21;
        }

        public bool IsBlackjack()
        {
            return cards.Count == 2 && GetValue() == 21; 
        }

        public bool IsSoft()
        {
            return cards.Any(card => card.Rank == Enums.Rank.Ace) && GetValue() <= 21; 
        }

    }

}