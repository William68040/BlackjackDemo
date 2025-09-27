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


    }
}
