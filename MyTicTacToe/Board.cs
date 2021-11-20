using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    class Board
    {
        public enum GameState
        {
            IN_PROGRESS,
            X_WINS,
            O_WINS,
            DRAW
        }

        /// <summary>
        ///  The board is an array of tokens, 9 deep, arranged as a 3x3 grid
        /// </summary>
        private BoardToken[] grid;

        /// <summary>
        /// Current game state
        /// </summary>
        private GameState gameState;

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
                this.UpdateGameState();
            }
            else
            {
                // Bad parameters
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Is this board's game over yet?
        /// </summary>
        /// <returns>True when the game is over, false when still in progress</returns>
        public bool IsGameOver()
        {
            // Game over when 3 in a row match X or O, or all spots on the grid are filled and no winner
            return this.gameState != GameState.IN_PROGRESS;
        }

        /// <summary>
        /// Returns a string denoting the state of the game (in progress, winning player, or a draw)
        /// </summary>
        /// <returns>String denoting the game's state</returns>
        public string GetGameState()
        {
            switch (this.gameState)
            {
                case GameState.IN_PROGRESS:  return "In progress";
                case GameState.X_WINS:       return "Player X wins!";
                case GameState.O_WINS:       return "Player O wins!";
                case GameState.DRAW:         return "It's a draw!";
            }
            return null;
        }

        /// <summary>
        /// Method to check for a winner or draw and update the internal game state
        /// </summary>
        private void UpdateGameState()
        {
            // Game over when 3 in a row match X or O, or all spots on the grid are filled and no winner

            // Check horizontal lines
            for (int i = 0; i < 3; i++)
            {
                int offset = i * 3;
                if ((grid[offset].value != BoardToken.BoardTokenValue.BT_Empty) &&
                    (grid[offset].value == grid[offset + 1].value) &&
                    (grid[offset].value == grid[offset + 2].value))
                {
                    // not empty, and all three match
                    this.gameState = (grid[offset].value == BoardToken.BoardTokenValue.BT_X) ? GameState.X_WINS : GameState.O_WINS;
                    return;
                }
            }

            // No horizontal match, check vertical matches
            for (int i = 0; i < 3; i++)
            {
                if ((grid[i].value != BoardToken.BoardTokenValue.BT_Empty) &&
                    (grid[i].value == grid[i + 3].value) &&
                    (grid[i].value == grid[i + 6].value))
                {
                    // not empty, and all three match
                    this.gameState = (grid[i].value == BoardToken.BoardTokenValue.BT_X) ? GameState.X_WINS : GameState.O_WINS;
                    return;
                }
            }

            // No vertical match, check diagonal
            if ((grid[0].value != BoardToken.BoardTokenValue.BT_Empty) &&
                (grid[0].value == grid[4].value) &&
                (grid[0].value == grid[8].value))
            {
                // not empty, and all three match
                this.gameState = (grid[0].value == BoardToken.BoardTokenValue.BT_X) ? GameState.X_WINS : GameState.O_WINS;
                return;
            }
            if ((grid[2].value != BoardToken.BoardTokenValue.BT_Empty) &&
                (grid[2].value == grid[4].value) &&
                (grid[2].value == grid[6].value))
            {
                // not empty, and all three match
                this.gameState = (grid[2].value == BoardToken.BoardTokenValue.BT_X) ? GameState.X_WINS : GameState.O_WINS;
                return;
            }

            // No matches, check for all full
            for (int i = 0; i < 9; i++)
            {
                if (grid[i].value == BoardToken.BoardTokenValue.BT_Empty)
                {
                    // found an empty space, so game is not over
                    this.gameState = GameState.IN_PROGRESS;
                    return;
                }
            }

            // No matches, not all full, game is not over yet
            this.gameState = GameState.DRAW;
            return;
        }
    }
}
