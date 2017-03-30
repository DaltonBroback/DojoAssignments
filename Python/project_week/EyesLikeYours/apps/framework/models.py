from __future__ import unicode_literals
from django.conf import settings
from django.db import models

class Episode(models.Model):
    id = models.IntegerField(primary_key=True)
    title = models.CharField(max_length=255)
    description = models.TextField()
    link = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    readonlyfields=('id')
    def __str__(self):
        return 'Episode: {}'.format(self.title)

class Character(models.Model):
    id = models.AutoField(primary_key=True)
    identifier = models.CharField(max_length=255)
    name = models.CharField(max_length=255)
    age = models.CharField(max_length=255)
    occupation = models.CharField(max_length=255)
    bio = models.TextField()
    image = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    def __str__(self):
        return 'Character: {}'.format(self.identifier)

class Announcement(models.Model):
    id = models.AutoField(primary_key=True)
    author = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,
        )
    title = models.CharField(max_length=255)
    text = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    def __str__(self):
        return 'Announcement: {}'.format(self.title)
    # def __unicode__(self):
    #     return self.user

class Content(models.Model):
    id = models.AutoField(primary_key=True)
    title = models.CharField(max_length=255)
    text = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    def __str__(self):
        return 'Contents: {}'.format(self.title)
