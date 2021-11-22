using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("War card game!");

            Card testCard = new Card(Card.CardRank.RANK_ACE, Card.SUIT_CLUBS);

            Console.WriteLine("Card is a {0}", testCard);

            Console.ReadKey();
        }
    }
}
