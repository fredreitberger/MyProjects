using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    /// <summary>
    /// Player abstraction interface
    /// </summary>
    interface IPlayer
    {
        /// <summary>
        /// Player takes a turn by placing a token on the board
        /// </summary>
        void PlaceToken(Board gameBoard);
    }
}
