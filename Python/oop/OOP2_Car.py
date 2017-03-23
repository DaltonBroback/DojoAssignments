class Car(object):
    def __init__(self, price, speed, mileage, fuel="Empty"):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12

    def display_all(self):
        print "Price: ",str(self.price)
        print "Speed: ",str(self.speed)
        print "Fuel: ",str(self.fuel)
        print "Mileage: ",str(self.fuel)
        print "Tax: ",str(self.tax)
        print ""

Car1 = Car(2000,"35mph","15mpg","Full")
Car2 = Car(2000,"5mph","105mpg","Not Full")
Car3 = Car(2000,"15mph","95mpg","Kind of Full")
Car4 = Car(2000,"25mph","25mpg","Full")
Car5 = Car(2000,"45mph","25mpg",)
Car6 = Car(20000000,"35mph","15mpg",)

print "Car 1:"
Car1.display_all()
print "Car 2:"
Car2.display_all()
print "Car 3:"
Car3.display_all()
print "Car 4:"
Car4.display_all()
print "Car 5:"
Car5.display_all()
print "Car 6:"
Car6.display_all()
