from django.conf.urls import url
from . import views
urlpatterns = [
    url(r'^$', views.index),
    url(r'^old$', views.old),
    url(r'^episodes$', views.episodes),
    url(r'^episodes/get/(?P<id>\d+)$', views.getepisode),
    url(r'^about$', views.about),
    url(r'^characters$', views.characters),
    url(r'^characters/(?P<name>[\w-]+)/$', views.getcharacter),
    url(r'^crew$', views.crew),
    url(r'^test$', views.test)
]
