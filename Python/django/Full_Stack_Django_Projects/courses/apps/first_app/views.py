from django.shortcuts import render, redirect
from .models import Course
import time

# from . import team_maker


# Create your views here.
def index(request):
    context = {
	   "courses": Course.objects.all(),
    }
    return render(request, "first_app/index.html",context)

def remove(request):
    request.session['id'] = request.POST['id']
    context={"coursetodelete": Course.objects.filter(id = request.session['id'])}
    return render(request, "first_app/remove.html", context)

def confirmremove(request):
    Course.objects.filter(id=request.session['id']).delete()
    return redirect('/')


def addcourse(request):
    name = request.POST['name']
    description = request.POST['description']
    Course.objects.create(name=name,description=description)
    return redirect('/')
