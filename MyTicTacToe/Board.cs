using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    class Board
    {


        /// <summary>
        ///  The board is an array of tokens, 9 deep, arranged as a 3x3 grid
        /// </summary>
        private BoardToken[] grid;

        public Board() => grid = new BoardToken[9] /*{ BoardToken.BT_Empty, BoardToken.BT_Empty, BoardToken.BT_Empty,
                                                     BoardToken.BT_Empty, BoardToken.BT_Empty, BoardToken.BT_Empty,
                                                     BoardToken.BT_Empty, BoardToken.BT_Empty, BoardToken.BT_Empty }*/;

        /// <summary>
        /// Returns the token at a given grid location
        /// </summary>
        /// <param name="x">X grid location on the board, 0 to 2, left to right</param>
        /// <param name="y">Y grid location on the board, 0 to 2, top to bottom</param>
        /// <returns>The token at the given location</returns>
        public BoardToken GetTokenAtXY(int x, int y)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                return grid[(y * 3) + x];
            }

            // Bad parameters
            throw new ArgumentException();
        }

        /// <summary>
        /// Check to see if the given grid location is empty
        /// </summary>
        /// <param name="x">X grid location on the board, 0 to 2, left to right</param>
        /// <param name="y">Y grid location on the board, 0 to 2, top to bottom</param>
        /// <returns>True if the location is empty, false if another token already occupies it</returns>
        public bool CanPlaceTokenAtXY(int x, int y)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                // Valid location, return true if the grid slot is empty
                return BoardToken.BoardTokenValue.BT_Empty == grid[(y * 3) + x].value;
            }

            // Bad parameters
            throw new ArgumentException();
        }

        /// <summary>
        /// Places a token at the specified grid location
        /// </summary>
        /// <param name="x">X grid location on the board, 0 to 2, left to right</param>
        /// <param name="y">Y grid location on the board, 0 to 2, top to bottom</param>
        /// <param name="token">The new token to place on the board</param>
        public void PlaceTokenAtXY(int x, int y, BoardToken token)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                grid[(y * 3) + x] = token;
            }
            else
            {
                // Bad parameters
                throw new ArgumentException();
            }
        }
    }
}
