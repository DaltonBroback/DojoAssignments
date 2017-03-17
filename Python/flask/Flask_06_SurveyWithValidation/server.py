from flask import Flask, render_template,request, redirect, session, flash
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    return render_template('index.html')
# @app.route('/submit', methods=['POST'])
@app.route('/submit', methods=['POST'])
def submit_form():
    if len(request.form['name']) < 1:
        flash("Name cannot be empty!")
        return redirect('/')
    else:
        session['name']=request.form['name']
    session['location']=request.form['location']
    session['language']=request.form['language']
    if len(request.form['comment']) < 1:
        flash("Comment cannot be left blank!")
        return redirect('/')
    elif len(request.form['comment']) > 120:
        flash("Comment cannot be longer than 120 characters!")
        return redirect('/')
    else:
        session['comment']=request.form['comment']
    return redirect('/result')
@app.route('/result')
def result():
    return render_template('result.html')
# @app.route('/return')
# def returnnow():
#     return redirect('/')
app.run(debug=True)
