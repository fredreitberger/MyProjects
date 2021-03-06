using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!  Welcome to the TicTacToe game (text version)");

            IPlayer player1 = PromptForPlayer(new BoardToken(BoardToken.BoardTokenValue.BT_X));
            IPlayer player2 = PromptForPlayer(new BoardToken(BoardToken.BoardTokenValue.BT_O));

            IPlayer currentPlayer = player1;

            Board gameBoard = new Board();

            IBoardView view = new ConsoleBoardView(gameBoard);

            view.DrawBoard();

            while (!gameBoard.IsGameOver())
            {
                currentPlayer.PlaceToken(gameBoard);

                view.DrawBoard();

                currentPlayer = (currentPlayer == player1) ? player2 : player1;
            }

            // Print the winner
            Console.WriteLine(gameBoard.GetGameState());

            Console.ReadKey();
        }


        /// <summary>
        /// Prompt to choose a player type
        /// </summary>
        /// <param name="player">The player's token</param>
        /// <returns>A new player</returns>
        static private IPlayer PromptForPlayer(BoardToken player)
        {
            while (true)
            {
                Console.WriteLine("  Choose player {0}:", player);
                Console.WriteLine("    1) Human (console)");
                Console.WriteLine("    2) Sequential AI");
                Console.WriteLine("    3) Random AI");

                int selection = 0;
                
                if (!Int32.TryParse(Console.ReadLine(), out selection))
                {
                    selection = 0; // force an invalid selection and try again
                }

                switch(selection)
                {
                    case 1: return new ConsolePlayer(player);
                    case 2: return new SequentialAIPlayer(player);
                    case 3: return new RandomAIPlayer(player);
                }

                // if we get here, it was an invalid selection
                Console.WriteLine("Invalid selection, try again");
            }
        }
    }
}
