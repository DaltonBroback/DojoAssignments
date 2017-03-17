from flask import Flask, render_template,request,redirect,session,flash
from mysqlconnection import MySQLConnector
import re
import time

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app = Flask(__name__)
mysql = MySQLConnector(app, 'email_validation_assignment')
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/getemail', methods=['POST'])
def getemail():
    if not EMAIL_REGEX.match(request.form['email']):
        flash("<p id='red'>Invalid Email Address!</p>")
        return redirect('/')
    else:
        print request.form['email']
        currenttime = time.strftime("%Y/%m/%d %H:%M %p")
        print currenttime
        query = "INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
        data = {
            'email':request.form['email'],
        }
        mysql.query_db(query, data)
        session['email'] = request.form['email']
        return redirect('/success')

# @app.route('/remove_email/<email_id>', methods=['POST'])
# def remove(email_id):
#         query = "DELETE FROM emails WHERE id = :id"
#         data = {'id': email_id}
#         mysql.query_db(query,data)
#         return redirect('/success')

@app.route('/success')
def success():
    emails = mysql.query_db("SELECT * FROM emails")
    return render_template('success.html', all_emails=emails)

@app.route('/goback')
def goback():
    return redirect('/')
app.run(debug=True)
