import shared
from itertools import groupby
from types import SimpleNamespace


def linq40():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    # First create a record of numbers and their modulus of 5
    number_remainders = map(lambda n: SimpleNamespace(Number=n,
                                                      Remainder=n % 5),
                            numbers)

    # Group By only works on sorted lists, so sort by both fields
    sorted_by_reminder = sorted(number_remainders, key=lambda x: (x.Remainder, x.Number))
    remainder_groups = groupby(sorted_by_reminder, key=lambda nr: nr.Remainder)

    for key, items in remainder_groups:
        print("Numbers with a remainder of %d when divided by 5:" % key)
        for item in items:
            print(item.Number)


def linq41():
    words = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"]

    first_letter_words = map(lambda w: SimpleNamespace(Letter=w[0],
                                                       Word=w),
                             words)

    # Group By only works on sorted lists, so sort by both fields
    sorted_letter_words = sorted(first_letter_words, key=lambda x: (x.Word, x.Letter))
    letter_groups = groupby(sorted_letter_words, key=lambda nr: nr.Letter)

    for key, items in letter_groups:
        print("Words that start with the letter '%s':" % key)
        for item in items:
            print(item.Word)


def linq42():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    order_groups = groupby(sorted_by_category, key=lambda p: p.Category)

    for key, items in order_groups:
        print("Products in the category '%s':" % key)
        print(list(items))


def linq43():
    pass


def linq44():
    pass


def linq45():
    pass


linq40()
# linq41()
# linq42()
# linq43()
# linq44()
