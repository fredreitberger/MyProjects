using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    /// <summary>
    /// Tic Tac Toe board view, using the console for rendering
    /// </summary>
    class ConsoleBoardView : IBoardView
    {
        /// <summary>
        /// The game board that this view will be drawing
        /// </summary>
        private Board board;

        public ConsoleBoardView(Board board) => this.board = board;

        /// <summary>
        /// Draws the current board to the console
        /// </summary>
        void IBoardView.DrawBoard()
        {
            Console.WriteLine("TicTacToe:");
            Console.WriteLine("{0}|{1}|{2}", GetTokenChar(0, 0), GetTokenChar(1, 0), GetTokenChar(2, 0));
            Console.WriteLine("-+-+-");
            Console.WriteLine("{0}|{1}|{2}", GetTokenChar(0, 1), GetTokenChar(1, 1), GetTokenChar(2, 1));
            Console.WriteLine("-+-+-");
            Console.WriteLine("{0}|{1}|{2}", GetTokenChar(0, 2), GetTokenChar(1, 2), GetTokenChar(2, 2));
            Console.WriteLine("");
        }

        /// <summary>
        /// Convienience method to get the character for a token at a location on the board. 
        /// </summary>
        /// <param name="x">X grid location on the board, 0 to 2, left to right</param>
        /// <param name="y">Y grid location on the board, 0 to 2, top to bottom</param>
        /// <returns>single character to represent the token at the given location</returns>
        private char GetTokenChar(int x, int y)
        {
            Board.BoardToken token = this.board.GetTokenAtXY(x, y);

            switch (token)
            {
                case Board.BoardToken.BT_Empty: return ' ';
                case Board.BoardToken.BT_X:     return 'X';
                case Board.BoardToken.BT_O:     return 'O';
            }
            // Error case, should never get here
            return '!';
        }
    }
}
