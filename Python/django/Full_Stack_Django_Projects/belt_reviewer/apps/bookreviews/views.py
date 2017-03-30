from django.shortcuts import render, redirect
from django.core.urlresolvers import reverse

def index(request):
    return render(request,'bookreviews/index.html')
def add(request):
    return redirect('/')
def logout(request):
    return redirect('users:my_index')
