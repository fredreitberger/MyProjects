using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    /// <summary>
    /// A collection of cards, used to represent a deck of cards, a hand, discard pile, etc
    /// </summary>
    class CardPile
    {

        private Card[] pile;


        /// <summary>
        /// Returns a new standard 52-card deck
        /// </summary>
        /// <returns></returns>
        public static CardPile StandardDeck()
        {
            CardPile newPile = new CardPile();

            foreach (Card.CardRank rank in Enum.GetValues(typeof(Card.CardRank)))
            {
                newPile.pile.Append(new Card(rank, Card.SUIT_HEARTS));
                newPile.pile.Append(new Card(rank, Card.SUIT_CLUBS));
                newPile.pile.Append(new Card(rank, Card.SUIT_DIAMONDS));
                newPile.pile.Append(new Card(rank, Card.SUIT_SPADES));
            }

            return newPile;
        }


        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = 0; i < pile.Length; i++)
            {
                Card tmp = pile[i];
                int swap = rng.Next(0, pile.Length);
                pile[i] = pile[swap];
                pile[swap] = tmp;
            }
        }
    }
}
