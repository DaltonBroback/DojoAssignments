class Animal(object):
    def __init__(self, name, health=100):
        self.name = name
        self.health = health
        print ""
        print self.name
    def walk(self):
        print "Walking"
        self.health -= 1
        return self
    def run(self):
        print "Running"
        self.health -= 5
        return self
    def display_health(self):
        print str(self.name),"- Health:",str(self.health)
