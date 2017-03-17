from flask import Flask, render_template,request, redirect, session
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    try:
        session['count'] += 1
    except KeyError:
        session['count'] = 1
    return render_template('index.html')

@app.route('/plustwo', methods=['GET'])
def plustwo():
    print "plustwo"
    session['count'] += 1
    return redirect('/')

@app.route('/reset', methods=['GET'])
def reset():
    print "reset"
    session['count'] = 0
    return redirect('/')

app.run(debug=True)
