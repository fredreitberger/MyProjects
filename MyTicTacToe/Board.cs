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
        /// Tokens that can be placed on the board
        /// </summary>
        enum BoardToken
        {
            BT_Empty,
            BT_X,
            BT_O
        }

        /// <summary>
        ///  The board is an array of tokens, 9 deep, arranged as a 3x3 grid
        /// </summary>
        private BoardToken[] grid;

        
    }
}
