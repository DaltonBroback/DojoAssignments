students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

def printnames(students):
    i = 0
    while i < len(students):
        names = ""
        names += students[i]['first_name'] + " " + students[i]['last_name']
        print names
        i += 1

printnames(students)

def printinfo(users):
    x = 0
    i = 0
    r = users.keys()
    while x < len(users):
        print r[x]
        while i < len(users[r[x]]):
            names = ""
            names += str(i+1)+" - "+ users[r[x]][i]['first_name'] + " " + users[r[x]][i]['last_name'] + " - "
            names += str((len(users[r[x]][i]['first_name']))+(len(users[r[x]][i]['last_name'])))
            print names
            i += 1
        i = 0
        x += 1
    x = 0
printinfo(users)
