import random
class Bike(object):
    def __init__(self, price, max_speed,miles=0):
        self.price = price
        self.max_speed = max_speed
        self.miles = miles
    def displayinfo(self):
        print "**********"
        print "Price:", self.price
        print "Max Speed:", self.max_speed
        print "Miles:", abs(self.miles)
        print "**********"
    def ride(self):
        print "Riding"
        self.miles += 10
    def reverse(self):
        print "Reversing"
        self.miles -= 5


bicycle = Bike(80, "9 mph")
moped = Bike(200, "30 mph")
motorcycle = Bike(500, "300 mph")

print "1 - Bicycle"
bicycle.ride()
bicycle.ride()
bicycle.ride()
bicycle.reverse()
bicycle.reverse()
bicycle.displayinfo()

print "2 - Moped"
moped.ride()
moped.ride()
moped.reverse()
moped.reverse()
moped.displayinfo()

print "3 - Motorcycle"
motorcycle.reverse()
motorcycle.reverse()
motorcycle.reverse()
motorcycle.displayinfo()
