from django.shortcuts import render, redirect

# Create your views here.

def index(request):
    return render(request,'survey/index.html')

def process(request):
    print '*'*300
    request.session['name'] = request.POST['name']
    request.session['location'] = request.POST['location']
    request.session['lang'] = request.POST['lang']
    request.session['comment'] = request.POST['comment']
    try:
        request.session['submission'] += 1
    except KeyError:
        request.session['submission'] = 1
    return redirect('/result')


def results(request):
    return render(request,'survey/result.html')
