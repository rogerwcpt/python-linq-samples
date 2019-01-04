import shared
import functions
import datetime

from types import SimpleNamespace


def linq6():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    nums_plus_one = (n+1 for n in numbers)

    print("Numbers + 1:")
    shared.printN(nums_plus_one)


def linq7():
    products = shared.getProductList()

    product_names = (p.ProductName for p in products)

    print("Product Names:")
    shared.printS(product_names)


def linq8():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    text_nums = (strings[n] for n in numbers)

    print("Number strings:")
    shared.printS(text_nums)


def linq9():
    words = ["aPPLE", "BlUeBeRrY", "cHeRry"]

    upper_lower_words = (SimpleNamespace(Upper=w.upper(),
                                         Lower=w.lower())
                         for w in words)

    for word in upper_lower_words:
        print("Uppercase: %s, Lowercase: %s" % (word.Upper, word.Lower))


def linq10():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    digit_odd_evens = (SimpleNamespace(Digit=strings[n],
                                       Even=(n % 2 == 0))
                       for n in numbers)

    for d in digit_odd_evens:
        print("The digit %s is %s" % (d.Digit, 'even' if d.Even else 'odd'))


def linq11():
    products = shared.getProductList()

    product_info = (SimpleNamespace(ProductName=p.ProductName,
                                    Category=p.Category,
                                    Price=p.UnitPrice)
                    for p in products)

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

    nums_in_place = (SimpleNamespace(Num=num,
                                     InPlace=digit_equals_index(num))
                     for num in numbers)

    print("Number: In-place?")
    for n in nums_in_place:
        print("%d: %s" % (n.Num, n.InPlace))


def linq13():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    result = (digits[n] for n in numbers if n < 5)

    print("Numbers < 5:")
    shared.printS(result)


def linq14():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    pairs = ((a, b) for a in numbers_a for b in numbers_b if (a < b))

    print("Pairs where a < b:")
    for p in pairs:
        print("%d is less than %d" % (p[0], p[1]))


def linq15():
    customers = shared.getCustomerList()

    orders_less_than_500 = ((customer, order)
                            for customer in customers
                            for order in customer.Orders
                            if order.Total < 500.00)
    orders = (SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              total=x[1].Total)
              for x in orders_less_than_500)

    shared.print_namespace(orders)


def linq16():
    customers = shared.getCustomerList()

    the_date = datetime.datetime(1998, 1, 1)

    order_greater_than_date = ((customer, order)
                            for customer in customers
                            for order in customer.Orders
                            if order.OrderDate > the_date)
    orders = (SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              orderDate=x[1].OrderDate)
              for x in order_greater_than_date)

    shared.print_namespace(orders)


def linq17():
    customers = shared.getCustomerList()

    orders_greater_than_2000 = ((customer, order)
                                for customer in customers
                                for order in customer.Orders
                                if order.Total > 2000.00)
    orders = (SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              total=x[1].Total)
              for x in orders_greater_than_2000)

    shared.print_namespace(orders)


def linq18():
    customers = shared.getCustomerList()

    the_date = datetime.datetime(1998, 1, 1)

    order_greater_than_date = ((customer, order)
                               for customer in customers
                               for order in customer.Orders
                               if order.OrderDate > the_date)
    orders = (SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              orderDate=x[1].OrderDate)
              for x in order_greater_than_date)

    shared.print_namespace(orders)


def linq19():
    customers = shared.getCustomerList()

    index = 0

    def get_cust_index_func():
        nonlocal index
        index += 1
        return index

    customer_orders = ((cust, get_cust_index_func(), order) for cust in customers for order in cust.Orders)

    for triplet in customer_orders:
        print("Customer #%d has an order with OrderID %d" % (triplet[1], triplet[2].OrderID))



# linq6()
# linq7()
# linq8()
# linq9()
# linq10()
# linq11()
# linq12()
# linq13()
# linq14()
# linq15()
# linq16()
# linq17()
# linq18()
linq19()