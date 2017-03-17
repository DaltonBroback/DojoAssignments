from flask import Flask, render_template,request,redirect,session,flash
import re
import time
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
    session['result']="<p> No ninjas here.</p>"
    return render_template('index.html')
# @app.route('/ninja')
# def ninja(color):
#     print color
#     try:
#         session['color'] = session['color']
#         if session['color']=="blue":
#             session['result']="<img src='static/leonardo.jpg'>"
#             session['color']="none"
#         elif session['color']=="orange":
#             session['result']="<img src='static/michelangelo.jpg'>"
#             session['color']="none"
#         elif session['color']=="red":
#             session['result']="<img src='static/raphael.jpg'>"
#             session['color']="none"
#         elif session['color']=="purple":
#             session['result']="<img src='static/donatello.jpg'>"
#             session['color']="none"
#         elif session['color']=="none":
#             session['result']="<img src='static/tmnt.png'>"
#             session['color']="none"
#         else:
#             session['result']="<img src='static/notapril.jpg'>"
#     except KeyError:
#         session['result']="<img src='static/tmnt.png'>"
#     return render_template('ninja.html')
# @app.route('/ninja')
# def ninja():
#     try:
#         session['color'] = session['color']
#         if session['color']=="blue":
#             session['result']="<img src='static/leonardo.jpg'>"
#             session['color']="none"
#         elif session['color']=="orange":
#             session['result']="<img src='static/michelangelo.jpg'>"
#             session['color']="none"
#         elif session['color']=="red":
#             session['result']="<img src='static/raphael.jpg'>"
#             session['color']="none"
#         elif session['color']=="purple":
#             session['result']="<img src='static/donatello.jpg'>"
#             session['color']="none"
#         elif session['color']=="none":
#             session['result']="<img src='static/tmnt.png'>"
#             session['color']="none"
#         else:
#             session['result']="<img src='static/notapril.jpg'>"
#     except KeyError:
#         session['result']="<img src='static/tmnt.png'>"
#     return render_template('ninja.html')

# @app.route('/ninja/blue')
# def blue():
#     session['color']="blue"
#     return redirect('/ninja')
#
# @app.route('/ninja/orange')
# def orange():
#     session['color']="orange"
#     return redirect('/ninja')
#
# @app.route('/ninja/red')
# def red():
#     session['color']="red"
#     return redirect('/ninja')
#
# @app.route('/ninja/purple')
# def purple():
#     session['color']="purple"
#     return redirect('/ninja')
#
# @app.route('/ninja/')
# def yellow():
#     session['color']="yellow"
#     return redirect('/ninja')

@app.route('/ninja/<color>')
def colorfunction(color):
    print color
    # return render_template('ninja.html'), color=color)

app.run(debug=True)
