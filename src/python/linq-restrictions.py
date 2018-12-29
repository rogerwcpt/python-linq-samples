import shared

def printS(sequence):
    print (list(sequence))

def linq1():
    numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]
    lowNums = filter(lambda x: x < 5, numbers)
    
    print("Numbers < 5:")
    printS(lowNums)

def linq2():
    products = shared.getProductList()
    soldOutProducts = filter(lambda x: x.UnitsInStock == 0, products)

    print("Sold out products:")
    for item in soldOutProducts:
        print("%s is sold out!" % (item.ProductName))

def linq3():
    products = shared.getProductList()
    expensiveInStockProducts = filter(lambda x: x.UnitsInStock > 0 and x.UnitPrice > 3.0000, products) 

    print("In-stock products that cost more than 3.00:")
    for item in expensiveInStockProducts:
        print("%s is in stock and costs more than 3.00." % (item.ProductName))

def linq4():
    customers = shared.getCustomerList()
    # waCustomers = filter(lambda x: x.Region == "WA", customers)

    print("Customers")
    for customer in customers:
        print(customer.Region)



# linq1()
# linq2()
# linq3()
linq4()
