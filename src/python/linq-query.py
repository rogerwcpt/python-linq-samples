import shared


def linq99():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    i = 0

    def add_to_i(n):
        nonlocal i
        i = i + 1
        return n

    q = map(lambda n: add_to_i(n), numbers)

    for v in q:
        print("v = %d, i = %d" % (v, i))


def linq100():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    i = 0

    def add_to_i(n):
        nonlocal i
        i = i + 1
        return n

    q = list(map(lambda n: add_to_i(n), numbers))

    for v in q:
        print("v = %d, i = %d" % (v, i))


def linq101():
    pass


# linq99()
# linq100()
linq101()