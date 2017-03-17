from flask import Flask, render_template,request, redirect, session
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    return render_template('index.html')
# @app.route('/submit', methods=['POST'])
@app.route('/submit', methods=['POST'])
def submit_form():
    print "form submitted"
    session['name']=request.form['name']
    session['location']=request.form['location']
    session['language']=request.form['language']
    session['comment']=request.form['comment']
    return redirect('/result')
@app.route('/result')
def result():
    return render_template('result.html')
# @app.route('/return')
# def returnnow():
#     return redirect('/')
app.run(debug=True)
