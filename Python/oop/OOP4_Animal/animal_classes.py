from animal import Animal

cat = Animal("Cat")
cat.walk().walk().walk().run().run().display_health()

class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150
    def pet(self):
        print "Petting"
        self.health += 5
        return self


dog1 = Dog("Dog")
dog1.walk().walk().walk().run().run().pet().display_health()

class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170
    def fly(self):
        print "Flying"
        self.health -= 10
        return self
    def display_health(self):
        super(Dragon, self).display_health()
        print "This is a dragon!"
        return self

dragon1 = Dragon("Dragon")
dragon1.walk().walk().walk().run().run().fly().fly().display_health()
