using System;

namespace War
{
    class WarGame
    {

        private CardPile player1;
        private CardPile player2;
        private CardPile playPile;

        private GameState state;

        public enum GameState
        {
            IN_PROGRESS = 0,
            PLAYER1_WIN = 1,
            PLAYER2_WIN = 2
        }



        public WarGame()
        {
            Console.WriteLine("Finding a good deck of cards...");
            CardPile deck = CardPile.StandardDeck();

            player1 = new CardPile();
            player2 = new CardPile();
            playPile = new CardPile();

            Console.WriteLine("Shuffling deck...");
            deck.Shuffle();

            Console.WriteLine("Dealing cards...");
            // deal out the cards
            while (deck.Count() > 0)
            {
                player1.Add(deck.TakeTop());
                player2.Add(deck.TakeTop());
            }

            state = GameState.IN_PROGRESS;
        }

        public void TakeTurn()
        {
            if (state != GameState.IN_PROGRESS)
            {
                return; // cannot take turns when game is not in progress
            }

            int compare = PlayOneCardEach();

            while (0 == compare)
            {
                Console.WriteLine("WAR!");

                // add three cards to the pile in the middle
                PlayOneCardEach(true);
                PlayOneCardEach(true);
                PlayOneCardEach(true);

                // now place a card face up
                compare = PlayOneCardEach();
            }

            if (compare > 0)
            {
                // player 1 wins the pile
                player1.Add(playPile);
                Console.WriteLine("Player 1 wins this round!");
            }
            else
            {
                player2.Add(playPile);
                Console.WriteLine("Player 2 wins this round!");
            }

            CheckForWinner();
            Console.WriteLine("------------------------");
        }

        private void CheckForWinner()
        {
            if (player1.Count() == 0)
            {
                state = GameState.PLAYER2_WIN;
            }
            if (player2.Count() == 0)
            {
                state = GameState.PLAYER1_WIN;
            }
        }

        private int PlayOneCardEach(bool faceDown = false)
        {
            if (player1.Count() > 0 && player2.Count() > 0)
            {
                // get the top card from each player
                Card p1 = player1.TakeTop();
                Card p2 = player2.TakeTop();

                // TODO: abstract this out to a view, to allow for graphics in the future
                // Display the cards
                string p1card = faceDown ? "Face Down" : p1.ToString();
                string p2card = faceDown ? "Face Down" : p2.ToString();

                Console.WriteLine("Player 1 ({0,2} cards):  {1,10}  vs  {2,-10}  :({3,2} cards) Player 2", player1.Count(), p1card, p2card, player2.Count());

                int compare = p1.CompareTo(p2);

                playPile.Add(p1);
                playPile.Add(p2);

                return compare;
            }
            else
            {
                // someone ran out of cards, determine the winner and bail
                CheckForWinner();

                return (GameState.PLAYER1_WIN == state) ? 1 : -1;
            }
        }

        public bool GameInProgress()
        {
            return GameState.IN_PROGRESS == state;
        }

        public int GetWinner()
        {
            return (int)state;
        }
    }
}
