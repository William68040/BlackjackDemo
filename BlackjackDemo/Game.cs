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



    }
}
