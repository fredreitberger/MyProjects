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
            IPlayer player2 = new ConsolePlayer(new BoardToken(BoardToken.BoardTokenValue.BT_O));


            Board gameBoard = new Board();

            IBoardView view = new ConsoleBoardView(gameBoard);

            view.DrawBoard();

            player1.PlaceToken(gameBoard);
//            gameBoard.PlaceTokenAtXY(0, 0, new BoardToken(BoardToken.BoardTokenValue.BT_X));

            view.DrawBoard();

            gameBoard.PlaceTokenAtXY(1, 1, new BoardToken(BoardToken.BoardTokenValue.BT_O));

            view.DrawBoard();

            Console.ReadKey();
        }
    }
}
