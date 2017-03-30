from django.shortcuts import render, redirect
from django.contrib import messages
from django.template import context
from .models import Episode, Character, Announcement, Content

def index(request):
    context = {
        "theannouncement":Announcement.objects.order_by('updated_at').reverse()[:1]
    }
    return render(request, 'framework/index.html',context)
def old(request):
    context = {
        "announcements":Announcement.objects.order_by('updated_at').reverse()
    }
    return render(request, 'framework/old.html',context)
def about(request):
    context = {
        "about":Content.objects.get(title = "about")
    }
    return render(request, 'framework/about.html',context)
def episodes(request):
    # request.session['link'] = ""
    # request.session['title'] = ""
    # request.session['description'] = ""
    # try:
    #     context = request.session['context']
    # except KeyError:
    #     context = {}
    return render(request, 'framework/episodes.html')
def getepisode(request, id):
    # context = {
    #     "episode":Episode.objects.get(id=id)
    # }
    # request.session['context'] = context
    request.session['id'] = id
    request.session['link'] = Episode.objects.get(id = id).link
    request.session['info'] = "<div class='textbox thin twothirty'><h2>"+Episode.objects.get(id = id).title+"</h2><p>"+Episode.objects.get(id = id).description+"</p></div>"
    return redirect('/episodes')
def characters(request):
    return render(request, 'framework/characters.html')
def getcharacter(request, name):
    context = {
        "character":Character.objects.get(identifier = name)
    }
    return render(request, 'framework/getcharacter.html', context)
    # return redirect('/characters')
def crew(request):
    context = {
        "cast":Content.objects.get(title = "cast")
    }
    return render(request, 'framework/crew.html',context)
def test(request):
    context = {
        "episodes":Episode.objects.all(),
        "characters":Character.objects.all()
    }
    return render(request, 'framework/test.html', context)
