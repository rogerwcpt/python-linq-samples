import shared
import itertools

def linq65():
    numbers = range(100, 150)

    odd_even = map(lambda n: {'Number': n, 'OddEven': ("odd" if (n % 2 == 1) else "even")}, numbers)

    for item in odd_even:
        print("The number %s is %s" % (item['Number'], item['OddEven']))


def linq66():
    numbers = itertools.repeat(7, 10)

    shared.printN(numbers)


# linq65()
linq66()