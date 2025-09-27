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
        public Enums.Suit Suit { get; }
        public Enums.Rank Rank { get; }
        public Card(Enums.Suit suit, Enums.Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }


    }
}
