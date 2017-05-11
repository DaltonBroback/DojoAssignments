//: Playground - noun: a place where people can play

import UIKit

class Animal {
    var name: String
    var health = 100
    init(name: String){
        self.name = name
    }
    func displayHealth(){
        print(self.name, "Health:", self.health)
    }
}

class Cat: Animal {
    override init(name: String){
        super.init(name: name)
        self.health = 150
    }
    func growl(){
        print("Rawr!")
    }
    func run(){
        print("Running")
        self.health -= 10
    }

}

class Lion: Cat {
    override init(name: String){
        super.init(name: name)
        self.health = 200
    }
    override func growl(){
        print("ROAR!!!! I am the King of the Jungle")
    }
}

class Cheetah: Cat {
    override func run(){
        self.health -= 50
        if self.health < 0{
            self.health = 0
            print("Too tired to run")
        }
        else{
            print("Running Fast")
        }
    }
    func sleep(){
        print("Sleeping")
        self.health += 50
        if self.health > 200{
            self.health = 200
        }
    }

}

print("TESTS")
var Fido = Animal(name: "Fido")
Fido.displayHealth()

var Bubsy = Cat(name: "Bubsy")
Bubsy.displayHealth()
Bubsy.run()
Bubsy.displayHealth()

var Sonic = Cheetah(name: "Sonic")
Sonic.displayHealth()
Sonic.run()
Sonic.displayHealth()
Sonic.sleep()
Sonic.displayHealth()
Sonic.sleep()
Sonic.displayHealth()
Sonic.sleep()
Sonic.displayHealth()


var Simba = Lion(name: "Simba")
Simba.displayHealth()
Simba.growl()

print("")
print("")
print("ASSIGNMENT")

var Chester = Cheetah(name: "Chester")
for _ in 1...4{
    Chester.run()
}
Chester.displayHealth()

var Leo = Lion(name: "Leo")
for _ in 1...3{
    Leo.run()
}
Leo.growl()
