from flask import Flask, render_template,request,redirect,session,flash
import re
import time

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX_CAPITAL= re.compile(r'^[A-Z]')
NAME_REGEX_NUMS= re.compile(r'^[0-9]')
PASSWORD_REGEX = re.compile(r'^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])')
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/register', methods=['POST'])
def register():
    errors = False
    if len(request.form['email'])<1:
        flash("Email address cannot be blank!")
        errors = True
    if len(request.form['first_name'])<1:
        flash("First name cannot be blank!")
        errors = True
    if not NAME_REGEX_CAPITAL.match(request.form['first_name']):
        flash("First name must begin with a capital letter!")
        errors = True
    if NAME_REGEX_NUMS.match(request.form['first_name']):
        flash("First name cannot include numbers!")
        errors = True
    if len(request.form['last_name'])<1:
        flash("Last name cannot be blank!")
        errors = True
    if not NAME_REGEX_CAPITAL.match(request.form['last_name']):
        flash("Last name must begin with a capital letter!")
        errors = True
    if NAME_REGEX_NUMS.match(request.form['last_name']):
        flash("Last name cannot include numbers!")
        errors = True
    if len(request.form['password'])<8:
        flash("Password must be at least 8 characters!")
        errors = True
    if not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
        errors = True
    if not PASSWORD_REGEX.match(request.form['password']):
        flash("Password must contain at least one capital letter and one number!")
        errors = True
    if request.form['password'] != request.form['confirm_password']:
        flash("Passwords must match!")
        errors = True
    if errors == False:
        session['email'] = request.form['email']
        session['first_name'] = request.form['first_name']
        session['last_name'] = request.form['last_name']
        return redirect ('/success')
    else:
        return redirect ('/')


@app.route('/success')
def success():
    return render_template('success.html')

@app.route('/returnnow')
def returnnow():
    return redirect('/')
app.run(debug=True)
