using System;

namespace War
{
    class Card : IComparable
    {
        /// <summary>
        /// Card rank, Ace = 1, 2-10, Jack = 11, Queen = 12, King = 13
        /// </summary>
        private readonly CardRank rank;

        public enum CardRank
        {
            RANK_ACE = 1,
            RANK_2,
            RANK_3,
            RANK_4,
            RANK_5,
            RANK_6,
            RANK_7,
            RANK_8,
            RANK_9,
            RANK_10,
            RANK_JACK,
            RANK_QUEEN,
            RANK_KING
        }

        private readonly char suit;

        public const char SUIT_HEARTS   = '\x2665';
        public const char SUIT_CLUBS    = '\x2663';
        public const char SUIT_SPADES   = '\x2660';
        public const char SUIT_DIAMONDS = '\x2666';


        public Card(CardRank rank, char suit = SUIT_CLUBS)
        {
            if (rank < CardRank.RANK_ACE || rank > CardRank.RANK_KING)
            {
                throw new ArgumentException("Invalid card rank");
            }

            if (SUIT_HEARTS != suit && SUIT_CLUBS != suit &&
                SUIT_SPADES != suit && SUIT_DIAMONDS != suit)
            {
                // invalid suit
                throw new ArgumentException("Invalid card suit");
            }

            this.rank = rank;
            this.suit = suit;
        }

        public override string ToString()
        {
            switch (this.rank)
            {
                case CardRank.RANK_ACE:   return "Ace of " + suit;
                case CardRank.RANK_2:     return "Two of " + suit;
                case CardRank.RANK_3:     return "Three of " + suit;
                case CardRank.RANK_4:     return "Four of " + suit;
                case CardRank.RANK_5:     return "Five of " + suit;
                case CardRank.RANK_6:     return "Six of " + suit;
                case CardRank.RANK_7:     return "Seven of " + suit;
                case CardRank.RANK_8:     return "Eight of " + suit;
                case CardRank.RANK_9:     return "Nine of " + suit;
                case CardRank.RANK_10:    return "Ten of " + suit;
                case CardRank.RANK_JACK:  return "Jack of " + suit;
                case CardRank.RANK_QUEEN: return "Queen of " + suit;
                case CardRank.RANK_KING:  return "King of " + suit;
            }
            return null;
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(Card))
            {
                throw new InvalidOperationException();
            }

            Card other = (Card)obj;

            if (CardRank.RANK_ACE == this.rank)
            {
                // Ace is highest rank, but lowest in the enum listing so we need special code here
                return (CardRank.RANK_ACE == other.rank) ? 0 : 1;
            }
            else if (CardRank.RANK_ACE == other.rank)
            {
                return -1;
            }
            else
            {
                if (this.rank == other.rank)
                {
                    return 0;
                }

                // not equal, so 
                return (this.rank > other.rank) ? 1 : -1;
            }
        }
    }
}
