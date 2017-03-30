from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'my_booksindex'),
    url(r'logout$', views.logout, name = 'my_logout'),
    url(r'add$', views.add, name = 'my_add'),
]
