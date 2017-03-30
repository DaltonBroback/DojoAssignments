from django.contrib import admin
from .models import Episode, Character, Announcement, Content

try:
    admin.register(Episode, Character, Announcement, Content)(admin.ModelAdmin)
except AlreadyRegistered:
    pass
