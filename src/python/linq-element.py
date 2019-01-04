import shared


def linq58():
    products = shared.getProductList()

    product_12 = next(p for p in products if p.ProductID == 12)

    print(product_12)


def linq59():
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    starts_with_o = next(s for s in strings if s[0] == 'o')

    print("A string starting with 'o': %s" % starts_with_o)


def linq61():
    numbers = []

    first_num_or_default = next((n for n in numbers), 0)

    print(first_num_or_default)


def linq62():
    products = shared.getProductList()

    product789 = next((p for p in products if p.ProductID == 789), None)

    print("Product 789 exists: %s" % (product789 is not None))


def linq64():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    second_number_greater_than_5 = [n for n in numbers if n > 5][1]

    print("Second number > 5: %d" % second_number_greater_than_5)


linq58()
# linq59()
# linq61()
# linq62()
# linq64()
