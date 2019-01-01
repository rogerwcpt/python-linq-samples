import shared
from types import SimpleNamespace
from itertools import groupby

def linq73():
    factors_of_300 = [2, 2, 3, 5, 5]

    unique_factors = len(set(factors_of_300))

    print("There are %d unique factors of 300." % unique_factors)


def linq74():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    odd_numbers = sum(n % 2 == 1 for n in numbers)

    print("There are %d odd numbers in the list." % odd_numbers)


def linq75():
    customers = shared.getCustomerList()

    order_counts = map(lambda cust: SimpleNamespace(CustomerID=cust.CustomerID, OrderCount=len(cust.Orders)), customers)

    shared.print_namespace(order_counts)


def linq77():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_counts = map(lambda g: SimpleNamespace(Category=g[0], ProductCount=len(list(g[1]))), grouped_by_category)

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

    category_counts = map(lambda g: SimpleNamespace(Category=g[0], TotalUnitsInStock=sum(p.UnitsInStock for p in g[1])), grouped_by_category)

    shared.print_namespace(category_counts)


def linq81():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    min_num = min(numbers)

    print("The minimum number is %d" % min_num)


def linq82():
    words = ["cherry", "apple", "blueberry"]

    shortest_word = min(len(w) for w in words)

    print("The shortest word is %s characters long." % shortest_word)


def linq83():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)

    category_cheapest_price = map(lambda g: SimpleNamespace(Category=g[0], CheapestPrice=min(p.UnitPrice for p in g[1])), grouped_by_category)

    shared.print_namespace(category_cheapest_price)

    
def linq84():
    products = shared.getProductList()

    sorted_by_category = sorted(products, key=lambda p: p.Category)
    grouped_by_category = groupby(sorted_by_category, key=lambda p: p.Category)
    
    categories_min_unitprice = map(lambda pg: SimpleNamespace(ProdGroup=pg, MinPrice=min(p.UnitPrice for p in pg[1])), grouped_by_category)

    for item in categories_min_unitprice:
        print("%s %d" % (item.ProdGroup, item.MinPrice))


# linq73()
# linq74()
# linq75()
# linq77()
# linq78()
# linq79()
# linq80()
# linq81()
# linq82()
# linq83()
linq84()