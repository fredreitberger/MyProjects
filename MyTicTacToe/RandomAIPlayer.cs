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
    /// It will pick a random space to play each turn
    /// </summary>
    class RandomAIPlayer : IPlayer
    {
        /// <summary>
        /// The player's token
        /// </summary>
        private readonly BoardToken token;

        /// <summary>
        /// Initializer, pass in the token for this player
        /// </summary>
        /// <param name="token"></param>
        public RandomAIPlayer(BoardToken token) => this.token = token;


        /// <summary>
        /// Implementation to play one turn
        /// </summary>
        /// <param name="gameBoard">The board to place a token on</param>
        public void PlaceToken(Board gameBoard)
        {
            while (true)
            {
                Random rng = new Random();

                int i = rng.Next(0, 8);

                if (gameBoard.CanPlaceTokenAtXY(i % 3, i / 3))
                {
                    gameBoard.PlaceTokenAtXY(i % 3, i / 3, this.token);
                    return;
                }
            }
        }
    }
}
