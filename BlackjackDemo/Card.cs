using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackDemo
{
    public class Card
    {
        // Properties for Suit and Rank of the card, excluding "set" to make them inmutable
        public Enums.Suit Suit { get; }
        public Enums.Rank Rank { get; }

        // Constructor to initialize a card with a specific suit and rank
        public Card(Enums.Suit suit, Enums.Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        // Returns a string representation of the card, e.g., "Ace of Spades"
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }


    }
}
