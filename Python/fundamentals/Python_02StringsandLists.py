str_banana = "if monkeys like bananas, then I must be a monkey!"
print str_banana.replace ("monkey","aligator")

x=[2,54,-2,7,12,98]
print max(x)
print min(x)

y=["hello",2,54,-2,7,12,98,"world"]
print y[0]
print y[len(y)-1]

z = [y[0],y[len(y)-1]]
print z

q = [19,2,54,-2,7,12,98,32,10,-3,6]
q.sort()
p = []
n = 0
while True:
    p.append(q[n])
    q.pop(n)
    n+1
    if q[n]>=0:
        break
q.insert(0,p)
print q
