from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'


@app.route('/')
def index():
    try:
        session['gold'] = session['gold']
    except KeyError:
        session['gold'] = 0
    return render_template('index.html')

@app.route('/process_money', methods=['POST'])
def process_money():
    import time
    currenttime = time.strftime("%Y/%m/%d %H:%M %p")
    try:
        session['result'] = session['result']
    except KeyError:
        session['result'] = ""
    if request.form['building'] == 'farm':
        winnings = random.randrange(10, 20)
        location = "farm"
    if request.form['building'] == 'cave':
        winnings = random.randrange(5, 10)
        location = "cave"
    if request.form['building'] == 'house':
        winnings = random.randrange(2, 5)
        location = "house"
    if request.form['building'] == 'casino':
        winnings = random.randrange(-50, 50)
        location = "casino"
    session['gold'] += winnings
    if winnings > 0:
        result = "<h5 class='green'>Earned "+str(winnings)+" gold from the "+location+" ("+str(currenttime)+")</h5>"
    else:
        winnings *= -1
        result = "<h5 class='red'>Entered a casino and lost "+str(winnings)+" gold... Ouch... ("+str(currenttime)+")</h5>"
    session['result'] = result + session['result']
    return redirect('/')

app.run(debug=True)
