//: Playground - noun: a place where people can play

import UIKit

var array1 = [Int]()
for i in 1...255 {
    array1.append(i)
}

for i in 1...100 {
var randomval1 = Int(arc4random_uniform(UInt32(array1.count)))
var randomval2 = Int(arc4random_uniform(UInt32(array1.count)))
var temp: Int = array1[randomval1]
array1[randomval1] = array1[randomval2]
array1[randomval2] = temp
}


for i in 0..<array1.count{
    if(array1[i] == 42){
        array1.remove(at: i)
        print("We found the answer to the Ultimate Question of Life, the Universe, and Everything at index \(i)")
        break
    }
}
