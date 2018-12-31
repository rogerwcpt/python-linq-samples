import shared

def linq20():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first3_numbers = numbers[:3]

    print("First 3 numbers:")
    shared.printN(first3_numbers)


def linq22():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
    all_but_first4_numbers = numbers[4:]

    print("All but first 4 numbers:");
    shared.printN(all_but_first4_numbers)



linq20()
linq22()
