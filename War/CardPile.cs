using System;
using System.Collections.Generic;

namespace War
{
    /// <summary>
    /// A collection of cards, used to represent a deck of cards, a hand, discard pile, etc
    /// </summary>
    class CardPile
    {

        private List<Card> pile;


        /// <summary>
        /// Returns a new standard 52-card deck
        /// </summary>
        /// <returns></returns>
        public static CardPile StandardDeck()
        {
            CardPile newPile = new CardPile();

            foreach (Card.CardRank rank in Enum.GetValues(typeof(Card.CardRank)))
            {
                newPile.pile.Add(new Card(rank, Card.SUIT_HEARTS));
                newPile.pile.Add(new Card(rank, Card.SUIT_CLUBS));
                newPile.pile.Add(new Card(rank, Card.SUIT_DIAMONDS));
                newPile.pile.Add(new Card(rank, Card.SUIT_SPADES));
            }

            return newPile;
        }

        public CardPile() => pile = new List<Card>();
         

        public Card TakeTop()
        {
            Card card = pile[0];
            pile.RemoveAt(0);

            return card;
        }

        public void Add(Card card)
        {
            pile.Add(card);
        }

        public void Add(CardPile pile)
        {
            foreach (Card card in pile.pile)
            {
                this.pile.Add(card);
            }

            // and remove all cards from the other pile
            pile.pile.RemoveRange(0, pile.pile.Count);
        }

        public int Count()
        {
            return pile.Count;
        }

        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = 0; i < pile.Count; i++)
            {
                Card tmp = pile[i];
                int swap = rng.Next(0, pile.Count);
                pile[i] = pile[swap];
                pile[swap] = tmp;
            }
        }
    }
}
