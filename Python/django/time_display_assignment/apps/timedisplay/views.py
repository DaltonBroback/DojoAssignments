from django.shortcuts import render, HttpResponse
import time
from django.utils import timezone
now = timezone.now

def index(request):
    currentTime=time.strftime('%I:%M %p', time.localtime())
    currentDate=time.strftime('%b %d, %Y', time.localtime())
    context = {"date":currentDate,
                "time":currentTime}
    return render(request,'timedisplay/page.html',context)
