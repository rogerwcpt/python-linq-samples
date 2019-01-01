
101 LINQ Samples in Python
========================

Port of the [C# 101 LINQ Samples](http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b) rewritten into idiomatic Python and utilizing its functional methods where possible.

Python doesn't really lend itself well to functional programming because is functional methods are really procedural.  There is support for lambda expressions, but you can't chain or compose your your functional operations very well as you will see compare to C# equivalent below.


### Why the fork?

- The original MSDN C# examples use the SQL Query / DSL Linq syntax instead for the more generally accepted Extension method/lambda syntax.
  -  which is very similar to Dart
  -  has all the methods such as Distinct, Take, Union First etc so that you don't have to mix the styles (see mixed syntax example below)
 - This fork uses more up to date C# syntax, including the `var` keyword wherever possible and string interpolatation
 - This fork has included the modified C# source locally so that you don't have to visit the outdated MSDN site.
 - This fork has included a [Operation Comparison Matrix](#operation-comparison-matrix)

##### Mixed syntax (bad)
```csharp
var categoryNames = ( 
    from p in products 
    select p.Category) 
    .Distinct(); 
```
- The SQL / DSL Linq syntax is more long winded.


##### Lonq winded Linq syntax
```csharp
var sortedWords =
    from w in words
    orderby w
    select w;
```

##### More succinct extension method Linq syntax
```csharp
var sortedWords = words
    .OrderBy(x => x);
```


### Contents

The samples below mirrors the C# LINQ samples layout with the names of the top-level Dart methods matching their corresponding C# examples.

### Operation Comparison Matrix
|Operation|C#|Dart|Comment|
|---------|--|----|-------|
|**Restriction**|`Where`|`filter`||
|**Projection**|`Select`|`map`||
||`SelectMany`||Custom select_many utility added|
|**Partitioning**|`IEnumerable.Take(n)`|`array[:n]`||
||`IEnumerable.TakeWhile(predicate)`|`itertools.takewhile(predicate, sequence)`||
||`IEnumerable.Skip(n)`|`array[n:]`||
||`SkipWhile`|`itertools.dropwhile(predicate, sequence)`||
|**Ordering**|`OrderBy`|`sequence.sort()` *or* <br/> `sorted(sequence)`|| 
||`OrderBy(lambda)`|`sequence.sort(key=lambda)` *or* <br/> `sorted(sequence, key=lambda)`|| 
||`OrderByDescending`|`sequence.sort(reverse=True)` *or* <br/>  `sorted(sequence, reverse=True)`|| 
||`OrderByDescending(lambda)`|`sequence.sort(key=lambda, reverse=True)` *or* <br/> `sorted(sequence, key=lambda, reverse=True)`|| 
||`ThenBy`|`sequence.sort(key=lambda (key1, key2))` *or* <br/> `sorted(sequence, key=lambda (key1, key))`|| 
||`ThenByDescending`|`sequence.sort(key=lambda (key1, -key2))` *or* <br/> `sorted(sequence, key=lambda (key1, -key2))` <br/> *or use a 2 pass sort, starting with least significant* <br/> `ordered =  sorted(unordered, key=lambda (key2))`  <br/> `ordered =  sorted(ordered, key=lambda (key1))` |
||`Reverse`|`sequence.reverse()` *or* `reversed(sequence)`||
|**Grouping**|`GroupBy`|`groupby`|`from itertools import groupby` <br/>Grouping  works on sorted sequences
|**Sets**|`Distinct`|`set`||
||`Union`|`union`||
||`Interect`|`intersection`||
||`Except`|`difference`||
|**Conversion**|`ToArray`|`toList`||
||`ToList`|`toList`||
||`ToDictionary`|`dict`|Often used in conjuction with `zip`|
||`OfType`|`'filter` using `isinstance` as predicate|
|**Element**|`First`|`next`||
||`First(lambda)`|`next(filter(lambda)`||
||`FirstOrDefault`|`next(filter(lambda), default)`|
||`ElementAt`|`list[0]`||
|**Generation**|`Enumerable.Range`|range|
||`Enumerable.Repeat`|`[x] * n` *or* <br /> `itertools.repeat(x, n)`||
|**Quantifiers**|`Any`|`any`||
||`All`|`all`||
|**Aggregate**|`Count`|`length`||
||`Count(lamda)`|`where(lambda).length`||
||`Sum`||Custom [sum](#dart-utils-added-4) utility  added|
||`Min`||Custom [min](#dart-utils-added-4) utility  added|
||`Max`||Custom [max](#dart-utils-added-4) utility  added|
||`Avg`||Custom [avg](#dart-utils-added-4) utility  added|
||`Sum(lambda)`||Custom [sum](#dart-utils-added-4) utility  added|
||`Min(lambda)`||Custom [min](#dart-utils-added-4) utility  added|
||`Max(lambda)`||Custom [max](#dart-utils-added-4) utility  added|
||`Avg(lambda)`||Custom [avg](#dart-utils-added-4) utility  added|
||`Aggregate`|reduce||
||`Aggregate(seed)`|fold||
|**Miscellaneous**|`Concat`||Custom [concat](#dart-utils-added-5) utility  added|
||`SequenceEqual`|SequenceEqual|||Custom [seqEq](#dart-utils-added-5) utility  added|
|**Join**|Join||Custom [join](#dart-utils-added-6) utility  added|
||GroupJoin||Custom [joinGroup](#dart-utils-added-6) utility  added|

#### Source
- [Restriction Operators](#linq1-where---simple-1)
  -  [Phython](src/python/linq-restrictions.py) 
  -  [C#](src/csharp/linq-restrictions/Program.cs)
- [Projection Operators](#linq---projection-operators)
  - [Phython](src/python/linq-projections.py)
  - [C#](src/csharp/linq-projections/Program.cs)
- [Partitioning Operators](#linq---partitioning-operators)
  - [Phython]src/python/linq-partitions.py)
  - [C#](src/csharp/linq-partitioning/Program.cs)
- [Ordering Operators](#linq---ordering-operators)
  - [Phython]src/python/linq-ordering.py)
  - [C#](src/csharp/linq-ordering/Program.cs)
- [Grouping Operators](#linq---grouping-operators)
  - [Dart](bin/linq-grouping.dart)
  - [C#](src/csharp/linq-grouping/Program.cs)
- [Set Operators](#linq---set-operators)
  - [Dart](bin/linq-setoperations.dart)
  - [C#](src/csharp/linq-sets/Program.cs)
- [Conversion Operators](#linq---conversion-operators)
  - [Dart](bin/linq-conversionoperations.dart)
  - [C#](src/csharp/linq-conversion/Program.cs)
- [Element Operators](#linq---element-operators)
  - [Dart](bin/linq-elementoperations.dart)
  - [C#](src/csharp/linq-element/Program.cs)
- [Generation Operators](#linq---generation-operators)
  - [Dart](bin/linq-generationoperations.dart)
  - [C#](src/csharp/linq-generation/Program.cs)
- [Quantifiers](#linq---quantifiers)
  - [Dart](bin/linq-quantifiers.dart)
  - [C#](src/csharp/linq-quantifiers/Program.cs)
- [Aggregate Operators](#linq---aggregate-operators)
  - [Dart](bin/linq-aggregateoperations.dart)
  - [C#](src/csharp/linq-aggregate/Program.cs)
- [Miscellaneous Operators](#linq---miscellaneous-operators)
  - [Dart](bin/linq-miscellaneousoperations.dart)
  - [C#](src/csharp/linq-miscellaneous/Program.cs)
- [Query Execution](#linq---query-execution)
  - [Dart](bin/linq-queryexecution.dart)
  - [C#](src/csharp/linq-query/Program.cs)
- [Join Operators](#linq---join-operators)
  - [Dart](bin/linq-joinoperators.dart)
  - [C#](src/csharp/linq-join/Program.cs)

##  Side-by-side - C# LINQ vs Dart functional collections

For a side-by-side comparison, the original **C#** source code is displayed above the equivalent **Dart** translation. 

  - The **Output** shows the console output of running the **Dart** sample. 
  - Outputs ending with `...` illustrates only a partial response is displayed. 
  - The source-code for C# and Dart utils used are included once under the first section they're used in.
  - The C# ObjectDumper util used is downloadable from MSDN - [ObjectDumper.zip](http://code.msdn.microsoft.com/Visual-Studio-2008-C-d295cdba/file/46086/1/ObjectDumper.zip)

LINQ - Restriction Operators
----------------------------

### linq1: Where - Simple 1

```csharp
//c#
public void Linq1() 
{ 
    var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var lowNums = numbers
        .Where(n => n < 5);

    Console.WriteLine("Numbers < 5:");
    lowNums.ForEach((x) => Console.WriteLine(x));
}  
```
```python
#python
def linq1():
    numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]
    lowNums = filter(lambda x: x < 5, numbers)
    
    print("Numbers < 5:")
    printS(lowNums)
```
#### Output

    Numbers < 5:
    4
    1
    3
    2
    0
  
### linq2: Where - Simple 2
```csharp
//c#
public void Linq2() 
{ 
    var products = GetProductList();

    var soldOutProducts = products
        .Where(p => p.UnitsInStock == 0);

    Console.WriteLine("Sold out products:");
    soldOutProducts.ForEach(x => Console.WriteLine($"{x.ProductName} is sold out!"));
} 
```
```python
#python
def linq2():
    products = shared.getProductList()
    soldOutProducts = filter(lambda x: x.UnitsInStock == 0, products)

    print("Sold out products:")
    for item in soldOutProducts:
        print("%s is sold out!" % (item.ProductName))
```
#### Output

    Sold out products:
    Chef Anton's Gumbo Mix is sold out!
    Alice Mutton is sold out!
    Th�ringer Rostbratwurst is sold out!
    Gorgonzola Telino is sold out!
    Perth Pasties is sold out!

### linq3: Where - Simple 3
```csharp
//c#
public void Linq3() 
{ 
    var products = GetProductList();

    var expensiveInStockProducts = products
        .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);

    Console.WriteLine("In-stock products that cost more than 3.00:");
    expensiveInStockProducts.ForEach((product) => Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00."));
  
} 
```
```python
#python
def linq3():
    products = shared.getProductList()
    expensiveInStockProducts = filter(lambda x: x.UnitsInStock > 0 and x.UnitPrice > 3.0000, products) 

    print("In-stock products that cost more than 3.00:")
    for item in expensiveInStockProducts:
        print("%s is in stock and costs more than 3.00." % (item.ProductName))

```
#### Output

    In-stock products that cost more than 3.00:
    Chai is in stock and costs more than 3.00.
    Chang is in stock and costs more than 3.00.
    Aniseed Syrup is in stock and costs more than 3.00.
    ...

### linq4: Where - Drilldown
```csharp
//c#
public void Linq4() 
{ 
    var customers = GetCustomerList();

    Console.WriteLine("Customers from Washington and their orders:");
    var waCustomers = customers
        .Where(c => c.Region == "WA");
    
    waCustomers.ForEach((customer) =>
    {
        Console.WriteLine("Customer {customer.CustomerID}: {customer.CompanyName}");
        customer.Orders.ForEach((order) => 
        {
            Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
        });
    });
} 
```
```python
#python
def linq4():
    customers = shared.getCustomerList()
    waCustomers = filter(lambda x: x.Region == "WA", customers)

    print("Customers from Washington and their orders:")
    for customer in waCustomers:
            print("Customer %s : %s" % (customer.CustomerID, customer.CompanyName))
            for order in customer.Orders:
                    print("     Order %s: %s" % (order.OrderID, order.OrderDate))
```
#### Output

    Customers from Washington and their orders:
    Customer LAZYK: Lazy K Kountry Store
      Order 10482: 1997-03-21T00:00:00
      Order 10545: 1997-05-22T00:00:00
    Customer TRAIH: Trail's Head Gourmet Provisioners
      Order 10574: 1997-06-19T00:00:00
      Order 10577: 1997-06-23T00:00:00
      Order 10822: 1998-01-08T00:00:00
    ...

### linq5: Where - Indexed
```csharp
//c#
public void Linq5() 
{ 
    var digits = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var shortDigits = digits.Where((digit, index) => digit.Length < index);

    Console.WriteLine("Short digits:");
    shortDigits.ForEach(d => Console.WriteLine($"The word {d} is shorter than its value."));
}
```
```python
#python
def linq5():
        digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
  
        index=0

        # Lambdas cant have multiple lines, so create a fitler function
        def FilterFunc(digit):
                nonlocal index
                result = len(digit) < index
                index += 1
                return result

        shortDigits = filter(lambda digit: FilterFunc(digit), digits)
  
        print("Short digits:"); 
        for d in shortDigits:
                print("The word %s is shorter than its value." % (d))
```
#### Output

    Short digits:
    The word five is shorter than its value.
    The word six is shorter than its value.
    The word seven is shorter than its value.
    The word eight is shorter than its value.
    The word nine is shorter than its value.


LINQ - Projection Operators
---------------------------

### Python utils added

```python
def select_many(outer_list, inner_list):
    def select(item, the_list):
        return map(lambda b: SimpleNamespace(a=item, b=b), the_list)

    result = []
    for outer_list in outer_list:
        result.extend(select(outer_list, inner_list))
    return result
```

### linq6: Select - Simple 1
```csharp
//c#
public void Linq6() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var numsPlusOne = numbers
        .Select(n => n + 1);

    Console.WriteLine("Numbers + 1:");
    numsPlusOne.ForEach(Console.WriteLine);
}
```
```python
#python
def linq6():
    numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]
    numsPlusOne = map(lambda n: n + 1, numbers)

    print("Numbers + 1:")
    print(list(numsPlusOne))
```
#### Output

Numbers + 1:
[6, 5, 2, 4, 10, 9, 7, 8, 3, 1]

### linq7: Select - Simple 2
```csharp
//c#
public void Linq7() 
{ 
    var products = GetProductList();

    var productNames = products
        .Select(p => p.ProductName);

    Console.WriteLine("Product Names:");
    productNames.ForEach(Console.WriteLine);
}
```
```python
#python
def linq7():
    products = shared.getProductList()

    productNames = map(lambda p: p.ProductName, products)
  
    print("Product Names:")
    shared.printS(productNames)
```
#### Output

    Product Names:
    Chai
    Chang
    Aniseed Syrup
    Chef Anton's Cajun Seasoning
    Chef Anton's Gumbo Mix
    ...

### linq8: Select - Transformation
```csharp
//c#
public void Linq8() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var strings = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var textNums = numbers
        .Select(n => strings[n]);

    Console.WriteLine("Number strings:");
    textNums.ForEach(Console.WriteLine);
}
```
```python
#python
def linq8():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
  
    textNums = map(lambda n : strings[n], numbers) 
  
    print("Number strings:")
    shared.printS(textNums)
```
#### Output

    Number strings:
    five
    four
    one
    three
    nine
    eight
    six
    seven
    two
    zero

### linq9: Select - Anonymous Types 1
```csharp
//c#
public void Linq9() 
{ 
    var words = new[] { "aPPLE", "BlUeBeRrY", "cHeRry" };

    var upperLowerWords = words
        .Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });

    upperLowerWords.ForEach(ul => Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}"));
}
```
```python
#python
def linq9():
    words = ["aPPLE", "BlUeBeRrY", "cHeRry"]
    
    upperLowerWords = map(lambda w : SimpleNamespace(Upper=w.upper(), Lower=w.lower()), words)
    for word in upperLowerWords:
        print("Uppercase: %s, Lowercase: %s" % (word.Upper, word.Lower))
```
#### Output

    Uppercase: APPLE, Lowercase: apple
    Uppercase: BLUEBERRY, Lowercase: blueberry
    Uppercase: CHERRY, Lowercase: cherry

### linq10: Select - Anonymous Types 2
```csharp
//c#
public void Linq10() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var digitOddEvens = numbers
        .Select(n => new { Digit = strings[n], Even = (n % 2 == 0) });
    
    digitOddEvens.ForEach(d => Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}."));
}
```
```python
#python
def linq10():
    numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
    strings = [ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ]
  
    digitOddEvens = map(lambda n : SimpleNamespace(Digit=strings[n], Even=(n % 2 == 0) ), numbers)
      
    for d in digitOddEvens:
        print("The digit %s is %s" % (d.Digit, 'even' if d.Even else 'odd'))
```
#### Output

    The digit five is odd.
    The digit four is even.
    The digit one is odd.
    The digit three is odd.
    The digit nine is odd.
    The digit eight is even.
    The digit six is even.
    The digit seven is odd.
    The digit two is even.
    The digit zero is even.

### linq11: Select - Anonymous Types 3
```csharp
//c#
public void Linq11() 
{ 
    var products = GetProductList();

    var productInfos = products
        .Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

    Console.WriteLine("Product Info:");
    productInfos.ForEach(productInfo => Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs {productInfo.Price} per unit."));
 }
```
```python
#python
def linq11():
    products = shared.getProductList()
  
    productInfos = map(lambda p: SimpleNamespace(ProductName=p.ProductName, Category=p.Category, Price=p.UnitPrice), products) 
      
    print("Product Info:")
    for p in productInfos:
        print("%s is in the category %s and costs %.2f per unit." % (p.ProductName, p.Category, p.Price))
```
#### Output

    Product Info:
    Chai is in the category Beverages and costs 18.0 per unit.
    Chang is in the category Beverages and costs 19.0 per unit.
    Aniseed Syrup is in the category Condiments and costs 10.0 per unit.
    ...

### linq12: Select - Indexed
```csharp
//c#
public void Linq12() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var numsInPlace = numbers
        .Select((num, index) => new { Num = num, InPlace = (num == index) });

    Console.WriteLine("Number: In-place?");
    numsInPlace.ForEach(n => Console.WriteLine($"{n.Num}: {n.InPlace}"));
}
```
```python
#python
def linq12():
    numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]
  
    index = 0

    def CheckInPlace(digit):
        nonlocal index
        result = digit == index
        index += 1
        return result

    numsInPlace = map(lambda num: SimpleNamespace(Num=num, InPlace=CheckInPlace(num)), numbers)
  
    print("Number: In-place?"); 
    for n in numsInPlace:
        print("%d: %s" % (n.Num, n.InPlace))
```
#### Output

    Number: In-place?
    5: false
    4: false
    1: false
    3: true
    9: false
    8: false
    6: true
    7: true
    2: false
    0: false

### linq13: Select - Filtered
```csharp
//c#
public void Linq13() 
{ 
    var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var  digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var lowNums = numbers
        .Where(n => n < 5)
        .Select(n => digits[n]);

    Console.WriteLine("Numbers < 5:");
    lowNums.ForEach(Console.WriteLine);
```
```python
#python
def linq13():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    result = map(lambda n: digits[n], filter(lambda n: n < 5, numbers))

    print("Numbers < 5:")
    shared.printS(result)

```
#### Output

    Numbers < 5:
    four
    one
    three
    two
    zero

### linq14: SelectMany - Compound from 1
```csharp
//c#
public void Linq14() 
{ 
    var numbersA = new [] { 0, 2, 4, 5, 6, 8, 9 };
    var numbersB = new []{ 1, 3, 5, 7, 8 };

    var pairs = numbersA
        .SelectMany(a => numbersB, (a, b) => new { a, b })
        .Where(x => x.a < x.b);

    Console.WriteLine("Pairs where a < b:");
    pairs.ForEach(pair => Console.WriteLine("{0} is less than {1}", pair.a, pair.b));
}
```
```python
#python
def linq_14():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    pairs = filter(lambda pair: pair.a < pair.b, select_many(numbers_a, numbers_b))

    print("Pairs where a < b:")
    for p in pairs:
        print("%d is less than %d}" % (p.a, p.b))

```
#### Output

    Pairs where a < b:
    0 is less than 1
    0 is less than 3
    0 is less than 5
    0 is less than 7
    0 is less than 8
    2 is less than 3
    2 is less than 5
    2 is less than 7
    2 is less than 8
    4 is less than 5
    4 is less than 7
    4 is less than 8
    5 is less than 7
    5 is less than 8
    6 is less than 7
    6 is less than 8

### linq15: SelectMany - Compound from 2
```csharp
//c#
public void Linq15() 
{ 
    var customers = GetCustomerList();

    var orders = customers
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Where(x => x.order.Total < 500.00M)
        .Select(x =>  new { x.customer.CustomerID, x.order.OrderID, x.order.Total });

    ObjectDumper.Write(orders);
}
```
```python
#python
def linq15():
    customers = shared.getCustomerList()

    orders = map(lambda x: SimpleNamespace(customer_id=x.item_a.CustomerID, order_id=x.item_b.OrderID, total=x.item_b.Total),
                 filter(lambda x: x.item_b.Total < 500.00,
                        select_many(customers, "Orders")))

    shared.print_namespace(orders)
```
#### Output

    {CustomerId: ALFKI, OrderId: 10702, Total: 330.0}
    {CustomerId: ALFKI, OrderId: 10952, Total: 471.2}
    {CustomerId: ANATR, OrderId: 10308, Total: 88.8}
    {CustomerId: ANATR, OrderId: 10625, Total: 479.75}
    ...

### linq16: SelectMany - Compound from 3
```csharp
//c#
public void Linq16() 
{ 
    var customers = GetCustomerList();

    var orders = customers
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Where(x => x.order.OrderDate >= new DateTime(1998, 1, 1))
        .Select(x => new { x.customer.CustomerID, x.order.OrderID, x.order.OrderDate });

    ObjectDumper.Write(orders);
}
```
```python
#python
linq16(){
  var customers = customersList(); 
  
  var orders = customers
    .expand((c) => c.orders
      .where((o) => o.orderDate.isAfter(new DateTime(1998, 1, 1)))
      .map((o) => { 'CustomerId': c.customerId, 'OrderId':o.orderId, 'OrderDate':o.orderDate }));
  
  orders.forEach(print);   
}
```
#### Output

    {CustomerId: ALFKI, OrderId: 10835, OrderDate: 1998-01-15 00:00:00.000}
    {CustomerId: ALFKI, OrderId: 10952, OrderDate: 1998-03-16 00:00:00.000}
    {CustomerId: ALFKI, OrderId: 11011, OrderDate: 1998-04-09 00:00:00.000}
    {CustomerId: ANATR, OrderId: 10926, OrderDate: 1998-03-04 00:00:00.000}
    {CustomerId: ANTON, OrderId: 10856, OrderDate: 1998-01-28 00:00:00.000}
    ...

### linq17: SelectMany - from Assignment
```csharp
//c#
public void Linq17() 
{ 
    var customers = GetCustomerList();

    var orders = customers
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Where(x => x.order.Total >= 2000.00M)
        .Select(x => new { x.customer.CustomerID, x.order.OrderID, x.order.Total });

    ObjectDumper.Write(orders);
}
```
```dart
//dart
linq17(){
  var customers = customersList(); 
  
  var orders = customers
    .expand((c) => c.orders
      .where((o) => o.total >= 2000)
      .map((o) => { 'CustomerId': c.customerId, 'OrderId':o.orderId, 'Total':o.total }));
  
  orders.forEach(print);   
}
```
#### Output

    {CustomerId: ANTON, OrderId: 10573, Total: 2082.0}
    {CustomerId: AROUT, OrderId: 10558, Total: 2142.9}
    {CustomerId: AROUT, OrderId: 10953, Total: 4441.25}
    {CustomerId: BERGS, OrderId: 10384, Total: 2222.4}
    {CustomerId: BERGS, OrderId: 10524, Total: 3192.65}
    ...

### linq18: SelectMany - Multiple from
```csharp
//c#
public void Linq18() 
{ 
    var customers = GetCustomerList();

    var cutoffDate = new DateTime(1997, 1, 1);

    var orders = customers
        .Where(c => c.Region == "WA")
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Where(x => x.order.OrderDate >= cutoffDate)
        .Select(x => new { x.customer.CustomerID, x.customer.Region, x.order.OrderID });

    ObjectDumper.Write(orders);
}
```
```dart
//dart
linq18(){
  var customers = customersList(); 

  var cutoffDate = new DateTime(1997, 1, 1); 
  
  var orders = customers
    .where((c) => c.region == "WA")
    .expand((c) => c.orders
      .where((o) => o.orderDate.isAfter(cutoffDate))
      .map((o) => { 'CustomerId': c.customerId, 'OrderId':o.orderId }));
  
  orders.forEach(print);   
}
```
#### Output

    {CustomerId: LAZYK, OrderId: 10482}
    {CustomerId: LAZYK, OrderId: 10545}
    {CustomerId: TRAIH, OrderId: 10574}
    {CustomerId: TRAIH, OrderId: 10577}
    {CustomerId: TRAIH, OrderId: 10822}
    {CustomerId: WHITC, OrderId: 10469}
    {CustomerId: WHITC, OrderId: 10483}
    {CustomerId: WHITC, OrderId: 10504}
    {CustomerId: WHITC, OrderId: 10596}
    {CustomerId: WHITC, OrderId: 10693}
    {CustomerId: WHITC, OrderId: 10696}
    {CustomerId: WHITC, OrderId: 10723}
    {CustomerId: WHITC, OrderId: 10740}
    {CustomerId: WHITC, OrderId: 10861}
    {CustomerId: WHITC, OrderId: 10904}
    {CustomerId: WHITC, OrderId: 11032}
    {CustomerId: WHITC, OrderId: 11066}

### linq19: SelectMany - Indexed
```csharp
//c#
public void Linq19() 
{ 
    var customers = GetCustomerList();

    var customerOrders =
            customers.SelectMany(
                (cust, custIndex) =>
                    cust.Orders.Select(o => $"Customer #{custIndex + 1}) has an order with OrderID {o.OrderID}"));

    ObjectDumper.Write(customerOrders);
}
```
```dart
//dart
linq19(){
  var customers = customersList(); 

  int custIndex = 0;
  var customerOrders = 
    customers.expand((cust){
      custIndex++;
      return cust.orders.map((o) => 
        "Customer #${custIndex} has an order with OrderID ${o.orderId}");
    }); 
    
  customerOrders.forEach(print);   
}
```
#### Output

    Customer #1 has an order with OrderID 10643
    Customer #1 has an order with OrderID 10692
    Customer #1 has an order with OrderID 10702
    Customer #1 has an order with OrderID 10835
    Customer #1 has an order with OrderID 10952
    Customer #1 has an order with OrderID 11011
    Customer #2 has an order with OrderID 10308
    Customer #2 has an order with OrderID 10625
    Customer #2 has an order with OrderID 10759
    Customer #2 has an order with OrderID 10926
    ...

LINQ - Partitioning Operators
-----------------------------

### linq20: Take - Simple
```csharp
//c#
public void Linq20() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var first3Numbers = numbers.Take(3);

    Console.WriteLine("First 3 numbers:");
    first3Numbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq20():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    first3_numbers = numbers[:3]

    print("First 3 numbers:")
    shared.printN(first3_numbers)
}
```
#### Output

    First 3 numbers:
    5
    4
    1

### linq21: Take - Nested
```csharp
//c#
public void Linq21()   
{ 
    var customers = GetCustomerList();

    var first3WAOrders = customers
        .Where(c => c.Region == "WA")
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Select(x => new { x.customer.CustomerID, x.order.OrderID, x.order.OrderDate })
        .Take(3);

    Console.WriteLine("First 3 orders in WA:");
    first3WAOrders.ForEach(ObjectDumper.Write);
}
```
```python
#python
linq21(){
  var customers = customersList(); 
  
  var first3WAOrders = customers
    .where((c) => c.region == "WA")
    .expand((c) => c.orders
      .map((o) => { 'CustomerId': c.customerId, 'OrderId':o.orderId, 'OrderDate':o.orderDate }))
    .take(3);
  
  print("First 3 orders in WA:");
  first3WAOrders.forEach(print);
}
```
#### Output

    First 3 orders in WA:
    {CustomerId: LAZYK, OrderId: 10482, OrderDate: 1997-03-21 00:00:00.000}
    {CustomerId: LAZYK, OrderId: 10545, OrderDate: 1997-05-22 00:00:00.000}
    {CustomerId: TRAIH, OrderId: 10574, OrderDate: 1997-06-19 00:00:00.000}


### linq22: Skip - Simple
```csharp
//c#
public void Linq22() 
{ 
    var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var allButFirst4Numbers = numbers.Skip(4);

    Console.WriteLine("All but first 4 numbers:");
    allButFirst4Numbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq22():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]
    all_but_first4_numbers = numbers[4:]

    print("All but first 4 numbers:")
    shared.printN(all_but_first4_numbers)
```
#### Output

    All but first 4 numbers:
    9
    8
    6
    7
    2
    0

### linq23: Skip - Nested
```csharp
//c#
public void Linq23()   
{ 
    var customers = GetCustomerList();

    var waOrders = customers
        .Where(c => c.Region == "WA")
        .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
        .Select(x => new { x.customer.CustomerID, x.order.OrderID, x.order.OrderDate });

    var allButFirst2Orders = waOrders.Skip(2);

    Console.WriteLine("All but first 2 orders in WA:");
    allButFirst2Orders.ForEach(ObjectDumper.Write);
}
```
```python
#python
def linq23():
    customers = shared.getCustomerList()

    wa_customers = filter(lambda c: c.Region == "WA", customers)
    wa_customer_orders = functions.select_many(wa_customers, "Orders")
    customer_orders = map(lambda x: SimpleNamespace(customer_id=x.item_a.CustomerID, order_id=x.item_b.OrderID, order_date=x.item_b.OrderDate), wa_customer_orders)

    all_but_first2 = list(customer_orders)[2:]

    print("All but first 2 orders in WA:");
    shared.print_namespace(all_but_first2)
```
#### Output

    All but first 2 orders in WA:
    {CustomerId: TRAIH, OrderId: 10574, OrderDate: 1997-06-19 00:00:00.000}
    {CustomerId: TRAIH, OrderId: 10577, OrderDate: 1997-06-23 00:00:00.000}
    {CustomerId: TRAIH, OrderId: 10822, OrderDate: 1998-01-08 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10269, OrderDate: 1996-07-31 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10344, OrderDate: 1996-11-01 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10469, OrderDate: 1997-03-10 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10483, OrderDate: 1997-03-24 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10504, OrderDate: 1997-04-11 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10596, OrderDate: 1997-07-11 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10693, OrderDate: 1997-10-06 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10696, OrderDate: 1997-10-08 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10723, OrderDate: 1997-10-30 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10740, OrderDate: 1997-11-13 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10861, OrderDate: 1998-01-30 00:00:00.000}
    {CustomerId: WHITC, OrderId: 10904, OrderDate: 1998-02-24 00:00:00.000}
    {CustomerId: WHITC, OrderId: 11032, OrderDate: 1998-04-17 00:00:00.000}
    {CustomerId: WHITC, OrderId: 11066, OrderDate: 1998-05-01 00:00:00.000}

### linq24: TakeWhile - Simple
```csharp
//c#
public void Linq24() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

    Console.WriteLine("First numbers less than 6:");
    firstNumbersLessThan6.ForEach(Console.WriteLine);
}
```
```python
#python
linq24(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var firstNumbersLessThan6 = numbers.takeWhile((n) => n < 6); 
  
  print("First numbers less than 6:"); 
  firstNumbersLessThan6.forEach(print);
}
```
#### Output

    First numbers less than 6:
    5
    4
    1
    3

### linq25: TakeWhile - Indexed
```csharp
//c#
public void Linq25() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

    Console.WriteLine("First numbers not less than their position:");
    firstSmallNumbers.ForEach(Console.WriteLine);
}
```
```python
#python
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
```
#### Output

    First numbers not less than their position:
    5
    4

### linq26: SkipWhile - Simple
```csharp
//c#
public void Linq26() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);

    Console.WriteLine("All elements starting from first element divisible by 3:");
    allButFirst3Numbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq26():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    all_but_first3_numbers = itertools.dropwhile(lambda n:  n % 3 != 0, numbers)

    print("All elements starting from first element divisible by 3:")
    shared.printN(all_but_first3_numbers)
```
#### Output

    All elements starting from first element divisible by 3:
    3
    9
    8
    6
    7
    2
    0

### linq27: SkipWhile - Indexed
```csharp
//c#
public void Linq27() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var laterNumbers = numbers.SkipWhile((n, index) => n >= index);

    Console.WriteLine("All elements starting from first element less than its position:");
    laterNumbers.ForEach(Console.WriteLine);
}
```
```python
#python
linq27(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  int index = 0;
  var laterNumbers = numbers.skipWhile((n) => n >= index++); 
  
  print("All elements starting from first element less than its position:"); 
  laterNumbers.forEach(print);
}
```
#### Output

    All elements starting from first element less than its position:
    1
    3
    9
    8
    6
    7
    2
    0


LINQ - Ordering Operators
-------------------------

### C# utils added

```csharp  
// No utils reuired, use built in comparer
StringComparer.CurrentCultureIgnoreCase
```

### Python utils added

```python

```

### linq28: OrderBy - Simple 1
```csharp
//c#
public void Linq28() 
{ 
    var words = new [] { "cherry", "apple", "blueberry" };

    var sortedWords = words.OrderBy(w => w);

    Console.WriteLine("The sorted list of words:");
    sortedWords.ForEach(Console.WriteLine);
}
```
```python
#python
linq28(){
  var words = [ "cherry", "apple", "blueberry" ]; 
  
  var sortedWords = order(words);
  
  print("The sorted list of words:"); 
  sortedWords.forEach(print);
}
```
#### Output

    The sorted list of words:
    apple
    blueberry
    cherry

### linq29: OrderBy - Simple 2
```csharp
//c#
public void Linq29() 
{ 
    var words = new [] { "cherry", "apple", "blueberry" };

    var sortedWords = words.OrderBy(w => w.Length);

    Console.WriteLine("The sorted list of words (by length):"); 
    sortedWords.ForEach(Console.WriteLine);
}
```
```python
#python
linq29(){
    words = ["cherry", "apple", "blueberry"]

    sorted_words = sorted(words, key=lambda x: len(x))

    print("The sorted list of words (by length):")
    shared.printS(sorted_words)
```
#### Output

    The sorted list of words (by length):
    apple
    cherry
    blueberry

### linq30: OrderBy - Simple 3
```csharp
//c#
public void Linq30() 
{ 
    var products = GetProductList();

    var sortedProducts = products.OrderBy(p => p.ProductName);

    ObjectDumper.Write(sortedProducts);
}
```
```python
#python
def linq30():
    products = shared.getProductList()

    sorted_products = sorted(products, key=lambda p:  p.ProductName)

    shared.print_namespace(sorted_products)
```
#### Output

    {productId: 17, productName: Alice Mutton, category: Meat/Poultry, unitPrice: 39.0, unitsInStock: 0}
    {productId: 3, productName: Aniseed Syrup, category: Condiments, unitPrice: 10.0, unitsInStock: 13}
    {productId: 40, productName: Boston Crab Meat, category: Seafood, unitPrice: 18.4, unitsInStock: 123}
    {productId: 60, productName: Camembert Pierrot, category: Dairy Products, unitPrice: 34.0, unitsInStock: 19}
    {productId: 18, productName: Carnarvon Tigers, category: Seafood, unitPrice: 62.5, unitsInStock: 42}
    ...

### linq31: OrderBy - Comparer
```csharp
//c#
public void Linq31() 
{ 
    var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 

    var sortedWords = words.OrderBy(a => a, StringComparer.CurrentCultureIgnoreCase); 

    ObjectDumper.Write(sortedWords); 
} 
```
```python
#python
def linq31():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda s: s.casefold())

    shared.printS(sorted_words)
```
#### Output

    AbAcUs
    aPPLE
    BlUeBeRrY
    bRaNcH
    cHeRry
    ClOvEr

### linq32: OrderByDescending - Simple 1
```csharp
//c#
public void Linq32() 
{ 
    var doubles = new[]{ 1.7, 2.3, 1.9, 4.1, 2.9 };

    var sortedDoubles = doubles.OrderByDescending(d => d);

    Console.WriteLine("The doubles from highest to lowest:");
    sortedDoubles.ForEach(Console.WriteLine);
}
```
```python
#python
def linq32():
    doubles = [1.7, 2.3, 1.9, 4.1, 2.9]

    sorted_doubles = sorted(doubles, reverse=True)

    print("The doubles from highest to lowest:")
    shared.printN(sorted_doubles)
```
#### Output

    The doubles from highest to lowest:
    4.1
    2.9
    2.3
    1.9
    1.7

### linq33: OrderByDescending - Simple 2
```csharp
//c#
public void Linq33() 
{ 
    var products = GetProductList();

    var sortedProducts = products.OrderByDescending(p => p.UnitsInStock);

    ObjectDumper.Write(sortedProducts);
}
```
```python
#python
def linq33():
    products = shared.getProductList()

    sorted_products = sorted(products, key=lambda p: p.UnitsInStock, reverse=True);

    shared.print_namespace(sorted_products)
```
#### Output

    {productId: 75, productName: Rh�nbr�u Klosterbier, category: Beverages, unitPrice: 7.75, unitsInStock: 125}
    {productId: 40, productName: Boston Crab Meat, category: Seafood, unitPrice: 18.4, unitsInStock: 123}
    {productId: 6, productName: Grandma's Boysenberry Spread, category: Condiments, unitPrice: 25.0, unitsInStock: 120}
    {productId: 55, productName: P�t� chinois, category: Meat/Poultry, unitPrice: 24.0, unitsInStock: 115}
    {productId: 61, productName: Sirop d'�rable, category: Condiments, unitPrice: 28.5, unitsInStock: 113}
    ...

### linq34: OrderByDescending - Comparer
```csharp
//c#
public void Linq34() 
{ 
    var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

    var sortedWords = words.OrderByDescending(a => a, StringComparer.CurrentCultureIgnoreCase); 

    ObjectDumper.Write(sortedWords);
} 
```
```python
#python
def linq34():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda s: s.casefold(), reverse=True);

    shared.print_namespace(sorted_words)
```
#### Output

    ClOvEr
    cHeRry
    bRaNcH
    BlUeBeRrY
    aPPLE
    AbAcUs

### linq35: ThenBy - Simple
```csharp
//c#
public void Linq35() 
{ 
    var digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var sortedDigits = digits
        .OrderBy(d => d.Length)
        .ThenBy(d => d);

    Console.WriteLine("Sorted digits:");
    sortedDigits.ForEach(Console.WriteLine);
}
```
```python
#python
def linq35():
    digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    sorted_digits = sorted(digits, key=lambda digit: (len(digit), digit))

    print("Sorted digits:")
    shared.printS(sorted_digits)
```
#### Output

    Sorted digits:
    one
    six
    two
    five
    four
    nine
    zero
    eight
    seven
    three

### linq36: ThenBy - Comparer
```csharp
//c#
public void Linq36() 
{ 
    var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

    var sortedWords = words
        .OrderBy(a => a.Length)
        .ThenBy(a => a, StringComparer.CurrentCultureIgnoreCase);

    ObjectDumper.Write(sortedWords);
} 
```
```python
#python
def linq36():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    sorted_words = sorted(words, key=lambda word: (len(word), word.casefold()))

    shared.print_namespace(sorted_words)
```
#### Output

    aPPLE
    AbAcUs
    bRaNcH
    cHeRry
    ClOvEr
    BlUeBeRrY

### linq37: ThenByDescending - Simple
```csharp
//c#
public void Linq37() 
{ 
    List<Product> products = GetProductList(); 

    var sortedProducts = products
        .OrderBy(p => p.Category)
        .ThenByDescending(p => p.UnitPrice);

    ObjectDumper.Write(sortedProducts); 
}
```
```python
#python
def linq37():
    products = shared.getProductList()

    # negate secondary sort because its a number for reverse order
    sorted_products = sorted(products, key=lambda product: (product.Category, -product.UnitPrice))

    shared.print_namespace(sorted_products)

```
#### Output

    {productId: 38, productName: C�te de Blaye, category: Beverages, unitPrice: 263.5, unitsInStock: 17}
    {productId: 43, productName: Ipoh Coffee, category: Beverages, unitPrice: 46.0, unitsInStock: 17}
    {productId: 2, productName: Chang, category: Beverages, unitPrice: 19.0, unitsInStock: 17}
    {productId: 76, productName: Lakkalik��ri, category: Beverages, unitPrice: 18.0, unitsInStock: 57}
    {productId: 39, productName: Chartreuse verte, category: Beverages, unitPrice: 18.0, unitsInStock: 69}
    {productId: 1, productName: Chai, category: Beverages, unitPrice: 18.0, unitsInStock: 39}
    {productId: 35, productName: Steeleye Stout, category: Beverages, unitPrice: 18.0, unitsInStock: 20}
    {productId: 70, productName: Outback Lager, category: Beverages, unitPrice: 15.0, unitsInStock: 15}
    {productId: 34, productName: Sasquatch Ale, category: Beverages, unitPrice: 14.0, unitsInStock: 111}
    ...

### linq38: ThenByDescending - Comparer
```csharp
//c#
public void Linq38() 
{ 
    var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

    var sortedWords = words
        .OrderBy(a => a.Length)
        .ThenByDescending(a => a, StringComparer.CurrentCultureIgnoreCase);

    ObjectDumper.Write(sortedWords);
} 
```
```python
#python
def linq38():
    words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"]

    # two pass sort, sort by least significant first
    sorted_words = sorted(words, key=lambda word: word.casefold(), reverse=True)
    sorted_words = sorted(sorted_words, key=lambda word: len(word))


    shared.printS(sorted_words)
}
```
#### Output

    aPPLE
    ClOvEr
    cHeRry
    bRaNcH
    AbAcUs
    BlUeBeRrY

### linq39: Reverse
```csharp
//c#
public void Linq39() 
{ 
    var digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var reversedIDigits = digits
        .Where(d => d[1] == 'i')
        .Reverse();

    Console.WriteLine("A backwards list of the digits with a second character of 'i':");
    reversedIDigits.ForEach(Console.WriteLine);
}
```
```python
#python
linq39(){
  var digits = [ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ]; 
  
  var reversedIDigits = digits
    .where((d) => d[1] == 'i')
    .toList()
    .reversed; 
  
  print("A backwards list of the digits with a second character of 'i':");
  reversedIDigits.forEach(print);
}
```
#### Output

    A backwards list of the digits with a second character of 'i':
    nine
    eight
    six
    five


LINQ - Grouping Operators
-------------------------

### C# utils added

```csharp
public class AnagramEqualityComparer : IEqualityComparer<string> 
{ 
    public bool Equals(string x, string y) 
    { 
        return getCanonicalString(x) == getCanonicalString(y); 
    } 
  
    public int GetHashCode(string obj) 
    { 
        return getCanonicalString(obj).GetHashCode(); 
    } 
  
    private string getCanonicalString(string word) 
    { 
        char[] wordChars = word.ToCharArray(); 
        Array.Sort<char>(wordChars); 
        return new string(wordChars); 
    } 
} 
```

### Dart utils added

```dart
anagramEqualityComparer(a, b) => 
  new String.fromCharCodes(orderBy(a.codeUnits.toList()))
  .compareTo(new String.fromCharCodes(orderBy(b.codeUnits.toList())));

List<Group> group(Iterable seq, {by(x):null, Comparator matchWith:null, valuesAs(x):null}){
  var ret = [];
  var map = new Map<dynamic, Group>();
  seq.forEach((x){
    var val = by(x);
    var key = matchWith != null
      ? map.keys.firstWhere((k) => matchWith(val, k) == 0, orElse:() => val)
      : val;
    
    if (!map.containsKey(key))
      map[key] = new Group(val);
    
    if (valuesAs != null)
      x = valuesAs(x);
    
    map[key].add(x);
  });
  return map.values.toList();
}

class Group extends IterableBase {
  var key;
  List _list;
  Group(this.key) : _list = [];

  get iterator => _list.iterator;
  void add(e) => _list.add(e);  
  get values => _list;
}
```

### linq40: GroupBy - Simple 1
```csharp
//c#
public void Linq40() 
{ 
    var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 

    var numberGroups = numbers
        .GroupBy(n => n % 5)
        .Select(x => new {Remainder = x.Key, Numbers = x});

    numberGroups.ForEach((g) => 
    {
        Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
        g.Numbers.ForEach(Console.WriteLine);
    });
}
```
```python
#python
def linq40():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    # First create a record of numbers and their modulus of 5
    number_remainders = map(lambda n: SimpleNamespace(Number=n, Remainder=n % 5), numbers)
    # Group By only works on sorted lists, so sort by both fields
    sorted_by_reminder = sorted(number_remainders, key=lambda x: (x.Remainder, x.Number))
    remainder_groups = groupby(sorted_by_reminder, key=lambda nr: nr.Remainder)

    for key, items in remainder_groups:
        print("Numbers with a remainder of %d when divided by 5:" % key)
        for item in items:
            print(item.Number)
```
#### Output

    Numbers with a remainder of 0 when divided by 5:
    5
    0
    Numbers with a remainder of 1 when divided by 5:
    1
    6
    Numbers with a remainder of 2 when divided by 5:
    7
    2
    Numbers with a remainder of 3 when divided by 5:
    3
    8
    Numbers with a remainder of 4 when divided by 5:
    4
    9

### linq41: GroupBy - Simple 2
```csharp
//c#
public void Linq41() 
{ 
    var words = new [] { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }; 

    var wordGroups = words
        .GroupBy(w => w[0])
        .Select(g => new { FirstLetter = g.Key, Words = g });

    wordGroups.ForEach((g) => 
    {
        Console.WriteLine($"Words that start with the letter '{g.FirstLetter}':");
        g.Words.ForEach(Console.WriteLine);
    });
}
```
```python
#python
def linq41():
    words = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"]

    first_letter_words = map(lambda w: SimpleNamespace(Letter=w[0], Word=w), words)
    # Group By only works on sorted lists, so sort by both fields
    sorted_letter_words = sorted(first_letter_words, key=lambda x: (x.Word, x.Letter))
    letter_groups = groupby(sorted_letter_words, key=lambda nr: nr.Letter)

    for key, items in letter_groups:
        print("Words that start with the letter '%s':" % key)
        for item in items:
            print(item.Word)
```
#### Output

    Words that start with the letter 'a':
    abacus
    apple
    Words that start with the letter 'b':
    banana
    blueberry
    Words that start with the letter 'c':
    cheese
    chimpanzee

### linq42: GroupBy - Simple 3
```csharp
//c#
public void Linq42() 
{ 
    var products = GetProductList(); 
    
    var orderGroups = products
        .GroupBy(p => p.Category)
        .Select(g => new { Category = g.Key, Products = g }); 

    ObjectDumper.Write(orderGroups, 1); 
} 
```
```python
#python
def linq42():
    products = shared.getProductList()

    # Group By only works on sorted lists, so sort by Category first, which is the grouping key
    sorted_by_category = sorted(products, key=lambda p: p.Category)
    order_groups = groupby(sorted_by_category, key=lambda p: p.Category)

    for key, items in order_groups:
        print("Products in the category '%s':" % key)
        print(list(items))
```
#### Output

/home/roger/PycharmProjects/untitled/venv/bin/python /home/roger/Projects/GitHub.Personal/python-linq-samples/src/python/linq-grouping.py
Products in the category 'Beverages':
[{productId: 1, productName: Chai, category: Beverages, unitPrice: 18.00, unitsInStock: 39}, {productId: 2, productName: Products in the category 'Condiments':
[{productId: 3, productName: Aniseed Syrup, category: Condiments, unitPrice: 10.00, unitsInStock: 13}, {productId: 4, Products in the category 'Confections':
[{productId: 16, productName: Pavlova, category: Confections, unitPrice: 17.45, unitsInStock: 29}, {productId: 19, Products in the category 'Dairy Products':
[{productId: 11, productName: Queso Cabrales, category: Dairy Products, unitPrice: 21.00, unitsInStock: 22}, {productId: Products in the category 'Grains/Cereals':
[{productId: 22, productName: Gustaf's Knäckebröd, category: Grains/Cereals, unitPrice: 21.00, unitsInStock: 104}, Products in the category 'Meat/Poultry':
[{productId: 9, productName: Mishi Kobe Niku, category: Meat/Poultry, unitPrice: 97.00, unitsInStock: 29}, {productId: 17,Products in the category 'Produce':
[{productId: 7, productName: Uncle Bob's Organic Dried Pears, category: Produce, unitPrice: 30.00, unitsInStock: 15}, Products in the category 'Seafood':
[{productId: 10, productName: Ikura, category: Seafood, unitPrice: 31.00, unitsInStock: 31}, {productId: 13, productName: 

### linq43: GroupBy - Nested
```csharp
//c#
public void Linq43() 
{ 
    var customers = GetCustomerList(); 

    var customerOrderGroups = customers
        .Select(c => new 
        {
            c.CompanyName,
            YearGroups = 
            (
                c.Orders
                    .GroupBy(y => y.OrderDate.Year)
                    .Select(YearGroup => new 
                    {
                        Year = YearGroup.Key,
                        MonthGroups = 
                        (
                            YearGroup
                            .GroupBy(m =>  m.OrderDate.Month)
                            .Select(MonthGroup => new
                            {
                                Month = MonthGroup.Key, Orders = MonthGroup
                            })

                        )
                    })
            )
        });
        
    ObjectDumper.Write(customerOrderGroups, 3); 
} 
```
```python
#python
def linq43():
    pass

```
#### Output

    {CompanyName: Alfreds Futterkiste, YearGroups: {{Year: 1997, MonthGroups: {{Month: 8, Orders: {{orderId: 10643, orderDate: 1997-08-25 00:00:00.000, total: 814.5}}}, {Month: 10, Orders: {{orderId: 10692, orderDate: 1997-10-03 00:00:00.000, total: 878.0}, {orderId: 10702, orderDate: 1997-10-13 00:00:00.000, total: 330.0}}}}}, {Year: 1998, MonthGroups: {{Month: 1, Orders: {{orderId: 10835, orderDate: 1998-01-15 00:00:00.000, total: 845.8}}}, {Month: 3, Orders: {{orderId: 10952, orderDate: 1998-03-16 00:00:00.000, total: 471.2}}}, {Month: 4, Orders: {{orderId: 11011, orderDate: 1998-04-09 00:00:00.000, total: 933.5}}}}}}}
    {CompanyName: Ana Trujillo Emparedados y helados, YearGroups: {{Year: 1996, MonthGroups: {{Month: 9, Orders: {{orderId: 10308, orderDate: 1996-09-18 00:00:00.000, total: 88.8}}}}}, {Year: 1997, MonthGroups: {{Month: 8, Orders: {{orderId: 10625, orderDate: 1997-08-08 00:00:00.000, total: 479.75}}}, {Month: 11, Orders: {{orderId: 10759, orderDate: 1997-11-28 00:00:00.000, total: 320.0}}}}}, {Year: 1998, MonthGroups: {{Month: 3, Orders: {{orderId: 10926, orderDate: 1998-03-04 00:00:00.000, total: 514.4}}}}}}}

### linq44: GroupBy - Comparer
```csharp
//c#
public void Linq44() 
{ 
    var anagrams = new [] { "from    ", " salt", " earn ", "  last   ", " near ", " form  " }; 
    var orderGroups = anagrams
        .GroupBy(w => w.Trim(), new AnagramEqualityComparer());

    ObjectDumper.Write(orderGroups, 1); 
} 
```
```python
#python
def linq44():
    pass
```
#### Output

    [ salt,   last   ]
    [ earn ,  near ]
    [from   ,  form  ]

### linq45: GroupBy - Comparer, Mapped    
```csharp
//c#
public void Linq45() 
{ 
    var anagrams = new [] { "from   ", " salt", " earn ", "  last   ", " near ", " form  " }; 

    var orderGroups = anagrams.GroupBy( 
                w => w.Trim(),
                a => a.ToUpper(), 
                new AnagramEqualityComparer() 
                ); 

    ObjectDumper.Write(orderGroups, 1); 
} 
```
```python
#python
def linq45():
    pass
```
#### Output

    [ SALT,   LAST   ]
    [ EARN ,  NEAR ]
    [FROM   ,  FORM  ]


LINQ - Set Operators
--------------------

### linq46: Distinct - 1
```csharp
//c#
public void Linq46() 
{ 
    int[] factorsOf300 = { 2, 2, 3, 5, 5 };

    var uniqueFactors = factorsOf300.Distinct();

    Console.WriteLine("Prime factors of 300:");
    uniqueFactors.ForEach(Console.WriteLine); 
}
```
```python
#python
def linq46():
    factors_of300 = [2, 2, 3, 5, 5]

    unique_factors = set(factors_of300)

    shared.printN(unique_factors)
```
#### Output

    Prime factors of 300:
    2
    3
    5

### linq47: Distinct - 2
```csharp
//c#
public void Linq47() 
{ 
    var products = GetProductList();

    var categoryNames = products
        .Select(p => p.Category)
        .Distinct();

    Console.WriteLine("Category names:");
    categoryNames.ForEach(Console.WriteLine);
}
```
```python
#python
def linq47():
    products = shared.getProductList()

    category_names = set(map(lambda p: p.Category, products))

    print("Category names:")
    shared.printS(category_names)
```
#### Output

    Category names:
    Dairy Products
    Grains/Cereals
    Confections
    Seafood
    Condiments
    Meat/Poultry
    Produce
    Beverages

### linq48: Union - 1
```csharp
//c#
public void Linq48() 
{ 
    int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
    int[] numbersB = { 1, 3, 5, 7, 8 };

    var uniqueNumbers = numbersA.Union(numbersB);

    Console.WriteLine("Unique numbers from both arrays:");
    uniqueNumbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq48():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    unique_numbers = set(numbers_a + numbers_b)

    print("Unique numbers from both arrays:")
    shared.printN(unique_numbers)
```
#### Output

    Unique numbers from both arrays:
    0
    1
    2
    3
    4
    5
    6
    7
    8
    9

### linq49: Union - 2
```csharp
//c#
public void Linq49() 
{ 
    var products = GetProductList();
    var customers = GetCustomerList();

    var productFirstChars = products
        .Select(p => p.ProductName[0]);
    var customerFirstChars = customers
        .Select(c => c.CompanyName[0]);

    var uniqueFirstChars = productFirstChars.Union(customerFirstChars);

    Console.WriteLine("Unique first letters from Product names and Customer names:");
    uniqueFirstChars.ForEach(Console.WriteLine);
}
```
```python
#python
def linq49():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).union(set(customer_first_chars))

    print("Unique first letters from Product names and Customer names:")
    shared.printS(unique_first_chars)
```
#### Output

    Unique first letters from Product names and Customer names:
    S
    F
    T
    N
    K
    E
    V
    Z
    Q
    M
    C
    L
    A
    J
    W
    P
    B
    O
    H
    D
    R
    I
    G
    U

### linq50: Intersect - 1
```csharp
//c#
public void Linq50() 
{ 
    int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
    int[] numbersB = { 1, 3, 5, 7, 8 };

    var commonNumbers = numbersA.Intersect(numbersB);

    Console.WriteLine("Common numbers shared by both arrays:");
    commonNumbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq50():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    common_numbers = set(numbers_a).intersection((set(numbers_b)))

    print("Common numbers shared by both arrays:")
    shared.printN(common_numbers)
```
#### Output

    Common numbers shared by both arrays:
    8
    5

### linq51: Intersect - 2
```csharp
//c#
public void Linq51() 
{ 
    var products = GetProductList();
    var customers = GetCustomerList();

    var productFirstChars = products
        .Select(p => p.ProductName[0]);
    var customerFirstChars = customers
        .Select(c => c.CompanyName[0]);

    var commonFirstChars = productFirstChars.Intersect(customerFirstChars)

    Console.WriteLine("Common first letters from Product names and Customer names:");
    commonFirstChars.ForEach(Console.WriteLine);
}
```
```python
#python
def linq51():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).intersection(set(customer_first_chars))

    print("Common first letters from Product names and Customer names:")
    shared.printS(unique_first_chars)
```
#### Output

    Common first letters from Product names and Customer names:
    F
    S
    T
    N
    K
    E
    V
    Q
    M
    C
    L
    A
    O
    W
    P
    B
    I
    G
    R

### linq52: Except - 1
```csharp
//c#
public void Linq52() 
{ 
    int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
    int[] numbersB = { 1, 3, 5, 7, 8 };

    var aOnlyNumbers = numbersA.Except(numbersB);

    Console.WriteLine("Numbers in first array but not second array:");
    aOnlyNumbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq52():
    numbers_a = [0, 2, 4, 5, 6, 8, 9]
    numbers_b = [1, 3, 5, 7, 8]

    a_only_numbers = set(numbers_a).difference((set(numbers_b)))

    print("Numbers in first array but not second array:")
    shared.printN(a_only_numbers)
```
#### Output

    Numbers in first array but not second array:
    0
    9
    2
    4
    6

### linq53: Except - 2
```csharp
//c#
public void Linq53() 
{ 
    var products = GetProductList();
    var customers = GetCustomerList();

    var productFirstChars = products
        .Select(p => p.ProductName[0]);
    var customerFirstChars = customers
        .Select(c => c.CompanyName[0]);

    var productOnlyFirstChars = productFirstChars.Except(customerFirstChars);

    Console.WriteLine("First letters from Product names, but not from Customer names:");
    productOnlyFirstChars.ForEach(Console.WriteLine);
}
```
```python
#python
def linq53():
    products = shared.getProductList()
    customers = shared.getCustomerList()

    product_first_chars = map(lambda p: p.ProductName[0], products)
    customer_first_chars = map(lambda c: c.CompanyName[0], customers)

    unique_first_chars = set(product_first_chars).difference(set(customer_first_chars))

    print("First letters from Product names, but not from Customer names:")
    shared.printS(unique_first_chars)
```
#### Output

    First letters from Product names, but not from Customer names:
    Z
    J
    U


LINQ - Conversion Operators
---------------------------

### linq54: ToArray
```csharp
//c#
public void Linq54() 
{ 
    double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

    var sortedDoubles = doubles.OrderByDescending(d => d);
        
    var doublesArray = sortedDoubles.ToArray();

    Console.WriteLine("Every other double from highest to lowest:");
    for (int d = 0; d < doublesArray.Length; d += 2)
    {
        Console.WriteLine(doublesArray[d]);
    }
}
```
```python
#python
def linq54():
    doubles = [ 1.7, 2.3, 1.9, 4.1, 2.9 ]
  
    sorted_doubles = sorted(doubles, reverse=True)

    doubles_array = list(sorted_doubles)
  
    print("Every other double from highest to lowest:")
    d = 0
    while d < len(doubles_array):
        print(doubles_array[d])
        d += 2
```
#### Output

    Every other double from highest to lowest:
    4.1
    2.3
    1.7

### linq55: ToList
```csharp
//c#
public void Linq55() 
{ 
    string[] words = { "cherry", "apple", "blueberry" };

    var sortedWords = words.OrderBy(x => x);

    var wordList = sortedWords.ToList();

    Console.WriteLine("The sorted word list:");
    wordList.ForEach(Console.WriteLine);
}
```
```python
#python
def  linq55():
    words = ["cherry", "apple", "blueberry"]

    sorted_words = sorted(words)

    word_list = list(sorted_words)

    print("The sorted word list:")
    shared.printN(word_list)
```
#### Output

    The sorted word list:
    apple
    blueberry
    cherry

### linq56: ToDictionary
```csharp
//c#
public void Linq56() 
{ 
    var scoreRecords = new[] 
    { 
        new {Name = "Alice", Score = 50},
        new {Name = "Bob"  , Score = 40},
        new {Name = "Cathy", Score = 45}
    };

    var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

    Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
}
```
```python
#python
def linq56():
    score_records = [{'Name': "Alice", 'Score': 50},
                    {'Name': "Bob", 'Score': 40},
                    {'Name': "Cathy", 'Score': 45}]

    index = map(lambda s: s["Name"], score_records)

    score_records_dict = dict(zip(index, score_records))

    print("Bob's score: %s" % score_records_dict["Bob"])
```
#### Output

    Bob's score: {Name: Bob, Score: 40}

### linq57: OfType    
```csharp
//c#
public void Linq57() 
{ 
    object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

    var doubles = numbers.OfType<double>();

    Console.WriteLine("Numbers stored as doubles:");
    doubles.ForEach(Console.WriteLine);
}
```
```python
#python
def linq57():
    numbers = [None, 1.0, "two", 3, "four", 5, "six", 7.0]

    floats = filter(lambda n: isinstance(n, float), numbers)

    print("Numbers stored as floats:")
    shared.printN(floats)
```
#### Output

    Numbers stored as doubles:
    1.0
    7.0


LINQ - Element Operators
------------------------

### linq58: First - Simple
```csharp
//c#
public void Linq58() 
{ 
    var products = GetProductList();

    var product12 = products
        .Where(p => p.ProductID == 12)
        .First();

    ObjectDumper.Write(product12);
}
```
```python
#python
def linq58():
    products = shared.getProductList()

    product_12 = next(filter(lambda p: p.ProductID == 12, products))

    print(product_12)
```
#### Output

    {productId: 12, productName: Queso Manchego La Pastora, category: Dairy Products, unitPrice: 38.0, unitsInStock: 86}

### linq59: First - Condition
```csharp
//c#
public void Linq59() 
{ 
    var strings = new []{ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    var startsWithO = strings.First(s => s.StartsWith('o'));

    Console.WriteLine("A string starting with 'o': {0}", startsWithO);
}
```
```python
#python
def linq59():
    strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]

    starts_with_o = next(filter(lambda s: s[0] == 'o', strings))

    print("A string starting with 'o': %s" % starts_with_o)
```
#### Output

    A string starting with 'o': one

### linq61: FirstOrDefault - Simple
```csharp
//c#
public void Linq61() 
{ 
    var numbers = new int[0];

    var firstNumOrDefault = numbers.FirstOrDefault();

    Console.WriteLine(firstNumOrDefault);
}
```
```python
#python
def linq61():
    numbers = []

    first_num_or_default = next(filter(lambda x: true, numbers), 0)

    print(first_num_or_default)
```
#### Output

    0

### linq62: FirstOrDefault - Condition
```csharp
//c#
public void Linq62() 
{ 
    var products = GetProductList();

    var product789 = products.FirstOrDefault(p => p.ProductID == 789);

    Console.WriteLine("Product 789 exists: {0}", product789 != null);
}
```
```python
#python
def linq62():
    products = shared.getProductList()

    product789 = next(filter(lambda p: p.ProductID == 789, products), None)

    print("Product 789 exists: %s" % (product789 is not None))
```
#### Output

    Product 789 exists: false

### linq64: ElementAt
```csharp
//c#
public void Linq64() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var fourthLowNum = numbers
        .Where(num => num > 5)
        .ElementAt(1);

    Console.WriteLine("Second number > 5: {0}", fourthLowNum);
}
```
```python
#python
def linq64():
    numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0]

    fourth_low_num = list(filter(lambda n: n > 5, numbers))[1]

    print("Second number > 5: %d" % fourth_low_num)
```
#### Output

    Second number > 5: 8


LINQ - Generation Operators
---------------------------

### linq65: Range
```csharp
//c#
public void Linq65() 
{ 
    var numbers = Enumerable.Range(100, 50)
        .Select(n => new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" });

    numbers.ForEach((n) => Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven));

}
```
```python
#python
def linq65():
    numbers = range(100, 150)

    odd_even = map(lambda n: {'Number': n, 'OddEven': ("odd" if (n % 2 == 1) else "even")}, numbers)

    for item in odd_even:
        print("The number %s is %s" % (item['Number'], item['OddEven']))
```
#### Output

    The number 100 is even.
    The number 101 is odd.
    The number 102 is even.
    The number 103 is odd.
    The number 104 is even.
    The number 105 is odd.
    The number 106 is even.
    The number 107 is odd.
    The number 108 is even.
    The number 109 is odd.
    The number 110 is even.
    ...

### linq66: Repeat
```csharp
//c#
public void Linq66() 
{ 
    var numbers = Enumerable.Repeat(7, 10);

    numbers.ForEach(Console.WriteLine);
}
```
```python
#python
def linq66():
    numbers = itertools.repeat(7, 10)

    shared.printN(numbers)
```
#### Output

    7
    7
    7
    7
    7
    7
    7
    7
    7
    7


LINQ - Quantifiers
------------------

### linq67: Any - Simple
```csharp
//c#
public void Linq67() 
{ 
    var words = new []{ "believe", "relief", "receipt", "field" };

    var iAfterE = words.Any(w => w.Contains("ei"));

    Console.WriteLine($"There is a word in the list that contains 'ei': {iAfterE}");
}
```
```python
#python
def linq67():
    words = ["believe", "relief", "receipt", "field"]

    i_after_e = any("ei" in w for w in words)

    print("There is a word that contains in the list that contains 'ei': %s" % i_after_e)
```
#### Output

    There is a word that contains in the list that contains 'ei': true

### linq69: Any - Grouped
```csharp
//c#
public void Linq69() 
{ 
    var products = GetProductList();

    var productGroups = products
        .GroupBy(prod => prod.Category)
        .Where(prodGroup => prodGroup.Any(p => p.UnitsInStock == 0))
        .Select(prodGroup => new { Category = prodGroup.Key, Products = prodGroup });

    ObjectDumper.Write(productGroups, 1);
}
```
```python
#python
def linq69():
    pass

```
#### Output

    {Category: Condiments, Products: {{productId: 3, productName: Aniseed Syrup, category: Condiments, unitPrice: 10.0, unitsInStock: 13}, {productId: 4, productName: Chef Anton's Cajun Seasoning, category: Condiments, unitPrice: 22.0, unitsInStock: 53}, {productId: 5, productName: Chef Anton's Gumbo Mix, category: Condiments, unitPrice: 21.35, unitsInStock: 0}, {productId: 6, productName: Grandma's Boysenberry Spread, category: Condiments, unitPrice: 25.0, unitsInStock: 120}, {productId: 8, productName: Northwoods Cranberry Sauce, category: Condiments, unitPrice: 40.0, unitsInStock: 6}, {productId: 15, productName: Genen Shouyu, category: Condiments, unitPrice: 15.5, unitsInStock: 39}, {productId: 44, productName: Gula Malacca, category: Condiments, unitPrice: 19.45, unitsInStock: 27}, {productId: 61, productName: Sirop d'�rable, category: Condiments, unitPrice: 28.5, unitsInStock: 113}, {productId: 63, productName: Vegie-spread, category: Condiments, unitPrice: 43.9, unitsInStock: 24}, {productId: 65, productName: Louisiana Fiery Hot Pepper Sauce, category: Condiments, unitPrice: 21.05, unitsInStock: 76}, {productId: 66, productName: Louisiana Hot Spiced Okra, category: Condiments, unitPrice: 17.0, unitsInStock: 4}, {productId: 77, productName: Original Frankfurter gr�ne So�e, category: Condiments, unitPrice: 13.0, unitsInStock: 32}}}
    ...

### linq70: All - Simple
```csharp
//c#
public void Linq70() 
{  
    var numbers = new [] { 1, 11, 3, 19, 41, 65, 19 };

    var onlyOdd = numbers.All(n => n % 2 == 1);

    Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
}
```
```python
#python
def linq70():
    numbers = [1, 11, 3, 19, 41, 65, 19]

    only_odd = all(n % 2 == 1 for n in numbers)

    print("The list contains only odd numbers: %s" % only_odd)
```
#### Output

    The list contains only odd numbers: true

### linq72: All - Grouped    
```csharp
//c#
public void Linq72() 
{ 
    var products = GetProductList();

    var productGroups = products
        .GroupBy(prod => prod.Category)
        .Where(prodGroup => prodGroup.All(p => p.UnitsInStock > 0))
        .Select(prodGroup => new { Category = prodGroup.Key, Products = prodGroup });

    ObjectDumper.Write(productGroups, 1);
}
```
```python
#python
def linq72():
    pass
```
#### Output

    {Category: Grains/Cereals, Products: {{productId: 22, productName: Gustaf's Kn�ckebr�d, category: Grains/Cereals, unitPrice: 21.0, unitsInStock: 104}, {productId: 23, productName: Tunnbr�d, category: Grains/Cereals, unitPrice: 9.0, unitsInStock: 61}, {productId: 42, productName: Singaporean Hokkien Fried Mee, category: Grains/Cereals, unitPrice: 14.0, unitsInStock: 26}, {productId: 52, productName: Filo Mix, category: Grains/Cereals, unitPrice: 7.0, unitsInStock: 38}, {productId: 56, productName: Gnocchi di nonna Alice, category: Grains/Cereals, unitPrice: 38.0, unitsInStock: 21}, {productId: 57, productName: Ravioli Angelo, category: Grains/Cereals, unitPrice: 19.5, unitsInStock: 36}, {productId: 64, productName: Wimmers gute Semmelkn�del, category: Grains/Cereals, unitPrice: 33.25, unitsInStock: 22}}}
    ...


LINQ - Aggregate Operators
--------------------------

### Dart utils added

```dart
sum(Iterable seq, [fn(x)]) =>
  seq.fold(0, (prev, element) => prev + (fn != null ? fn(element) : element));

min(Iterable seq) =>
  seq.fold(double.MAX_FINITE, (prev, element) => prev.compareTo(element) > 0 ? element : prev);

max(Iterable seq) =>
  seq.fold(double.MIN_POSITIVE, (prev, element) => prev.compareTo(element) > 0 ? prev : element);

avg(Iterable seq) => sum(seq) / seq.length;
```

### linq73: Count - Simple
```csharp
//c#
public void Linq73() 
{ 
    var primeFactorsOf300 = new [] { 2, 2, 3, 5, 5 };

    var uniqueFactors = primeFactorsOf300.Distinct().Count();

    Console.WriteLine($"There are {uniqueFactors} unique prime factors of 300.");
}
```
```dart
//dart
linq73(){
  var factorsOf300 = [ 2, 2, 3, 5, 5 ]; 
  
  int uniqueFactors = factorsOf300.toSet().length; 
  
  print("There are $uniqueFactors unique factors of 300."); 
}
```
#### Output

    There are 3 unique factors of 300.

### linq74: Count - Conditional
```csharp
//c#
public void Linq74() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var oddNumbers = numbers.Count(n => n % 2 == 1);

    Console.WriteLine($"There are {oddNumbers} odd numbers in the list.");
}
```
```dart
//dart
linq74(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  int oddNumbers = numbers.where((n) => n % 2 == 1).length; 
  
  print("There are $oddNumbers odd numbers in the list."); 
}
```
#### Output

    There are 5 odd numbers in the list.

### linq76: Count - Nested
```csharp
//c#
public void Linq76() 
{ 
    var customers = GetCustomerList();

    var orderCounts = customers
        .Select(cust => new { cust.CustomerID, OrderCount = cust.Orders.Count() });

    ObjectDumper.Write(orderCounts);
}
```
```dart
//dart
linq76(){
  var customers = customersList(); 
  
  var orderCounts = customers
    .map((c) => { 'CustomerId': c.customerId, 'OrderCount': c.orders.length }); 

  orderCounts.forEach(print);
}
```
#### Output

    {CustomerId: ALFKI, OrderCount: 6}
    {CustomerId: ANATR, OrderCount: 4}
    {CustomerId: ANTON, OrderCount: 7}
    {CustomerId: AROUT, OrderCount: 13}
    {CustomerId: BERGS, OrderCount: 18}
    {CustomerId: BLAUS, OrderCount: 7}
    {CustomerId: BLONP, OrderCount: 11}
    ...

### linq77: Count - Grouped
```csharp
//c#
public void Linq77() 
{ 
    var products = GetProductList();

    var categoryCounts = products
        .GroupBy(prod => prod.Category)
        .Select(prodGroup => new { Category = prodGroup.Key, ProductCount = prodGroup.Count() });

    ObjectDumper.Write(categoryCounts);
}
```
```dart
//dart
linq77(){
  var products = productsList(); 
  
  var categoryCounts = group(products, by:(p) => p.category)
    .map((g) => { 'Category': g.key, 'ProductCount': g.length });      

  categoryCounts.forEach(print);
}
```
#### Output

    {Category: Dairy Products, ProductCount: 10}
    {Category: Grains/Cereals, ProductCount: 7}
    {Category: Confections, ProductCount: 13}
    {Category: Seafood, ProductCount: 12}
    {Category: Condiments, ProductCount: 12}
    {Category: Meat/Poultry, ProductCount: 6}
    {Category: Produce, ProductCount: 5}
    {Category: Beverages, ProductCount: 12}

### linq78: Sum - Simple
```csharp
//c#
public void Linq78() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var numSum = numbers.Sum();

    Console.WriteLine($"The sum of the numbers is {numSum}.");
}
```
```dart
//dart
linq78(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var numSum = sum(numbers); 
  
  print("The sum of the numbers is $numSum."); 
}
```
#### Output

    The sum of the numbers is 45.

### linq79: Sum - Projection
```csharp
//c#
public void Linq79() 
{ 
    var  words = new [] { "cherry", "apple", "blueberry" };

    var totalChars = words.Sum(w => w.Length);

    Console.WriteLine($"There are a total of {totalChars} characters in these words.");
}
```
```dart
//dart
linq79(){
  var words = [ "cherry", "apple", "blueberry" ]; 
  
  var totalChars = sum(words, (w) => w.length); 
  
  print("There are a total of $totalChars characters in these words.");
}
```
#### Output

    There are a total of 20 characters in these words.

### linq80: Sum - Grouped
```csharp
//c#
public void Linq80() 
{ 
    var products = GetProductList();

    var categories = products
        .GroupBy(prod => prod.Category)
        .Select(prodGroup => new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock) });

    ObjectDumper.Write(categories);
}
```
```dart
//dart
linq80(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g) => { 'Category': g.key, 'TotalUnitsInStock': sum(g.values, (p) => p.unitsInStock) }); 
      
  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, TotalUnitsInStock: 393}
    {Category: Grains/Cereals, TotalUnitsInStock: 308}
    {Category: Confections, TotalUnitsInStock: 386}
    {Category: Seafood, TotalUnitsInStock: 701}
    {Category: Condiments, TotalUnitsInStock: 507}
    {Category: Meat/Poultry, TotalUnitsInStock: 165}
    {Category: Produce, TotalUnitsInStock: 100}
    {Category: Beverages, TotalUnitsInStock: 559}

### linq81: Min - Simple
```csharp
//c#
public void Linq81() 
{ 
    var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var minNum = numbers.Min();

    Console.WriteLine($"The minimum number is {minNum}.");
}
```
```dart
//dart
linq81(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  int minNum = min(numbers); 
  
  print("The minimum number is $minNum.");
}
```
#### Output

    The minimum number is 0.

### linq82: Min - Projection
```csharp
//c#
public void Linq82() 
{ 
    var words = new [] { "cherry", "apple", "blueberry" };

    var shortestWord = words.Min(w => w.Length);

    Console.WriteLine($"The shortest word is {shortestWord} characters long.");
}
```
```dart
//dart
linq82(){
  var words = [ "cherry", "apple", "blueberry" ]; 
  
  var shortestWord = min(words.map((x) => x.length));
  
  print("The shortest word is $shortestWord characters long."); 
}
```
#### Output

    The shortest word is 5 characters long.

### linq83: Min - Grouped
```csharp
//c#
public void Linq83() 
{ 
    var products = GetProductList();

    var categories = products
        .GroupBy(prod => prod.Category)
        .Select(prodGroup => new { Category = prodGroup.Key, CheapestPrice = prodGroup.Min(p => p.UnitPrice) });

    ObjectDumper.Write(categories);
}
```
```dart
//dart
linq83(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g) => { 'Category': g.key, 'CheapestPrice': min(g.values.map((p) => p.unitPrice)) });

  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, CheapestPrice: 2.5}
    {Category: Grains/Cereals, CheapestPrice: 7.0}
    {Category: Confections, CheapestPrice: 9.2}
    {Category: Seafood, CheapestPrice: 6.0}
    {Category: Condiments, CheapestPrice: 10.0}
    {Category: Meat/Poultry, CheapestPrice: 7.45}
    {Category: Produce, CheapestPrice: 10.0}
    {Category: Beverages, CheapestPrice: 4.5}

### linq84: Min - Elements
```csharp
//c#
public void Linq84() 
{ 
    var products = GetProductList();

    var categories = products.GroupBy(prod => prod.Category)
        .Select(prodGroup => new {prodGroup, minPrice = prodGroup.Min(p => p.UnitPrice)})
        .Select(x => new
        {
            Category = x.prodGroup.Key,
            CheapestProducts = x.prodGroup.Where(p => p.UnitPrice == x.minPrice)
        });

    ObjectDumper.Write(categories, 1);
}
```
```dart
//dart
linq84(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g){
      var minPrice = min(g.values.map((p) => p.unitPrice));
      return { 'Category': g.key, 'CheapestProducts': g.values.where((p) => p.unitPrice == minPrice) };
    });

  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, CheapestProducts: {{productId: 33, productName: Geitost, category: Dairy Products, unitPrice: 2.5, unitsInStock: 112}}}
    {Category: Grains/Cereals, CheapestProducts: {{productId: 52, productName: Filo Mix, category: Grains/Cereals, unitPrice: 7.0, unitsInStock: 38}}}
    {Category: Confections, CheapestProducts: {{productId: 19, productName: Teatime Chocolate Biscuits, category: Confections, unitPrice: 9.2, unitsInStock: 25}}}
    {Category: Seafood, CheapestProducts: {{productId: 13, productName: Konbu, category: Seafood, unitPrice: 6.0, unitsInStock: 24}}}
    {Category: Condiments, CheapestProducts: {{productId: 3, productName: Aniseed Syrup, category: Condiments, unitPrice: 10.0, unitsInStock: 13}}}
    {Category: Meat/Poultry, CheapestProducts: {{productId: 54, productName: Tourti�re, category: Meat/Poultry, unitPrice: 7.45, unitsInStock: 21}}}
    {Category: Produce, CheapestProducts: {{productId: 74, productName: Longlife Tofu, category: Produce, unitPrice: 10.0, unitsInStock: 4}}}
    {Category: Beverages, CheapestProducts: {{productId: 24, productName: Guaran� Fant�stica, category: Beverages, unitPrice: 4.5, unitsInStock: 20}}}

### linq85: Max - Simple
```csharp
//c#
public void Linq85() 
{ 
    var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var maxNum = numbers.Max();

    Console.WriteLine($"The maximum number is {maxNum}.");
}
```
```dart
//dart
linq85(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var maxNum = max(numbers); 
  
  print("The maximum number is $maxNum."); 
}
```
#### Output

    The maximum number is 9.

### linq86: Max - Projection
```csharp
//c#
public void Linq86() 
{ 
    var words = new [] { "cherry", "apple", "blueberry" };

    var longestLength = words.Max(w => w.Length);

    Console.WriteLine($"The longest word is {longestLength} characters long.");}
```
```dart
//dart
linq86(){
  var words = [ "cherry", "apple", "blueberry" ]; 
  
  int longestLength = max(words.map((w) => w.length)); 
  
  print("The longest word is $longestLength characters long."); 
}
```
#### Output

    The longest word is 9 characters long.

### linq87: Max - Grouped
```csharp
//c#
public void Linq87() 
{ 
    var products = GetProductList();

    var categories = products
        .GroupBy(prod => prod.Category)
        .Select(prodGroup => new { Category = prodGroup.Key, MostExpensivePrice = prodGroup.Max(p => p.UnitPrice) });

    ObjectDumper.Write(categories);
}
```
```dart
//dart
linq87(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g) => { 'Category': g.key, 'MostExpensivePrice': max(g.values.map((p) => p.unitPrice)) });      

  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, MostExpensivePrice: 55.0}
    {Category: Grains/Cereals, MostExpensivePrice: 38.0}
    {Category: Confections, MostExpensivePrice: 81.0}
    {Category: Seafood, MostExpensivePrice: 62.5}
    {Category: Condiments, MostExpensivePrice: 43.9}
    {Category: Meat/Poultry, MostExpensivePrice: 123.79}
    {Category: Produce, MostExpensivePrice: 53.0}
    {Category: Beverages, MostExpensivePrice: 263.5}

### linq88: Max - Elements
```csharp
//c#
public void Linq88() 
{ 
    var products = GetProductList();

    var categories = products.GroupBy(prod => prod.Category)
        .Select(prodGroup => new {prodGroup, maxPrice = prodGroup.Max(p => p.UnitPrice)})
        .Select(x => new
        {
            Category = x.prodGroup.Key,
            MostExpensiveProducts = x.prodGroup.Where(p => p.UnitPrice == x.maxPrice)
        });

    ObjectDumper.Write(categories, 1);
}
```
```dart
//dart
linq88(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g){
      var maxPrice = max(g.values.map((p) => p.unitPrice));
      return { 'Category': g.key, 'MostExpensiveProducts': g.values.where((p) => p.unitPrice == maxPrice) };
    });

  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, MostExpensiveProducts: {{productId: 59, productName: Raclette Courdavault, category: Dairy Products, unitPrice: 55.0, unitsInStock: 79}}}
    {Category: Grains/Cereals, MostExpensiveProducts: {{productId: 56, productName: Gnocchi di nonna Alice, category: Grains/Cereals, unitPrice: 38.0, unitsInStock: 21}}}
    {Category: Confections, MostExpensiveProducts: {{productId: 20, productName: Sir Rodney's Marmalade, category: Confections, unitPrice: 81.0, unitsInStock: 40}}}
    {Category: Seafood, MostExpensiveProducts: {{productId: 18, productName: Carnarvon Tigers, category: Seafood, unitPrice: 62.5, unitsInStock: 42}}}
    {Category: Condiments, MostExpensiveProducts: {{productId: 63, productName: Vegie-spread, category: Condiments, unitPrice: 43.9, unitsInStock: 24}}}
    {Category: Meat/Poultry, MostExpensiveProducts: {{productId: 29, productName: Th�ringer Rostbratwurst, category: Meat/Poultry, unitPrice: 123.79, unitsInStock: 0}}}
    {Category: Produce, MostExpensiveProducts: {{productId: 51, productName: Manjimup Dried Apples, category: Produce, unitPrice: 53.0, unitsInStock: 20}}}
    {Category: Beverages, MostExpensiveProducts: {{productId: 38, productName: C�te de Blaye, category: Beverages, unitPrice: 263.5, unitsInStock: 17}}}

### linq89: Average - Simple
```csharp
//c#
public void Linq89() 
{ 
    var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    var averageNum = numbers.Average();

    Console.WriteLine($"The average number is {averageNum}.");
}
```
```dart
//dart
linq89(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var averageNum = avg(numbers); 
  
  print("The average number is $averageNum.");
}
```
#### Output

    The average number is 4.5.

### linq90: Average - Projection
```csharp
//c#
public void Linq90() 
{ 
    var words = new [] { "cherry", "apple", "blueberry" };

    var averageLength = words.Average(w => w.Length);

    Console.WriteLine($"The average word length is {averageLength} characters.");
}
```
```dart
//dart
linq90(){
  var words = [ "cherry", "apple", "blueberry" ]; 
  
  var averageLength = avg(words.map((w) => w.length)); 
  
  print("The average word length is $averageLength characters."); 
}
```
#### Output

    The average word length is 6.666666666666667 characters.

### linq91: Average - Grouped
```csharp
//c#
public void Linq91() 
{ 
    var  products = GetProductList();

    var categories = products
        .GroupBy(prod => prod.Category)
        .Select(prodGroup => new { Category = prodGroup.Key, AveragePrice = prodGroup.Average(p => p.UnitPrice) });

    ObjectDumper.Write(categories);
}
```
```dart
//dart
linq91(){
  var products = productsList(); 
  
  var categories = group(products, by:(p) => p.category)
    .map((g) => { 'Category': g.key, 'AveragePrice': avg(g.values.map((p) => p.unitPrice)) });

  categories.forEach(print);
}
```
#### Output

    {Category: Dairy Products, AveragePrice: 28.73}
    {Category: Grains/Cereals, AveragePrice: 20.25}
    {Category: Confections, AveragePrice: 25.16}
    {Category: Seafood, AveragePrice: 20.6825}
    {Category: Condiments, AveragePrice: 23.0625}
    {Category: Meat/Poultry, AveragePrice: 54.00666666666667}
    {Category: Produce, AveragePrice: 32.37}
    {Category: Beverages, AveragePrice: 37.979166666666664}

### linq92: Aggregate - Simple
```csharp
//c#
public void Linq92() 
{ 
    var doubles = new [] { 1.7, 2.3, 1.9, 4.1, 2.9 };

    var product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

    Console.WriteLine($"Total product of all numbers: {product}");
}
```
```dart
//dart
linq92(){
  var doubles = [ 1.7, 2.3, 1.9, 4.1, 2.9 ]; 
  
  var product = doubles.reduce((runningProduct, nextFactor) => runningProduct * nextFactor); 
  
  print("Total product of all numbers: $product");
}
```
#### Output

    Total product of all numbers: 88.33080999999999

### linq93: Aggregate - Seed
```csharp
//c#
public void Linq93() 
{ 
    var startBalance = 100.0;

    var attemptedWithdrawals = new []{ 20, 10, 40, 50, 10, 70, 30 };

    var endBalance = attemptedWithdrawals
        .Aggregate(startBalance, 
                    (balance, nextWithdrawal) =>
                    ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

    Console.WriteLine($"Ending balance: {endBalance}");
}
```
```dart
//dart
linq93(){
  var startBalance = 100.0; 
  
  var attemptedWithdrawals = [ 20, 10, 40, 50, 10, 70, 30 ]; 
  
  var endBalance = attemptedWithdrawals.fold(startBalance, 
    (balance, nextWithdrawal) => 
      ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance)); 
  
  print("Ending balance: $endBalance"); 
}
```
#### Output

    Ending balance: 20.0


LINQ - Miscellaneous Operators
------------------------------

### Dart utils added

```dart
concat(Iterable seq, Iterable withSeq) =>
  seq.toList()..addAll(withSeq);

bool seqEq(Iterable seq, Iterable withSeq) =>    
  seq.length == withSeq.length 
  && range(seq.length).every((i) => seq.elementAt(i) == withSeq.elementAt(i));
```

### linq94: Concat - 1
```csharp
//c#
public void Linq94() 
{ 
    int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
    int[] numbersB = { 1, 3, 5, 7, 8 };

    var allNumbers = numbersA.Concat(numbersB);

    Console.WriteLine("All numbers from both arrays:");
    allNumbers.ForEach(Console.WriteLine);
}
```
```dart
//dart
linq94(){
  var numbersA = [ 0, 2, 4, 5, 6, 8, 9 ]; 
  var numbersB = [ 1, 3, 5, 7, 8 ]; 
  
  var allNumbers = concat(numbersA, numbersB); 
  
  print("All numbers from both arrays:");
  allNumbers.forEach(print);
}
```
#### Output

    All numbers from both arrays:
    0
    2
    4
    5
    6
    8
    9
    1
    3
    5
    7
    8

### linq95: Concat - 2
```csharp
//c#
public void Linq95() 
{ 
    var customers = GetCustomerList();
    var products = GetProductList();

    var customerNames = customers
        .Select(cust => cust.CompanyName);
    var productNames = products
        .Select(prod => prod.ProductName);

    var allNames = customerNames.Concat(productNames);

    Console.WriteLine("Customer and product names:");
    allNames.ForEach(Console.WriteLine);
}
```
```dart
//dart
linq95(){
  var customers = customersList(); 
  var products = productsList(); 
  
  var customerNames = customers
    .map((c) => c.companyName);
  var productNames = products
    .map((p) => p.productName);
  
  var allNames = concat(customerNames, productNames); 
  
  print("Customer and product names:");
  allNames.forEach(print);
}
```
#### Output

    Customer and product names:
    Alfreds Futterkiste
    Ana Trujillo Emparedados y helados
    Antonio Moreno Taquer�a
    Around the Horn
    Berglunds snabbk�p
    Blauer See Delikatessen
    ...

### linq96: EqualAll - 1
```csharp
//c#
public void Linq96() 
{ 
    var wordsA = new string[] { "cherry", "apple", "blueberry" };
    var wordsB = new string[] { "cherry", "apple", "blueberry" };

    var match = wordsA.SequenceEqual(wordsB);

    Console.WriteLine($"The sequences match: {match}");
}
```
```dart
//dart
linq96(){
  var wordsA = [ "cherry", "apple", "blueberry" ]; 
  var wordsB = [ "cherry", "apple", "blueberry" ]; 
  
  bool match = seqEq(wordsA, wordsB); 
  
  print("The sequences match: $match");
}
```
#### Output

    The sequences match: true

### linq97: EqualAll - 2
```csharp
//c#
public void Linq97() 
{ 
    var wordsA = new string[] { "cherry", "apple", "blueberry" };
    var wordsB = new string[] { "apple", "blueberry", "cherry" };

    var match = wordsA.SequenceEqual(wordsB);

    Console.WriteLine($"The sequences match: {match}");
}
```
```dart
//dart
linq97(){
  var wordsA = [ "cherry", "apple", "blueberry" ]; 
  var wordsB = [ "apple", "blueberry", "cherry" ]; 
  
  bool match = seqEq(wordsA, wordsB); 
  
  print("The sequences match: $match");
}
```
#### Output

    The sequences match: false

LINQ - Query Execution
----------------------

### linq99: Deferred Execution
```csharp
//c#
public void Linq99() 
{ 
    // Queries are not executed until you enumerate over them.
    int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    int i = 0;
    var simpleQuery = numbers
        .Select(x => i++);

    // The local variable 'i' is not incremented until the query is executed in the foreach loop.
    Console.WriteLine($"The current value of i is {i}"); //i is still zero

    simpleQuery.ForEach(item => Console.WriteLine($"v = {item}, i = {i}")); // now i is incremented  
}
```
```dart
//dart
linq99(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var i = 0; 
  var q = numbers.map((n) => ++i);
  
  q.forEach((v) => 
    print("v = $v, i = $i"));
}
```
#### Output

    v = 1, i = 1
    v = 2, i = 2
    v = 3, i = 3
    v = 4, i = 4
    v = 5, i = 5
    v = 6, i = 6
    v = 7, i = 7
    v = 8, i = 8
    v = 9, i = 9
    v = 10, i = 10

### linq100: Immediate Execution
```csharp
//c#
public void Linq100() 
{ 
    // Methods like ToList(), Max(), and Count() cause the query to be executed immediately.            
    int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    int i = 0;
    var immediateQuery = numbers
        .Select(x =>  ++i)
        .ToList();

    Console.WriteLine("The current value of i is {0}", i); //i has been incremented

    immediateQuery.ForEach(item => Console.WriteLine($"v = {item}, i = {i}"));
} 
```
```dart
//dart
linq100(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  
  var i = 0; 
  var q = numbers.map((n) => ++i).toList();
  
  q.forEach((v) => 
    print("v = $v, i = $i"));
}
```
#### Output

    v = 1, i = 10
    v = 2, i = 10
    v = 3, i = 10
    v = 4, i = 10
    v = 5, i = 10
    v = 6, i = 10
    v = 7, i = 10
    v = 8, i = 10
    v = 9, i = 10
    v = 10, i = 10

### linq101: Query Reuse
```csharp
//c#
public void Linq101() 
{ 
    // Deferred execution lets us define a query once and then reuse it later in various ways.
    int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var lowNumbers = numbers
        .Where(num => num <= 3);

    Console.WriteLine("First run numbers <= 3:");
    lowNumbers.ForEach(Console.WriteLine);

    // Modify the source data.
    for (int i = 0; i < 10; i++)
    {
        numbers[i] = -numbers[i];
    }

    // During this second run, the same query object,
    // lowNumbers, will be iterating over the new state
    // of numbers[], producing different results:
    Console.WriteLine("Second run numbers <= 3:");
    lowNumbers.ForEach(Console.WriteLine);
} 
```
```dart
//dart
linq101(){
  var numbers = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ]; 
  var lowNumbers = numbers
    .where((n) => n <= 3); 
  
  print("First run numbers <= 3:");
  lowNumbers.forEach(print);
  
  for (int i = 0; i < 10; i++){ 
    numbers[i] = -numbers[i]; 
  } 
  
  print("Second run numbers <= 3:"); 
  lowNumbers.forEach(print);
}
```
#### Output

    First run numbers <= 3:
    1
    3
    2
    0
    Second run numbers <= 3:
    -5
    -4
    -1
    -3
    -9
    -8
    -6
    -7
    -2
    0


LINQ - Join Operators
---------------------

### Dart utils added

```dart
join(Iterable seq, Iterable withSeq, bool match(x,y)) =>
  seq.expand((x) => withSeq
    .where((y) => match(x,y))
    .map((y) => [x,y]));

joinGroup(Iterable seq, Iterable withSeq, bool match(x,y)) =>
  group(join(seq, withSeq, match), by:(j) => j[0]);  
```

### linq102: Cross Join
```csharp
//c#
public void Linq102() 
{ 
    var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };

    var products = GetProductList();

    var q = categories
        .Join(products, c => c, p => p.Category, 
            (c, p) => new {Category = c, p.ProductName});

    q.ForEach(v => Console.WriteLine($"Category: {v.Category}: Product {v.ProductName}"));
}
```
```dart
//dart
linq102(){
  var categories = [ "Beverages", "Condiments", "Vegetables", "Dairy Products", "Seafood" ];  
  
  var products = productsList(); 
  
  var q = join(categories, products, (c,p) => c == p.category)
    .map((j) => { 'Category': j[0], 'ProductName': j[1].productName });

  q.forEach(print);
}
```
#### Output

    {Category: Beverages, ProductName: Chai}
    {Category: Beverages, ProductName: Chang}
    {Category: Beverages, ProductName: Guaran� Fant�stica}
    {Category: Beverages, ProductName: Sasquatch Ale}
    {Category: Beverages, ProductName: Steeleye Stout}
    {Category: Beverages, ProductName: C�te de Blaye}
    {Category: Beverages, ProductName: Chartreuse verte}
    {Category: Beverages, ProductName: Ipoh Coffee}
    ...

### linq103: Group Join
```csharp
//c#
public void Linq103() 
{ 
    var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  

    var products = GetProductList(); 

    var q = categories
        .GroupJoin(products, c => c, p => p.Category,
            (c, ps) => new {Category = c, Products = ps}); 

    q.ForEach((v) => 
    {
        Console.WriteLine(v.Category + ":"); 
        v.Products.ForEach(p => Console.WriteLine($"\t{p.ProductName}"));
    });
}
```
```dart
//dart
linq103(){
  var categories = [ "Beverages", "Condiments", "Vegetables", "Dairy Products", "Seafood" ];  
  
  var products = productsList(); 
  
  var q = joinGroup(categories, products, (c,p) => c == p.category)
    .map((j) => { 'Category': j.key, 'Products': j.values.map((g) => g[1]) });

  q.forEach((v){
    print("${v['Category']}:");
    v['Products'].forEach((p) => print("   ${p.productName}"));
  });
}
```
#### Output

    Dairy Products:
       Queso Cabrales
       Queso Manchego La Pastora
       Gorgonzola Telino
       Mascarpone Fabioli
       Geitost
       Raclette Courdavault
       Camembert Pierrot
       Gudbrandsdalsost
       Flotemysost
       Mozzarella di Giovanni
    Condiments:
       Aniseed Syrup
       Chef Anton's Cajun Seasoning
       Chef Anton's Gumbo Mix
       Grandma's Boysenberry Spread
       Northwoods Cranberry Sauce
       Genen Shouyu
       Gula Malacca
       Sirop d'�rable
       Vegie-spread
       Louisiana Fiery Hot Pepper Sauce
       Louisiana Hot Spiced Okra
       Original Frankfurter gr�ne So�e
    ...

### linq104: Cross Join with Group Join
```csharp
//c#
public void Linq104() 
{ 
    var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  

    var products = GetProductList();

    var prodByCategory = categories
        .GroupJoin(products, cat => cat, prod => prod.Category, 
            (category, prods) => new {category, prods})
        .SelectMany(x => x.prods, (x, plist) => new {Category = x.category, plist.ProductName});

    prodByCategory.ForEach(item => Console.WriteLine($"{item.ProductName }: {item.Category}"));
}
```
```dart
//dart
linq104(){
  var categories = [ "Beverages", "Condiments", "Vegetables", "Dairy Products", "Seafood" ];  
  
  var products = productsList(); 
  
  var q = joinGroup(categories, products, (c,p) => c == p.category)
    .expand((j) => j.values.map((g) => g[1])
      .map((p) => { 'Category': j.key, 'ProductName': p.productName }));

  q.forEach((v) => 
    print("${v['ProductName']}: ${v['Category']}"));
}
```
#### Output

    Queso Cabrales: Dairy Products
    Queso Manchego La Pastora: Dairy Products
    Gorgonzola Telino: Dairy Products
    Mascarpone Fabioli: Dairy Products
    Geitost: Dairy Products
    Raclette Courdavault: Dairy Products
    Camembert Pierrot: Dairy Products
    Gudbrandsdalsost: Dairy Products
    Flotemysost: Dairy Products
    Mozzarella di Giovanni: Dairy Products
    Aniseed Syrup: Condiments
    Chef Anton's Cajun Seasoning: Condiments
    Chef Anton's Gumbo Mix: Condiments
    ...

### linq105: Left Outer Join
```csharp
//c#
public void Linq105()  
{ 
    var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  

    var products = GetProductList(); 

    var q = categories
        .GroupJoin(products, cat => cat, prod => prod.Category, 
            (category, prods) => new {category, prods})
        .SelectMany(x => x.prods.DefaultIfEmpty(),
            (x, p) => new {Category = x.category, ProductName = p == null ? "(No products)" : p.ProductName}); 

    q.ForEach(item => Console.WriteLine($"{item.ProductName }: {item.Category}"));
}
```
```dart
//dart
linq105(){
  var categories = [ "Beverages", "Condiments", "Vegetables", "Dairy Products", "Seafood" ];  
  
  var products = productsList(); 
  
  var q = categories
    .expand((c){
      var catProducts = products.where((p) => c == p.category);
      return catProducts.isEmpty 
        ? [{ 'Category': c, 'ProductName': "(No products)" }]
        : catProducts.map((p) => { 'Category': c, 'ProductName': p.productName });
    });

  q.forEach((v) => 
    print("${v['ProductName']}: ${v['Category']}"));
}
```
#### Output

    Chai: Beverages
    Chang: Beverages
    Guaran� Fant�stica: Beverages
    Sasquatch Ale: Beverages
    Steeleye Stout: Beverages
    C�te de Blaye: Beverages
    Chartreuse verte: Beverages
    Ipoh Coffee: Beverages
    Laughing Lumberjack Lager: Beverages
    Outback Lager: Beverages
    Rh�nbr�u Klosterbier: Beverages
    Lakkalik��ri: Beverages
    Aniseed Syrup: Condiments
    Chef Anton's Cajun Seasoning: Condiments
    Chef Anton's Gumbo Mix: Condiments
    Grandma's Boysenberry Spread: Condiments
    Northwoods Cranberry Sauce: Condiments
    Genen Shouyu: Condiments
    Gula Malacca: Condiments
    Sirop d'�rable: Condiments
    Vegie-spread: Condiments
    Louisiana Fiery Hot Pepper Sauce: Condiments
    Louisiana Hot Spiced Okra: Condiments
    Original Frankfurter gr�ne So�e: Condiments
    (No products): Vegetables
    ...


### Contributors

  - [mythz](https://github.com/mythz) (Demis Bellot)

