from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^ninjas$', views.thefour),
    url(r'blue$', views.leonardo),
    url(r'orange$', views.michelangelo),
    url(r'red$', views.raphael),
    url(r'purple$', views.donatello),
    url(r'^ninjas/', views.april),
]
