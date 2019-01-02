import shared


def linq46():
    factors_of300 = [2, 2, 3, 5, 5]

    unique_factors = set(factors_of300)

    shared.printN(unique_factors)


def linq47():
    products = shared.getProductList()

    category_names = set(map(lambda p: p.Category, products))

    print("Category names:")
    shared.printS(category_names)


def linq48():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    unique_numbers = set(numbers_a + numbers_b)

    print("Unique numbers from both arrays:")
    shared.printN(unique_numbers)


def linq49():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).union(set(customer_first_chars))

    print("Unique first letters from Product names and Customer names:")
    shared.printS(unique_first_chars)


def linq50():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    common_numbers = set(numbers_a).intersection((set(numbers_b)))

    print("Common numbers shared by both arrays:")
    shared.printN(common_numbers)


def linq51():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).intersection(set(customer_first_chars))

    print("Common first letters from Product names and Customer names:")
    shared.printS(unique_first_chars)


def linq52():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    a_only_numbers = set(numbers_a).difference((set(numbers_b)))

    print("Numbers in first array but not second array:")
    shared.printN(a_only_numbers)


def linq53():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).difference(set(customer_first_chars))

    print("First letters from Product names, but not from Customer names:")
    shared.printS(unique_first_chars)


linq46()
# linq47()
# linq48()
# linq49()
# linq50()
# linq51()
# linq52()
# linq53()
