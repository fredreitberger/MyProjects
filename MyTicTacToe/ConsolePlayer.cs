using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    class ConsolePlayer : IPlayer
    {
        /// <summary>
        /// The player's token
        /// </summary>
        private readonly BoardToken token;

        /// <summary>
        /// Initializer, pass in the token for this player
        /// </summary>
        /// <param name="token"></param>
        public ConsolePlayer(BoardToken token) => this.token = token;


        /// <summary>
        /// Implementation to play one turn
        /// </summary>
        /// <param name="gameBoard">The board to place a token on</param>
        void IPlayer.PlaceToken(Board gameBoard)
        {
            int selection = PromptPlayer(gameBoard);

            gameBoard.PlaceTokenAtXY(selection % 3, selection / 3, this.token);
        }

        /// <summary>
        /// Helper method to prompt for a location to place a token
        /// </summary>
        /// <param name="gameBoard">The game board</param>
        /// <returns></returns>
        private int PromptPlayer(Board gameBoard)
        {
            int selection = -1;

            while (true)
            {
                Console.WriteLine("Player {0} turn:", this.token);
                Console.WriteLine("  1|2|3");
                Console.WriteLine("  -+-+-");
                Console.WriteLine("  4|5|6");
                Console.WriteLine("  -+-+-");
                Console.WriteLine("  7|8|9");
                Console.Write("Select a space (1-9):");

                selection = Int32.Parse(Console.ReadLine()) - 1; // convert from 1-9 to 0-8
                if (selection < 0 || selection >= 9)
                {
                    Console.WriteLine("Invalid selection, try again");
                    continue;
                }

                if (gameBoard.CanPlaceTokenAtXY(selection % 3, selection / 3))
                {
                    return selection;
                }
                else
                {
                    Console.WriteLine("That space is occupied, try again");
                    continue;
                }
            }
        }
    }
}
