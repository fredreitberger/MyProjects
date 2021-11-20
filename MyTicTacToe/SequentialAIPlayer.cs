using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    /// <summary>
    /// This is a very basic "AI" for Tic Tac Toe
    /// 
    /// It will always pick the first open spot to play, left to right, top to bottom
    /// </summary>
    class SequentialAIPlayer : IPlayer
    {
        /// <summary>
        /// The player's token
        /// </summary>
        private readonly BoardToken token;

        /// <summary>
        /// Initializer, pass in the token for this player
        /// </summary>
        /// <param name="token"></param>
        public SequentialAIPlayer(BoardToken token) => this.token = token;


        /// <summary>
        /// Implementation to play one turn
        /// </summary>
        /// <param name="gameBoard">The board to place a token on</param>
        public void PlaceToken(Board gameBoard)
        {
            for (int i = 0; i < 9; i++)
            {
                if (gameBoard.CanPlaceTokenAtXY(i % 3, i / 3))
                {
                    gameBoard.PlaceTokenAtXY(i % 3, i / 3, this.token);
                    return;
                }
            }
        }
    }
}
