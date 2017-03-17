x = [4, 6, 1, 3, 5, 7, 25]

def draw_stars(x):
    for element in x:
        stars = ""
        while element > 0:
            stars += "*"
            element -= 1
        print stars
# draw_stars(x)
y = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]

def draw_symbols(y):
    str_count = 0
    for element in y:
        if isinstance(element,str):
            str_count = len(element)
            symbols = ""
            while str_count > 0:
                element = element.lower()
                symbols += element[0][0]
                str_count -= 1
            print symbols
        else:
            symbols = ""
            while element > 0:
                symbols += "*"
                element -= 1
            print symbols
draw_symbols(y)
