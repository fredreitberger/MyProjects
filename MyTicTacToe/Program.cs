using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string input = Console.ReadLine();
            int a = Int32.Parse(input);

            Console.WriteLine("You wrote {0}", a);
            Console.ReadKey();
        }
    }
}
