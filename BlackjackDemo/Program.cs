namespace BlackjackDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");

            Game game = new Game();
            game.PlayRound();

            Console.WriteLine("Thanks for playing!");

        }
    }
}
