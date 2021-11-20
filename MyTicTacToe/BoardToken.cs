using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    struct BoardToken
    {
        /// <summary>
        /// Tokens that can be placed on the board
        /// </summary>
        public enum BoardTokenValue
        {
            BT_Empty,
            BT_X,
            BT_O
        }

        /// <summary>
        /// The token representation
        /// </summary>
        public BoardTokenValue value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The token value to use</param>
        public BoardToken(BoardTokenValue value = BoardTokenValue.BT_Empty) => this.value = value;

        /// <summary>
        /// Gets the representation of this token
        /// </summary>
        /// <returns>String representation of the token</returns>
        public override string ToString()
        {
            switch (value)
            {
                case BoardTokenValue.BT_Empty: return " ";
                case BoardTokenValue.BT_X:     return "X";
                case BoardTokenValue.BT_O:     return "O";
            }
            return null;
        }
    }
}
