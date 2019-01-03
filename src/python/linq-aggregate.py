import shared
from types import SimpleNamespace
from itertools import groupby
from functools import reduce
import operator


def linq73():
    factors_of_300 = [2, 2, 3, 5, 5]

    unique_factors = len(set(factors_of_300))

    print("There are %d unique factors of 300." % unique_factors)


def linq74():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    odd_numbers = sum(n % 2 == 1 for n in numbers)

    print("There are %d odd numbers in the list." % odd_numbers)


def linq76():
    customers = shared.getCustomerList()

    order_counts = map(lambda cust: SimpleNamespace(CustomerID=cust.CustomerID,
                                                    OrderCount=len(cust.Orders)),
                       customers)

    shared.print_namespace(order_counts)


def linq77():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_counts = map(lambda g: SimpleNamespace(Category=g[0],
                                                    ProductCount=len(list(g[1]))),
                          grouped_by_category)

    shared.print_namespace(category_counts)


def linq78():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    num_sum = sum(numbers)

    print("The sum of the numbers is %d." % num_sum)


def linq79():
    words = ["cherry", "apple", "blueberry"]

    total_chars = sum(len(w) for w in words)

    print("There are a total of %d characters in these words." % total_chars)


def linq80():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_counts = map(lambda g: SimpleNamespace(Category=g[0],
                                                    TotalUnitsInStock=sum(p.UnitsInStock for p in g[1])),
                          grouped_by_category)

    shared.print_namespace(category_counts)


def linq81():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    min_num = min(numbers)

    print("The minimum number is %d" % min_num)


def linq82():
    words = ["cherry", "apple", "blueberry"]

    shortest_word = min(len(w) for w in words)

    print("The shortest word is %d characters long." % shortest_word)


def linq83():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_cheapest_price = map(lambda g: SimpleNamespace(Category=g[0],
                                                            CheapestPrice=min(p.UnitPrice for p in g[1])),
                                  grouped_by_category)

    shared.print_namespace(category_cheapest_price)

    
def linq84():
    pass


def linq85():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    max_num = max(numbers)

    print("The maximum number is %d." % max_num)


def linq86():
    words = ["cherry", "apple", "blueberry"]

    longest_word = max(len(w) for w in words)

    print("The longest word is %d characters long." % longest_word)


def linq87():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_expensive_price = map(
        lambda g: SimpleNamespace(Category=g[0],
                                  MostExpensive=max(p.UnitPrice for p in g[1])),
        grouped_by_category)

    shared.print_namespace(category_expensive_price)


def linq88():
    pass


def linq89():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    average_num = sum(numbers) / float(len(numbers))

    print("The average number is %f." % average_num)


def linq90():
    words = ["cherry", "apple", "blueberry"]
    average_length = sum(len(w) for w in words) / float(len(words))

    print("The average word length is %f characters." % average_length)


def linq91():
    pass


def linq92():
    doubles = [1.7, 2.3, 1.9, 4.1, 2.9]

    product = reduce(operator.mul, doubles)

    #or
    #product = reduce(lambda running_product, next_factor: running_product * next_factor, doubles)

    print("Total product of all numbers: %f" % product)


def linq93():
    start_balance = 100.0

    attempted_withdrawals = [20, 10, 40, 50, 10, 70, 30]

    end_balance = reduce(
        lambda runningBalance, nextWithDrawal: runningBalance - nextWithDrawal if nextWithDrawal <= runningBalance else runningBalance,
        attempted_withdrawals,
        start_balance)

    print("Ending balance: %f" % end_balance)


linq73()
# linq74()
# linq76()
# linq77()
# linq78()
# linq79()
# linq80()
# linq81()
# linq82()
# linq83()
# linq84()
# linq85()
# linq86()
# linq87()
# linq88()
# linq89()
# linq90()
# linq91()
# linq92()
# linq93()
