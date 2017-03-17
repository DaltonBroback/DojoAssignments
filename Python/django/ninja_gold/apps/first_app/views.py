from django.shortcuts import render, redirect
import time
from random import randint
from django.utils import timezone

# Create your views here.
def index(request):
    return render(request, "first_app/index.html")
def process_money(request):
    result = ""
    try:
        request.session['result'] = request.session['result']
    except KeyError:
        request.session['result'] = ""
    try:
        request.session['gold'] = request.session['gold']
    except KeyError:
        request.session['gold'] = 0
    if request.POST['building'] == 'farm':
        winnings = randint(10,20)
        location = 'farm'
    if request.POST['building'] == 'cave':
        winnings = randint(5,10)
        location = 'cave'
    if request.POST['building'] == 'house':
        winnings = randint(2,5)
        location = 'house'
    if request.POST['building'] == 'casino':
        winnings = randint(-50,50)
        location = 'casino'
    request.session['gold'] += winnings
    if winnings < 0:
        winnings -= (2*winnings)
        result = "<h5 class = 'red'>Entered a casino and lost "+ str(winnings) +" gold... Ouch... ("+str(time.strftime ('%Y/%m/%d %I:%M %p'))+")</h5> \n"
    else:
        result = "<h5 class = 'green'>Earned "+ str(winnings) + " gold from the "+location+"! ("+str(time.strftime ('%Y/%m/%d %I:%M %p'))+") \n"
    # print result
    request.session['result'] = result + request.session['result']
    return redirect('/')
