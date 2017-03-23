from __future__ import unicode_literals

from django.db import models

class UserManager(models.Manager):
	def login(self, postData):
		print "Login Successful"
		pass
	def register(self, postData):
		print "Registration Succesful"
		pass

class User(models.Model):
	first_name = models.CharField(max_length=255)
	last_name = models.CharField(max_length=255)
	email = models.CharField(max_length=255)
	password = models.CharField(max_length=255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = UserManager()
