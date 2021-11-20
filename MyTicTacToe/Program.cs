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
            Console.WriteLine("Hello World!");

//            string input = Console.ReadLine();
//            int a = Int32.Parse(input);
//
//            Console.WriteLine("You wrote {0}", a);
//            Console.ReadKey();

            Board gameBoard = new Board();

            IBoardView view = new ConsoleBoardView(gameBoard);

            view.DrawBoard();

            gameBoard.PlaceTokenAtXY(0, 0, Board.BoardToken.BT_X);

            view.DrawBoard();

            gameBoard.PlaceTokenAtXY(1, 1, Board.BoardToken.BT_O);

            view.DrawBoard();

            Console.ReadKey();
        }
    }
}
