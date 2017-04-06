using System;
using System.Collections.Generic;

namespace DeckOfCards{
    public class Deck{
        private List<Card> cards;
        public Deck()
        {
            Reset();
        }
        public Card Deal(){
            if(cards.Count > 0){
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }
            return null;
        }

        public Deck Shuffle(){
            Random rand = new Random();
            for(int idx = cards.Count -1; idx > 0; idx--){
                int randIdx = rand.Next(idx);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[idx];
                cards[idx] = temp;
            }
            return this;
        }

        public Deck Reset(){
            cards = new List<Card>();
            string[] suits =  new string[4] {"Hearts", "Diamonds","Clubs","Spades"};
            foreach(string suit in suits){
                for(int i = 1; i <= 13; i++){
                    cards.Add(new Card(suit, i));
                }
            }
            return this;
        }
        public override string ToString(){
            string info = "";
            foreach (Card card in cards){
                info += card + "\n";
            }
            return info;
        }
    }
}