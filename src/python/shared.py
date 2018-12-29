import json

class Product(object):
    def __init__(self, ProductID=None, ProductName=None, Category=None, UnitPrice=None, UnitsInStock=None):
        self.ProductID = ProductID
        self.ProductName = ProductName
        self.Category = Category
        self.UnitPrice = UnitPrice
        self.UnitsInStock = UnitsInStock

class Order(object):
    def __init__(self, OrderId=None, OrderDate=None, Total=None):
        self.OrderID = Order
        self.OrderDate = OrderDate
        self.Total = Total
    
class Customer(object):
    def __init__(self, CustomerID=None, CompanyName=None, Address=None, City=None, Region=None, PostalCode=None, Country=None, Phone=None, Fax=None, Order = None):
        self.CustomerID = CustomerID
        self.CompanyName = CompanyName
        self.Address = Address
        self.City = City
        self.Region = Region
        self.PostalCode = PostalCode
        self.Country = Country
        self.Phone = Phone
        self.Fax = Fax
        self.Orders = Order

def getProductList():
    result = []
    result.append(Product(1, "Chai", "Beverages", 18.0000, 39))
    result.append(Product(2, "Chang", "Beverages", 19.0000, 17 ))
    result.append(Product(3, "Aniseed Syrup", "Condiments", 10.0000, 13 ))
    result.append(Product(4, "Chef Anton's Cajun Seasoning", "Condiments", 22.0000, 53 ))
    result.append(Product(5, "Chef Anton's Gumbo Mix", "Condiments", 21.3500, 0 ))
    result.append(Product(6, "Grandma's Boysenberry Spread", "Condiments", 25.0000, 120 ))
    result.append(Product(7, "Uncle Bob's Organic Dried Pears", "Produce", 30.0000, 15 ))
    result.append(Product(8, "Northwoods Cranberry Sauce", "Condiments", 40.0000, 6 ))
    result.append(Product(9, "Mishi Kobe Niku", "Meat/Poultry", 97.0000, 29 ))
    result.append(Product(10, "Ikura", "Seafood", 31.0000, 31 ))
    result.append(Product(11, "Queso Cabrales", "Dairy Products", 21.0000, 22 ))
    result.append(Product(12, "Queso Manchego La Pastora", "Dairy Products", 38.0000, 86 ))
    result.append(Product(13, "Konbu", "Seafood", 6.0000, 24 ))
    result.append(Product(14, "Tofu", "Produce", 23.2500, 35 ))
    result.append(Product(15, "Genen Shouyu", "Condiments", 15.5000, 39 ))
    result.append(Product(16, "Pavlova", "Confections", 17.4500, 29 ))
    result.append(Product(17, "Alice Mutton", "Meat/Poultry", 39.0000, 0 ))
    result.append(Product(18, "Carnarvon Tigers", "Seafood", 62.5000, 42 ))
    result.append(Product(19, "Teatime Chocolate Biscuits", "Confections", 9.2000, 25 ))
    result.append(Product(20, "Sir Rodney's Marmalade", "Confections", 81.0000, 40 ))
    result.append(Product(21, "Sir Rodney's Scones", "Confections", 10.0000, 3 ))
    result.append(Product(22, "Gustaf's Knäckebröd", "Grains/Cereals", 21.0000, 104 ))
    result.append(Product(23, "Tunnbröd", "Grains/Cereals", 9.0000, 61 ))
    result.append(Product(24, "Guaraná Fantástica", "Beverages", 4.5000, 20 ))
    result.append(Product(25, "NuNuCa Nuß-Nougat-Creme", "Confections", 14.0000, 76 ))
    result.append(Product(26, "Gumbär Gummibärchen", "Confections", 31.2300, 15 ))
    result.append(Product(27, "Schoggi Schokolade", "Confections", 43.9000, 49 ))
    result.append(Product(28, "Rössle Sauerkraut", "Produce", 45.6000, 26 ))
    result.append(Product(29, "Thüringer Rostbratwurst", "Meat/Poultry", 123.7900, 0 ))
    result.append(Product(30, "Nord-Ost Matjeshering", "Seafood", 25.8900, 10 ))
    result.append(Product(31, "Gorgonzola Telino", "Dairy Products", 12.5000, 0 ))
    result.append(Product(32, "Mascarpone Fabioli", "Dairy Products", 32.0000, 9 ))
    result.append(Product(33, "Geitost", "Dairy Products", 2.5000, 112 ))
    result.append(Product(34, "Sasquatch Ale", "Beverages", 14.0000, 111 ))
    result.append(Product(35, "Steeleye Stout", "Beverages", 18.0000, 20 ))
    result.append(Product(36, "Inlagd Sill", "Seafood", 19.0000, 112 ))
    result.append(Product(37, "Gravad lax", "Seafood", 26.0000, 11 ))
    result.append(Product(38, "Côte de Blaye", "Beverages", 263.5000, 17 ))
    result.append(Product(39, "Chartreuse verte", "Beverages", 18.0000, 69 ))
    result.append(Product(40, "Boston Crab Meat", "Seafood", 18.4000, 123 ))
    result.append(Product(41, "Jack'England Clam Chowder", "Seafood", 9.6500, 85 ))
    result.append(Product(42, "Singaporean Hokkien Fried Mee", "Grains/Cereals", 14.0000, 26 ))
    result.append(Product(43, "Ipoh Coffee", "Beverages", 46.0000, 17 ))
    result.append(Product(44, "Gula Malacca", "Condiments", 19.4500, 27 ))
    result.append(Product(45, "Rogede sild", "Seafood", 9.5000, 5 ))
    result.append(Product(46, "Spegesild", "Seafood", 12.0000, 95 ))
    result.append(Product(47, "Zaanse koeken", "Confections", 9.5000, 36 ))
    result.append(Product(48, "Chocolade", "Confections", 12.7500, 15 ))
    result.append(Product(49, "Maxilaku", "Confections", 20.0000, 10 ))
    result.append(Product(50, "Valkoinen suklaa", "Confections", 16.2500, 65 ))
    result.append(Product(51, "Manjimup Dried Apples", "Produce", 53.0000, 20 ))
    result.append(Product(52, "Filo Mix", "Grains/Cereals", 7.0000, 38 ))
    result.append(Product(53, "Perth Pasties", "Meat/Poultry", 32.8000, 0 ))
    result.append(Product(54, "Tourtière", "Meat/Poultry", 7.4500, 21 ))
    result.append(Product(55, "Pâté chinois", "Meat/Poultry", 24.0000, 115 ))
    result.append(Product(56, "Gnocchi di nonna Alice", "Grains/Cereals", 38.0000, 21 ))
    result.append(Product(57, "Ravioli Angelo", "Grains/Cereals", 19.5000, 36 ))
    result.append(Product(58, "Escargots de Bourgogne", "Seafood", 13.2500, 62 ))
    result.append(Product(59, "Raclette Courdavault", "Dairy Products", 55.0000, 79 ))
    result.append(Product(60, "Camembert Pierrot", "Dairy Products", 34.0000, 19 ))
    result.append(Product(61, "Sirop d'érable", "Condiments", 28.5000, 113 ))
    result.append(Product(62, "Tarte au sucre", "Confections", 49.3000, 17 ))
    result.append(Product(63, "Vegie-spread", "Condiments", 43.9000, 24 ))
    result.append(Product(64, "Wimmers gute Semmelknödel", "Grains/Cereals", 33.2500, 22 ))
    result.append(Product(65, "Louisiana Fiery Hot Pepper Sauce", "Condiments", 21.0500, 76 ))
    result.append(Product(66, "Louisiana Hot Spiced Okra", "Condiments", 17.0000, 4 ))
    result.append(Product(67, "Laughing Lumberjack Lager", "Beverages", 14.0000, 52 ))
    result.append(Product(68, "Scottish Longbreads", "Confections", 12.5000, 6 ))
    result.append(Product(69, "Gudbrandsdalsost", "Dairy Products", 36.0000, 26 ))
    result.append(Product(70, "Outback Lager", "Beverages", 15.0000, 15 ))
    result.append(Product(71, "Flotemysost", "Dairy Products", 21.5000, 26 ))
    result.append(Product(72, "Mozzarella di Giovanni", "Dairy Products", 34.8000, 14 ))
    result.append(Product(73, "Röd Kaviar", "Seafood", 15.0000, 101 ))
    result.append(Product(74, "Longlife Tofu", "Produce", 10.0000, 4 ))
    result.append(Product(75, "Rhönbräu Klosterbier", "Beverages", 7.7500, 125 ))
    result.append(Product(76, "Lakkalikööri", "Beverages", 18.0000, 57 ))
    result.append(Product(77, "Original Frankfurter grüne Soße", "Condiments", 13.0000, 32 ))
    return result

def getCustomerList():
    result = []
    with open("../../Customers.json", "r") as read_file:
        customerData = json.load(read_file)
        for customer in customerData["customers"]:
            cust = Customer(customer["id"], customer["name"])
            if "region" in customer:
                cust.Region = customer["region"]
            # for order in customer["orders"]:
            #     ord = Order(order["id"], order["orderdate"], order["total"])
            #     cust.Orders.append(ord)
            result.append(cust)
    return result
