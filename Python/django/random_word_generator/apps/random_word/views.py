from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string
# Create your views here.

def index(request):
    return render(request,'random_word/index.html')

def generate_word(request):
    try:
        request.session['attempt'] += 1
    except KeyError:
        request.session['attempt'] = 0
    string = get_random_string(14)
    request.session['thestring']=string
    return redirect('/')
