//: Playground - noun: a place where people can play

import UIKit

func tossCoin() -> String {
    print("Tossing a Coin!")
    let resultval = Int(arc4random_uniform(UInt32(2)))
    var result = "Tails"
    if (resultval == 0){
        result = "Heads"
    }
    print(result)
    return(result)
}

func tossMultipleCoins(tosses: Int) -> Double {
    var headcount = 0
    for _ in 0...tosses {
        if tossCoin() == "Heads" {
            headcount += 1
        }
    }
    return (Double(headcount) / Double(tosses))
}

print(tossMultipleCoins(tosses: 20))
