using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    /// <summary>
    /// Interface for the game board display
    /// </summary>
    interface IBoardView
    {
        /// <summary>
        /// Command to draw the game board
        /// </summary>
        void DrawBoard();
    }
}
