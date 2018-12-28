using System;
using System.Linq;

using linqshared;
using System.ComponentModel;

namespace linq_restrictions
{
    class Program: ProgramBase
    {
        static void Main(string[] args)
        {
            //Linq1();
            //Linq2();
            //Linq3();
            //Linq4();
            Linq5();
        }

        [Category("Restriction Operators")]
        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        static void Linq1()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums = numbers
                .Where(n => n < 5);

            Console.WriteLine("Numbers < 5:");
            lowNums.ForEach(Console.WriteLine);
        }

        [Category("Restriction Operators")]
        [Description("This sample uses the where clause to find all products that are out of stock.")]
        static void Linq2()
        {
            var products = GetProductList();

            var soldOutProducts = products
                .Where(p => p.UnitsInStock == 0);

            Console.WriteLine("Sold out products:");
            soldOutProducts.ForEach(x => Console.WriteLine($"{x.ProductName} is sold out!"));
        }

        [Category("Restriction Operators")]
        [Description("This sample uses the where clause to find all products that are in stock and cost more than 3.00 per unit.")]
        public static void Linq3()
        {
            var products = GetProductList();

            var expensiveInStockProducts = products
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);

            Console.WriteLine("In-stock products that cost more than 3.00:");
            expensiveInStockProducts.ForEach(product => Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00."));
        }

        [Category("Restriction Operators")]
        [Description("This sample uses the where clause to find all customers in Washington and then it uses a foreach loop to iterate over the orders collection that belongs to each customer.")]
        static void Linq4()
        {
            var customers = GetCustomerList();

            Console.WriteLine("Customers from Washington and their orders:");
            var waCustomers = customers.Where(c => c.Region == "WA");

            waCustomers.ForEach((customer) =>
            {
                Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
                customer.Orders.ForEach((order) => 
                {
                    Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
                });
            });
        }

        [Description("This sample demonstrates an indexed where clause that returns digits whose name is shorter than their value.")]
        static void Linq5()
        {
            var digits = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");
            shortDigits.ForEach(d => Console.WriteLine($"The word {d} is shorter than its value."));
        }
    }
}
