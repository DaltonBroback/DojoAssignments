from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    return render(request,"first_app/index.html")
def thefour(request):
    return render(request,"first_app/thefour.html")
def leonardo(request):
    return render(request,"first_app/leonardo.html")
def michelangelo(request):
    return render(request,"first_app/michelangelo.html")
def raphael(request):
    return render(request,"first_app/raphael.html")
def donatello(request):
    return render(request,"first_app/donatello.html")
def april(request):
    return render(request,"first_app/april.html")
