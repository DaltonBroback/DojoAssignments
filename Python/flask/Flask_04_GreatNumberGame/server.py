from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'


@app.route('/')
def index():
    try:
        print session['randomnum']
    except KeyError:
        session['randomnum'] = random.randrange(0, 101)
    return render_template('index.html')

@app.route('/game', methods=['POST'])
def game():
    session['number']=request.form['number']
    try:
        if (int(session['number']) == session['randomnum']):
            result = "<form action='/replay' class='result' id='win'><h2>"+str(session['randomnum'])+" was the number!</h2><button type='submit'>Play Again</button></form>"
        if (int(session['number']) < session['randomnum']):
            result = "<div class='result' id='lose'><h2>Too low!</h2></div>"
        if (int(session['number']) > session['randomnum']):
            result = "<div class='result' id='lose'><h2>Too high!</h2></div>"
    except ValueError:
        result = "<div class='result' id='lose'><h2>Please enter a valid number!</h2></div>"
    session['result'] = result
    return redirect('/')

@app.route('/replay')
def replay():
    session['randomnum'] = random.randrange(0, 101)
    session['result'] = ""
    return redirect('/')
app.run(debug=True)
