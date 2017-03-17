import random

def coinflip():
    result = ""
    wins = 0
    losses = 0
    attempts = 0
    for count in range (0,5000):
        random_num = random.random()
        attempts += 1
        if random_num < 0.5:
            result = "tail"
            losses += 1
        else:
            result = "head"
            wins += 1
        print "Attempt #"+str(attempts)+": Throwing a coin... it's a "+result+"! ... Got", wins, "head(s) so far and", losses, "tail(s) so far"

print "Starting the program..."
coinflip()
print "Ending the program. Thank you!"
