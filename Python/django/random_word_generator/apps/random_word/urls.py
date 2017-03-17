from django.conf.urls import url ufr

from . import views
urlpatterns = [
    url(r'^$', views.index),
    url(r'^generate_word$',views.generate_word)
]
