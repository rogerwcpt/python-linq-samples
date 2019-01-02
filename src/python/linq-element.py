import shared


def linq58():
    products = shared.getProductList()

    product_12 = next(filter(lambda p: p.ProductID == 12, products))

    print(product_12)


def linq59():
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    starts_with_o = next(filter(lambda s: s[0] == 'o', strings))

    print("A string starting with 'o': %s" % starts_with_o)


def linq61():
    numbers = []

    first_num_or_default = next(filter(lambda x: True, numbers), 0)

    print(first_num_or_default)


def linq62():
    products = shared.getProductList()

    product789 = next(filter(lambda p: p.ProductID == 789, products), None)

    print("Product 789 exists: %s" % (product789 is not None))


def linq64():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    fourth_low_num = list(filter(lambda n: n > 5, numbers))[1]

    print("Second number > 5: %d" % fourth_low_num)


linq58()
# linq59()
# linq61()
# linq62()
# linq64()
