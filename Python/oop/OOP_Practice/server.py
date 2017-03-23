import random
class Human(object):
  def __init__(self, clan=None):
    print 'New Human!!!'
    self.health = 100
    self.clan = clan
    self.strength = 3
    self.intelligence = 3
    self.stealth = 3
  def taunt(self):
    print "You want a piece of me?"
  def attack(self):
    self.taunt()
    luck = round(random.random() * 100)
    if(luck > 50):
      if((luck * self.stealth) > 150):
        print 'attacking!'
        return True
      else:
        print 'attack failed'
        return False
    else:
      self.health -= self.strength
      print "attack failed"
      return False

class Point(object):
    def __init__(self,x = 0,y = 0):
        print "Created a new point!"
        self.x = x
        self.y = y
    def distance(self):
        #Find distance from origin
        return (self.x**2 + self.y**2) ** 0.5

def my_function(self):
    print "This is a message inside the class."


class Cat(object):
  def __init__(self, color, type, age):
    self.color = color
    self.type = type
    self.age = age

garfield = Cat('orange', 'fat', 5)
print "Garfield's color:", garfield.color
print "Garfield's type:", garfield.type
print "Garfield's age:", garfield.age

class Test(object):
  def __init__(self, phrase='Nothing was passed'):     # set the default value for 'phrase' parameter
    print "This string was passed in: " + phrase
    self.phrase = phrase

    test1 = Test('Hello, World!')
test2 = Test()
print "Test 1 has phrase: '" + test1.phrase + "'"
print "Test 2 has phrase, '" + test2.phrase + "'"
