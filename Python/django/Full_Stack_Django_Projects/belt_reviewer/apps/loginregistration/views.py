from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User
import bcrypt
import re

EMAIL_REGEX = r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$'
NAME_REGEX = r'^[0-9.+_-]'


def index(request):
    # User.objects.all().delete()
    request.session['email'] = ""
    request.session['username'] = ""
    return render(request,'loginregistration/index.html')
def success(request):
    context = {
        "users": User.objects.get(email = request.session['email'])
    }
    return render(request,'loginregistration/success.html',context)
def register(request):
    request.session['username'] = ""
    first_name = request.GET['first_name']
    last_name = request.GET['last_name']
    email = request.GET['email']
    password =  request.GET['password']
    pwconfirm = request.GET['pwconfirm']
    errors = 0
    try:
        User.objects.get(email = email)
        messages.add_message(request, messages.INFO, "email already in use!")
        return redirect('/')
    except:
        if len(first_name) < 2:
            errors += 1
            messages.add_message(request, messages.INFO, "first name too short!")
        if re.match(NAME_REGEX, first_name):
            errors += 1
            messages.add_message(request, messages.INFO, "first name must only contain letters!")
        if re.match(NAME_REGEX, last_name):
            errors += 1
            messages.add_message(request, messages.INFO, "last name must only contain letters!")
        if len(last_name) < 2:
            errors += 1
            messages.add_message(request, messages.INFO, "last name too short!")
        if not re.match(EMAIL_REGEX,email):
            errors += 1
            messages.add_message(request, messages.INFO, "invalid email!")
        if len(password) < 8:
            errors += 1
            messages.add_message(request, messages.INFO, "password too short!")
        if not password == pwconfirm:
            errors += 1
            messages.add_message(request, messages.INFO, "passwords must match!")
        if errors == 0:
            hashed = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
            User.objects.create(first_name=first_name,last_name=last_name,email=email,password=hashed)
            print User.objects.all()
            request.session['username'] = first_name
            return redirect('/success')
        else:
            return redirect('/')

def login(request):
    email = request.GET['email']
    password =  request.GET['password']
    try:
        user = User.objects.get(email = email)
    except UnboundLocalError:
        messages.add_message(request, messages.INFO, "email does not match any account!")
        return redirect('/')
    except:
        messages.add_message(request, messages.INFO, "email does not match any account!")
        return redirect('/')
    if bcrypt.hashpw(password.encode(), user.password.encode()) == user.password:
        request.session['email'] = email
        request.session['username'] = user.first_name
        return redirect('/success')
    else:
        messages.add_message(request, messages.INFO, "incorrect password!")
    return redirect('/')
