import shared
from types import SimpleNamespace


def select(item, the_list):
    return map(lambda b: SimpleNamespace(item_a=item, item_b=b), the_list)


def left_outer_join(outer_list, inner_list):

    result = []
    for outer_item in outer_list:
        result.extend(select(outer_item, inner_list))
    return result


def select_many(outer_list, inner_item_list_key):
    result = []
    for outer_item in outer_list:
        result.extend(select(outer_item, getattr(outer_item, inner_item_list_key)))
    return result


def linq6():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    nums_plus_one = map(lambda n: n + 1, numbers)

    print("Numbers + 1:")
    print(list(nums_plus_one))


def linq7():
    products = shared.getProductList()

    product_names = map(lambda p: p.ProductName, products)

    print("Product Names:")
    shared.printS(product_names)


def linq8():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    text_nums = map(lambda n: strings[n], numbers)

    print("Number strings:")
    shared.printS(text_nums)


def linq9():
    words = ["aPPLE", "BlUeBeRrY", "cHeRry"]

    upper_lower_words = map(lambda w: SimpleNamespace(Upper=w.upper(), Lower=w.lower()), words)
    for word in upper_lower_words:
        print("Uppercase: %s, Lowercase: %s" % (word.Upper, word.Lower))


def linq10():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    digit_odd_evens = map(lambda n: SimpleNamespace(Digit=strings[n], Even=(n % 2 == 0)), numbers)

    for d in digit_odd_evens:
        print("The digit %s is %s" % (d.Digit, 'even' if d.Even else 'odd'))


def linq11():
    products = shared.getProductList()

    product_info = map(lambda p: SimpleNamespace(ProductName=p.ProductName, Category=p.Category, Price=p.UnitPrice),
                       products)

    print("Product Info:")
    for product in product_info:
        print("%s is in the category %s and costs %.2f per unit." % (product.ProductName, product.Category, product.Price))


def linq12():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    index = 0

    def digit_equals_index(digit):
        nonlocal index
        result = digit == index
        index += 1
        return result

    nums_in_place = map(lambda num: SimpleNamespace(Num=num, InPlace=digit_equals_index(num)), numbers)

    print("Number: In-place?");
    for n in nums_in_place:
        print("%d: %s" % (n.Num, n.InPlace))


def linq13():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    result = map(lambda n: digits[n], filter(lambda n: n < 5, numbers))

    print("Numbers < 5:")
    shared.printS(result)


def linq14():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    pairs = filter(lambda pair: pair.item_a < pair.item_b, left_outer_join(numbers_a, numbers_b))

    print("Pairs where a < b:")
    for p in pairs:
        print("%d is less than %d}" % (p.item_a, p.item_b))


def linq15():
    customers = shared.getCustomerList()

    orders = map(lambda x: SimpleNamespace(customer_id=x.item_a.CustomerID, order_id=x.item_b.OrderID, total=x.item_b.Total),
                 filter(lambda x: x.item_b.Total < 500.00,
                        select_many(customers, "Orders")))

    shared.print_namespace(orders)


# linq6()
# linq7()
# linq8()
# linq9()
# linq10()
# linq11()
# linq12()
# linq13()
#linq14()
# linq15()
