import shared


def linq28():
    words = ["cherry", "apple", "blueberry"]

    sorted_words = sorted(words)

    print("The sorted list of words:")
    shared.printS(sorted_words)


def linq29():
    words = ["cherry", "apple", "blueberry"]

    sorted_words = sorted(words, key=lambda x: len(x))

    print("The sorted list of words (by length):")
    shared.printS(sorted_words)


def linq30():
    products = shared.getProductList()

    sorted_products = sorted(products, key=lambda p:  p.ProductName)

    shared.print_namespace(sorted_products)


def linq31():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda s: s.casefold())

    shared.printS(sorted_words)


def linq32():
    doubles = [1.7, 2.3, 1.9, 4.1, 2.9]

    sorted_doubles = sorted(doubles, reverse=True)

    print("The doubles from highest to lowest:")
    shared.printN(sorted_doubles)


def linq33():
    products = shared.getProductList()

    sorted_products = sorted(products, key=lambda p: p.UnitsInStock, reverse=True)

    shared.print_namespace(sorted_products)


def linq34():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda s: s.casefold(), reverse=True)

    shared.print_namespace(sorted_words)


def linq35():
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    sorted_digits = sorted(digits, key=lambda digit: (len(digit), digit))

    print("Sorted digits:")
    shared.printS(sorted_digits)


def linq36():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda word: (len(word), word.casefold()))

    shared.printS(sorted_words)


def linq37():
    products = shared.getProductList()

    # negate secondary sort because its a number for reverse order
    sorted_products = sorted(products, key=lambda product: (product.Category, -product.UnitPrice))

    shared.print_namespace(sorted_products)


def linq38():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    # two pass sort, sort by least significant first
    sorted_words = sorted(words, key=lambda word: word.casefold(), reverse=True)
    sorted_words = sorted(sorted_words, key=lambda word: len(word))

    shared.printS(sorted_words)


def linq39():
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    reversed_i_digits = reversed(list(filter(lambda digit: digit[1] == "i", digits)))

    print("A backwards list of the digits with a second character of 'i':")
    shared.printS(reversed_i_digits)


linq28()
# linq29()
# linq30()
# linq31()
# linq32()
# linq33()
# linq34()
# linq35()
# linq36()
# linq37()
# linq38()
# linq39()
