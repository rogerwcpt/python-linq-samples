using System;
using System.ComponentModel;
using linqshared;
using System.Linq;
using System.Globalization;

namespace linq_projections
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq6();
            // Linq7();
            // Linq8();
            // Linq9();
            // Linq10();
            // Linq11();
            // Linq12();
            // Linq13();
            // Linq14();
            // Linq15();
            // Linq16();
            // Linq17();
            // Linq18();
            // Linq19();
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence of ints 1+ higher than those in an existing array of ints.")]
        static void Linq6()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsPlusOne = numbers.Select(n => n + 1);

            Console.WriteLine("Numbers + 1:");
            numsPlusOne.ForEach(Console.WriteLine);
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence of just the names of a list of products.")]
        static void Linq7()
        {
            var products = GetProductList();

            var productNames = products.Select(p => p.ProductName);

            Console.WriteLine("Product Names:");
            productNames.ForEach(Console.WriteLine);
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence of strings representing the text version of a sequence of integers.")]
        static void Linq8()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var strings = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(n => strings[n]);

            Console.WriteLine("Number strings:");
            textNums.ForEach(Console.WriteLine);
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence of the uppercase and lowercase versions of each word in the original array.")]
        static void Linq9()
        {
            var words = new[] { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words.Select(w => 
                new
                {
                    Upper = w.ToUpper(), 
                    Lower = w.ToLower()
                });

            upperLowerWords.ForEach(ul => Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}"));
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence containing text representations of digits and whether their length is even or odd.")]
        static void Linq10()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = numbers.Select(n => 
                new
                {
                    Digit = strings[n], 
                    Even = (n % 2 == 0)
                });
            
            digitOddEvens.ForEach(d => Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}."));
        }

        [Category("Projection Operators")]
        [Description("This sample projects a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.")]
        static void Linq11()
        {
            var products = GetProductList();

            var productInfos = products.Select(p => 
                new
                {
                    p.ProductName, 
                    p.Category, 
                    Price = p.UnitPrice
                });

            Console.WriteLine("Product Info:");
            productInfos.ForEach(productInfo => Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs {productInfo.Price} per unit."));
        }


        [Category("Projection Operators")]
        [Description("This sample uses an indexed projection to determine if the value of integers in an array match their position in the array.")]
        static void Linq12()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => 
                new
                {
                    Num = num, 
                    InPlace = (num == index)
                });

            Console.WriteLine("Number: In-place?");
            numsInPlace.ForEach(n => Console.WriteLine($"{n.Num}: {n.InPlace}"));
        }

        [Category("Projection Operators")]
        [Description("This sample first filters, then projects to make a simple query that returns the text form of each digit less than 5.")]
        static void Linq13()
        {
            var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var  digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = numbers
                .Where(n => n < 5)
                .Select(n => digits[n]);

            Console.WriteLine("Numbers < 5:");
            lowNums.ForEach(Console.WriteLine);
        }

        [Category("Projection Operators")]
        [Description("This sample projects a combination of 2 source arrays, then filters all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.")]
        static void Linq14()
        {
            var numbersA = new [] { 0, 2, 4, 5, 6, 8, 9 };
            var numbersB = new []{ 1, 3, 5, 7, 8 };

            var pairs = numbersA
                .SelectMany(a => numbersB, (a, b) => new { a, b })
                .Where(x => x.a < x.b);

            Console.WriteLine("Pairs where a < b:");
            pairs.ForEach(pair => Console.WriteLine("{0} is less than {1}", pair.a, pair.b));
        }

        [Category("Projection Operators")]
        [Description("This sample uses a nested projection to flatten the customer orders, then filtes the order total is less than 500.00.")]
        static void Linq15()
        {
            var customers = GetCustomerList();

            var orders = customers
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .Where(x => x.order.Total < 500.00M)
                .Select(x => 
                    new
                    {
                        x.customer.CustomerID, 
                        x.order.OrderID, 
                        x.order.Total
                    });

            ObjectDumper.Write(orders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses a nested projection to flatten the customer orders, the filters all orders that was made in 1998 or later.")]
        static void Linq16()
        {
            var customers = GetCustomerList();

            var orders = customers
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .Where(x => x.order.OrderDate >= new DateTime(1998, 1, 1))
                .Select(x => 
                    new
                    {
                        x.customer.CustomerID, 
                        x.order.OrderID, 
                        x.order.OrderDate
                    });

            ObjectDumper.Write(orders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses a nested projection to flatten the customer orders, then filters the orders where the order total is greater than 2000.00.")]
        static void Linq17()
        {
            var customers = GetCustomerList();

            var orders = customers
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .Where(x => x.order.Total >= 2000.00M)
                .Select(x => 
                    new
                    {
                        x.customer.CustomerID,
                        x.order.OrderID, 
                        x.order.Total
                    });

            ObjectDumper.Write(orders);
        }

        [Category("Projection Operators")]
        [Description("This sample fist filters on all Customers in Washington, then uses a nested projection to flatten the customer orders, then filtering on all orders greater than the cut-off date")]
        static void Linq18()
        {
            var customers = GetCustomerList();

            var cutoffDate = new DateTime(1997, 1, 1);

            var orders = customers
                .Where(c => c.Region == "WA")
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .Where(x => x.order.OrderDate >= cutoffDate)
                .Select(x => 
                    new
                    {
                        x.customer.CustomerID, 
                        x.customer.Region, 
                        x.order.OrderID
                    });

            ObjectDumper.Write(orders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses an indexed SelectMany clause to select all orders, while referring to customers by the order in which they are returned from the query.")]
        static void Linq19()
        {
            var customers = GetCustomerList();

            var customerOrders =
                   customers.SelectMany(
                       (cust, custIndex) =>
                            cust.Orders.Select(o => $"Customer #{custIndex + 1}) has an order with OrderID {o.OrderID}"));

            ObjectDumper.Write(customerOrders);
        }
    }
}