def linq67():
    words = ["believe", "relief", "receipt", "field"]

    i_after_e = any("ei" in w for w in words)

    print("There is a word that contains in the list that contains 'ei': %s" % i_after_e)


def linq69():
    pass


def linq70():
    numbers = [1, 11, 3, 19, 41, 65, 19]

    only_odd = all(n % 2 == 1 for n in numbers)

    print("The list contains only odd numbers: %s" % only_odd)


def linq72():
    pass


linq67()
# linq69()
# linq70()
# linq72()
