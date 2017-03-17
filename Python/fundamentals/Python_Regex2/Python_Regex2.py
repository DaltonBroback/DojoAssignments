import re
file = open("pandp.txt","r+")
text = file.read()

regex = re.compile(r"wife")
print re.findall(regex,text)

print re.sub(regex,r"unicorn",text)

term = re.compile(r"\w*t\w*")
print re.findall(term,text)
str = re.compile(r'\s+')
print re.split(str,text)

term = re.compile(r'[.?\-",!\']+')
re.findall(term,text)
term = re.compile(r'[.?\-",!\']+\s*')
print "this is the split", re.split(term,text)

pattern = re.compile(ur'\s+')
replaced = re.sub(pattern,ur'',text)

file.seek(0)
file.truncate()

file.write(replaced)
