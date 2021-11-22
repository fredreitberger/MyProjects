using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("War card game!");

            WarGame game = new WarGame();

            // cards delt, now to play war!
            Console.WriteLine("Press any key to play a card");
            Console.ReadKey();

            while (game.GameInProgress())
            {
                game.TakeTurn();
                Console.ReadKey();
            }

            Console.WriteLine("Player {0} wins!", game.GetWinner());
            Console.ReadKey();
        }
    }
}
