import shared
import functions
from types import SimpleNamespace
import itertools

def linq20():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first3_numbers = numbers[:3]

    print("First 3 numbers:")
    shared.printN(first3_numbers)


def linq22():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    all_but_first4_numbers = numbers[4:]

    print("All but first 4 numbers:")
    shared.printN(all_but_first4_numbers)


def linq23():
    customers = shared.getCustomerList()

    wa_customers = filter(lambda c: c.Region == "WA", customers)
    wa_customer_orders = functions.select_many(wa_customers, "Orders")
    customer_orders = map(lambda x: SimpleNamespace(customer_id=x.item_a.CustomerID, order_id=x.item_b.OrderID, order_date=x.item_b.OrderDate), wa_customer_orders)

    all_but_first2 = list(customer_orders)[2:]

    print("All but first 2 orders in WA:");
    shared.print_namespace(all_but_first2)


def linq24():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first_numbers_less_than6 = itertools.takewhile(lambda x: x < 6, numbers);

    print("First numbers less than 6:");
    shared.printN(first_numbers_less_than6)


def linq25():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    index = 0

    def digit_greater_equal_to_index(digit):
        nonlocal index
        result = digit >= index
        index += 1
        return result

    first_small_numbers = itertools.takewhile(lambda x: digit_greater_equal_to_index(x), numbers)

    print("First numbers not less than their position:")
    shared.printN(first_small_numbers)


def linq26():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    all_but_first3_numbers = itertools.dropwhile(lambda n:  n % 3 != 0, numbers)

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

    later_numbers = itertools.dropwhile(lambda x: digit_greater_equal_to_index(x), numbers)

    print("All elements starting from first element less than its position:")
    shared.printN(later_numbers)


# linq20()
# linq22()
# linq23()
# linq24()
# linq25()
# linq26()
linq27()
