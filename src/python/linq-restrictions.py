import shared


def linq1():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    low_nums = filter(lambda x: x < 5, numbers)
    
    print("Numbers < 5:")
    shared.printN(low_nums)


def linq2():
    products = shared.getProductList()

    sold_out_products = filter(lambda x: x.UnitsInStock == 0, products)

    print("Sold out products:")
    for item in sold_out_products:
        print("%s is sold out!" % item.ProductName)


def linq3():
    products = shared.getProductList()

    expensive_in_stock_products = filter(lambda x: x.UnitsInStock > 0 and x.UnitPrice > 3.0000, products)

    print("In-stock products that cost more than 3.00:")
    for item in expensive_in_stock_products:
        print("%s is in stock and costs more than 3.00." % item.ProductName)


def linq4():
    customers = shared.getCustomerList()

    wa_customers = filter(lambda x: x.Region == "WA", customers)

    print("Customers from Washington and their orders:")
    for customer in wa_customers:
            print("Customer %s : %s" % (customer.CustomerID, customer.CompanyName))
            for order in customer.Orders:
                    print("     Order %s: %s" % (order.OrderID, order.OrderDate))


def linq5():
        digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
  
        index = 0

        # Lambdas cant have multiple lines, so create a filter function
        def filter_func(digit):
                nonlocal index
                result = len(digit) < index
                index += 1
                return result

        short_digits = filter(lambda digit: filter_func(digit), digits)
  
        print("Short digits:")
        for d in short_digits:
                print("The word %s is shorter than its value." % d)

        
linq1()
# linq2()
# linq3()
# linq4()
# linq5()
