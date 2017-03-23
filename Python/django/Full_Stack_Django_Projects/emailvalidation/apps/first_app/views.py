from django.shortcuts import render

# EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# app = Flask(__name__)
# mysql = MySQLConnector(app, 'email_validation_assignment')
# app.secret_key = 'ThisIsSecret'
#

def index(request):
    return render(request, "first_app/index.html")

# def getemail(request):
#     if not EMAIL_REGEX.match(request.form['email']):
#         flash("<p id='red'>Invalid Email Address!</p>")
#         return redirect('/')
#     else:
#         print request.form['email']
#         currenttime = time.strftime("%Y/%m/%d %H:%M %p")
#         print currenttime
#         query = "INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
#         data = {
#             'email':request.form['email'],
#         }
#         mysql.query_db(query, data)
#         session['email'] = request.form['email']
#         return redirect('/success')
