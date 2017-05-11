//: Playground - noun: a place where people can play

import UIKit



struct Card{
    var value: String
    var suit: String
    var numerical_value: Int
    func display() -> String{
//        print("The \(value) of \(suit)")
        return("The \(value) of \(suit)")
    }
}

class Deck{
    var cards = [Card]()
    init(){
        self.reset()
    }
    func reset(){
        let suits = ["Clubs", "Spades","Hearts","Diamonds"]
        let values = ["A","2","3","4","5","6","7","8","9","10","J","Q","K"]
        for suit in suits{
            for i in 0...12{
                let newCard = Card(value: values[i], suit: suit, numerical_value: i+1)
//                newCard.display();
                cards.append(newCard)
            }
        }
    }
    func shuffle(){
        for _ in 1...200 {
            let randomval1 = Int(arc4random_uniform(UInt32(cards.count)))
            let randomval2 = Int(arc4random_uniform(UInt32(cards.count)))
            let temp = cards[randomval1]
            cards[randomval1] = cards[randomval2]
            cards[randomval2] = temp
        }
    }
    func deal() -> Card{
        let card = cards[0]
        cards.remove(at:0)
        return card
    }
}

class Player{
    var hand = [Card]()
    func draw(deck: Deck){
        hand.append(deck.deal())
    }
    func discard(suit: String, value: String) -> Bool{
        for i in 0..<hand.count{
            if (hand[i].suit == suit && hand[i].value == value){
                hand.remove(at: i)
                return true
            }
        }
        return false
    }
}

let gameDeck = Deck()
let Dalton = Player()

gameDeck.shuffle()

for card in gameDeck.cards{
    print(card.display())
}

print(Dalton.hand)
Dalton.draw(deck: gameDeck)
Dalton.draw(deck: gameDeck)
Dalton.draw(deck: gameDeck)
Dalton.draw(deck: gameDeck)

print(Dalton.hand)
print(Dalton.discard(suit: "Hearts", value: "K"))

