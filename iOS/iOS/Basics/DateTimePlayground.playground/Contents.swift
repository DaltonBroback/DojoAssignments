//: Playground - noun: a place where people can play

import UIKit

let date = Date()
let calendar = Calendar.current
let hour = calendar.component(.hour, from: date)
let minutes = calendar.component(.minute, from: date)

print(date)