using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackDemo
{
    public class Deck
    {
        // List to hold the cards in the deck
        private List<Card> cards;

        // Random number generator for shuffling the deck
        private Random Random;

        public Deck()
        {
            foreach (Enums.Suit suit in Enum.GetValues(typeof(Enums.Suit))) // Retrieves the values of the Suit enumeration
            {
                foreach (Enums.Rank rank in Enum.GetValues(typeof(Enums.Rank))) // Retrieves the values of the Rank enumeration 
                {
                    cards.Add(new Card(suit, rank)); // Creates a new Card object with the current suit and rank, and adds it to the cards list
                }
            }
        }

        public void Shuffle()
        {
            //Fisher-yates shuffle algorithm, which is an efficient and unbiased way to shuffle a list
            int n = cards.Count;
            for (int i = n - 1; i > 0; i--) // Start from the last element and go backwards
            {
                int j = Random.Next(0, i + 1); // Random index from 0 to i
                // Swap cards[i] with the element at random index
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty."); // Handle the case when there are no cards left in the deck
            }
            Card drawnCard = cards[0]; // Get the top card
            cards.RemoveAt(0); // Remove the top card from the deck
            return drawnCard; // Return the drawn card
        }

        public int CardsRemaining
        {
            get { return cards.Count; } // Property returns the number of cards left in the deck
        }



    }
}
