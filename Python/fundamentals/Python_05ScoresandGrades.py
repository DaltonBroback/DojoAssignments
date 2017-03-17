import random
def postgrade():
    random_num = 60 + random.random() * 40
    grade = "F"
    if int(random_num) > 89:
        grade = "A"
    elif int(random_num) > 79:
        grade = "B"
    elif int(random_num) > 69:
        grade = "C"
    elif int(random_num) > 59:
        grade = "D"
    print "Score: "+str(int(random_num))+"; Your grade is", grade

print "Scores and Grades"
for count in range (0, 10):
    postgrade()
print "End of the program. Bye!"
