from flask import Flask, render_template,request,redirect,session,flash
from mysqlconnection import MySQLConnector
import re
import time
import md5

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app = Flask(__name__)
mysql = MySQLConnector(app, 'mydb')
app.secret_key = 'ThisIsSecret'


password = 'password';
encrypted_password = md5.new(password).hexdigest();

@app.route('/')
def index():
    return render_template('login.html')

@app.route('/register')
def register():
    return render_template('register.html')

@app.route('/wall')
def wall():
    session['time'] = time.strftime( "%B %d, %Y %I:%M")
    query = "SELECT CONCAT(users.first_name, ' ', users.last_name) AS user, messages.id, messages.message, messages.created_at, messages.updated_at FROM messages JOIN users ON users.id = messages.users_id ORDER by messages.created_at DESC;"
    messages = mysql.query_db(query)
    comments = mysql.query_db("SELECT CONCAT(users.first_name, ' ', users.last_name) AS user, messages.id AS messages_id, comments.comment, comments.created_at, comments.updated_at FROM comments JOIN users ON users.id = comments.users_id JOIN messages ON messages.id = comments.messages_id ORDER by comments.created_at;")
    for message in messages:
        try:
            session['allmessages'] = session['allmessages']
            i = i
        except KeyError:
            session['allmessages'] = ""
            i = 0
        except UnboundLocalError:
            session['allmessages'] = ""
            i = 0
        allcomments = ""
        for comment in comments:
            try:
                allcomments = allcomments
                j = j
            except KeyError:
                allcomments = ""
                j = 0
            except UnboundLocalError:
                allcomments = ""
                j = 0
            if comments[j]['messages_id'] == messages[i]['id']:
                commenttime = comments[j]['created_at'].strftime("%B %d, %Y %H:%M")
                allcomments += "<b>"+comments[j]['user']+" - "+commenttime +"</b><p>"+comments[j]['comment']+"</p>"
            j+=1
        j = 0
        posttime = messages[i]['created_at'].strftime( "%B %d, %Y %H:%M")
        session['allmessages'] +="<b>"+messages[i]['user']+" - "+posttime+"</b><p>"+messages[i]['message']+"</p><div class = 'comment'>"+allcomments+"<form action='/comment' method ='post'><input type='hidden' name='messageID' value='"+str(messages[i]['id'])+"'<h3>Post a Comment</h3><textarea  class='commenttext' name='commenttext'></textarea><button type='submit'/>Post a Comment</button></form></div>"
        i+=1
    return render_template('index.html')

@app.route('/createaccount', methods=['POST'])
def createaccount():
    password = md5.new(request.form['password']).hexdigest()
    query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, NOW(), NOW())"
    data = {
        'first_name':request.form['first_name'],
        'last_name':request.form['last_name'],
        'email':request.form['email'],
        'password':password,
    }
    mysql.query_db(query, data)
    return redirect('/')
@app.route('/login', methods=['POST'])
def login():
    email = request.form['email']
    password = md5.new(request.form['password']).hexdigest()
    user_query = "SELECT * FROM users WHERE users.email=:email LIMIT 1"
    query_data = {
        'email':email,
    }
    user = mysql.query_db(user_query, query_data)
    try:
        user[0]['password']=user[0]['password']
    except IndexError:
        flash("<p id='red'>Invalid Email Address!</p>")
        return redirect('/')
    if user[0]['password']==password:
        session['user']=user[0]
        return redirect('/wall')
    else:
        flash("<p id='red'>Invalid Password!</p>")
    return redirect('/')
@app.route('/logoff')
def logoff():
    session['user']=0
    return redirect('/')
@app.route('/message', methods=['POST'])
def message():
    user_id = session['user']['id']
    query = "INSERT INTO messages (users_id, message, created_at, updated_at) VALUES (:users_id, :message, NOW(),NOW())"
    data = {
        'users_id': user_id,
        'message': request.form['messagetext']
    }
    mysql.query_db(query, data)
    return redirect('/wall')
@app.route('/comment', methods=['POST'])
def comment():
    query = "INSERT INTO comments (users_id, messages_id, comment, created_at, updated_at) VALUES (:users_id,:messages_id, :comment, NOW(),NOW())"
    data = {
        'users_id': session['user']['id'],
        'messages_id': request.form['messageID'],
        'comment': request.form['commenttext']
    }
    mysql.query_db(query, data)
    return redirect('/wall')

app.run(debug=True)
