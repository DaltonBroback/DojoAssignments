for count in range (0,1001):
    if (count % 2 == 1): #odd
        print count

for count in range (0,1000001):
    if (count % 5 == 0): #multiple of 5
        print count

a = [1, 2, 5, 10, 255, 3]


def gettotal(a):
    x = 0
    for element in a:
        x += element
    print "Total: "
    print x
gettotal(a)
def getaverage(a):
    loops = 0
    avg = 0
    x=0
    for element in a:
        x += element
    loops = (len(a))
    avg = x/loops
    print "Average: "
    print avg
getaverage(a)
