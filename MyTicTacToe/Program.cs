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

            IPlayer player1 = new ConsolePlayer(new BoardToken(BoardToken.BoardTokenValue.BT_X));
            IPlayer player2 = new RandomAIPlayer(new BoardToken(BoardToken.BoardTokenValue.BT_O));

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
            Console.WriteLine(gameBoard.GetWinner());

            Console.ReadKey();
        }
    }
}
