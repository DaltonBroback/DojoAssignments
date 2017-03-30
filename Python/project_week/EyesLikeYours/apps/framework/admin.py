from django.contrib import admin
from .models import Episode, Character, Announcement

try:
    admin.register(Episode, Character, Announcement)(admin.ModelAdmin)
except AlreadyRegistered:
    pass
