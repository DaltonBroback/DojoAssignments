def odd_even():
    for count in range (1,2001):
        oe = ""
        if count % 2 == 0:
            oe = "even"
        else:
            oe = "odd"
        print "Number is",str(count)+". This is an",oe,"number."

odd_even()
a = [2,4,10,16]
def multipy(a,x):
    b = []
    for element in a:
        b.append(element*x)
    print b
multipy(a,5)

def layered_multiples(arr,m):
    c = []
    new_array = []
    for element in arr:
        c.append(element*m)
    for element in c:
        d = []
        while (element > 0):
            d.append(1)
            element -= 1
        new_array.append(d)
    return new_array
x = layered_multiples([2,4,5],3)
print x
