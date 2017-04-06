using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Player tester = new Player("Dalton");
            Console.WriteLine(myDeck);
        }
    }
}
