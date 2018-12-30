import shared
from types import SimpleNamespace


def linq6():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    numsPlusOne = map(lambda n: n + 1, numbers)

    print("Numbers + 1:")
    print(list(numsPlusOne))


def linq7():
    products = shared.getProductList()

    productNames = map(lambda p: p.ProductName, products)

    print("Product Names:")
    shared.printS(productNames)


def linq8():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    textNums = map(lambda n: strings[n], numbers)

    print("Number strings:")
    shared.printS(textNums)


def linq9():
    words = ["aPPLE", "BlUeBeRrY", "cHeRry"]

    upperLowerWords = map(lambda w: SimpleNamespace(Upper=w.upper(), Lower=w.lower()), words)
    for word in upperLowerWords:
        print("Uppercase: %s, Lowercase: %s" % (word.Upper, word.Lower))


def linq10():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    digitOddEvens = map(lambda n: SimpleNamespace(Digit=strings[n], Even=(n % 2 == 0)), numbers)

    for d in digitOddEvens:
        print("The digit %s is %s" % (d.Digit, 'even' if d.Even else 'odd'))


def linq11():
    products = shared.getProductList()

    productInfos = map(lambda p: SimpleNamespace(ProductName=p.ProductName, Category=p.Category, Price=p.UnitPrice),
                       products)

    print("Product Info:")
    for p in productInfos:
        print("%s is in the category %s and costs %.2f per unit." % (p.ProductName, p.Category, p.Price))


def linq12():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    index = 0

    def CheckInPlace(digit):
        nonlocal index
        result = digit == index
        index += 1
        return result

    numsInPlace = map(lambda num: SimpleNamespace(Num=num, InPlace=CheckInPlace(num)), numbers)

    print("Number: In-place?");
    for n in numsInPlace:
        print("%d: %s" % (n.Num, n.InPlace))


def linq13():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    result = map(lambda n: digits[n], filter(lambda n: n < 5, numbers))

    print("Numbers < 5:")
    shared.printS(result)


# linq6()
# linq7()
# linq8()
# linq9()
# linq10()
# linq11()
# linq12()
linq13()
