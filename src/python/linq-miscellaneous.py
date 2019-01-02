import shared


def linq94():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    all_numbers = numbers_a + numbers_b

    print("All numbers from both arrays:")
    shared.printN(all_numbers)


def linq95():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    customer_names = map(lambda c: c.CompanyName, customers)
    product_names = map(lambda p: p.ProductName, products)

    all_names = list(customer_names) + list(product_names)

    print("Customer and product names:")
    shared.printS(all_names)


def linq96():
    words_a = ["cherry", "apple", "blueberry"]
    words_b = ["cherry", "apple", "blueberry"]

    match = words_a == words_b

    print("The sequences match: %s" % match)


def linq97():
    words_a = ["cherry", "apple", "blueberry"]
    words_b = ["apple", "blueberry", "cherry"]

    match = words_a == words_b

    print("The sequences match: %s" % match)


linq94()
# linq95()
# linq96()
# linq97()
