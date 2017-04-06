using System;
using System.Collections.Generic;

namespace DeckOfCards{
    public class Card{
        public string stringVal {
            get {
                if(val == 1){
                    return "Ace";
                }
                else if(val == 11){
                    return "Jack";
                }
                else if(val == 12){
                    return "Queen";
                }
                else if(val == 13){
                    return "King";
                }
                else if(val < 1 || val > 13){
                    return "Joker";
                }
                else{
                    return val.ToString();
                }
            }
        }
        public string suit;
        public int val;
        public Card(string cardsuit, int numVal){
            suit = cardsuit;
            val = numVal;
        }
        public override string ToString(){
            return stringVal + " of " + suit;;
        }
    }
}