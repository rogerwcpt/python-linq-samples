import shared
import functions
import datetime

from types import SimpleNamespace

from itertools import takewhile
from itertools import dropwhile


def linq20():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first3_numbers = numbers[:3]

    print("First 3 numbers:")
    shared.printN(first3_numbers)


def linq21():
    customers = shared.getCustomerList()

    order_greater_than_date = ((cust, order)
                               for cust in customers
                               for order in cust.Orders
                               if cust.Region == "WA")
    orders = [SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              orderDate=x[1].OrderDate)
              for x in order_greater_than_date]

    first_3_orders = orders[:3]

    print("First 3 orders in WA:")
    shared.print_namespace(first_3_orders)


def linq22():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    all_but_first4_numbers = numbers[4:]

    print("All but first 4 numbers:")
    shared.printN(all_but_first4_numbers)


def linq23():
    customers = shared.getCustomerList()

    order_greater_than_date = ((cust, order)
                               for cust in customers
                               for order in cust.Orders
                               if cust.Region == "WA")
    orders = [SimpleNamespace(customer_id=x[0].CustomerID,
                              order_id=x[1].OrderID,
                              orderDate=x[1].OrderDate)
              for x in order_greater_than_date]

    all_but_first2 = orders[2:]

    print("All but first 2 orders in WA:")
    shared.print_namespace(all_but_first2)


def linq24():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first_numbers_less_than6 = takewhile(lambda x: x < 6, numbers)

    print("First numbers less than 6:")
    shared.printN(first_numbers_less_than6)


def linq25():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    index = 0

    def digit_greater_equal_to_index(digit):
        nonlocal index
        result = digit >= index
        index += 1
        return result

    first_small_numbers = takewhile(digit_greater_equal_to_index, numbers)

    print("First numbers not less than their position:")
    shared.printN(first_small_numbers)


def linq26():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    all_but_first3_numbers = dropwhile(lambda n:  n % 3 != 0, numbers)

    print("All elements starting from first element divisible by 3:")
    shared.printN(all_but_first3_numbers)


def linq27():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    index = 0

    def digit_greater_equal_to_index(digit):
        nonlocal index
        result = digit >= index
        index += 1
        return result

    later_numbers = dropwhile(digit_greater_equal_to_index, numbers)

    print("All elements starting from first element less than its position:")
    shared.printN(later_numbers)


# linq20()
# linq21()
# linq22()
# linq23()
# linq24()
# linq25()
# linq26()
# linq27()
