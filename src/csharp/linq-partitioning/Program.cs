using System;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_partitioning
{
    class Program: ProgramBase
    {
        static void Main(string[] args)
        {
            //Linq20();
            Linq21();
            //Linq22();
            //Linq23();
            //Linq24();
            //Linq25();
            //Linq26();
            //Linq27();
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses Take to get only the first 3 elements of the array.")]
        private static void Linq20()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");
            first3Numbers.ForEach(Console.WriteLine);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses Take to get the first 3 orders from customers in Washington.")]
        private static void Linq21()
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

        [Category("Partitioning Operators")]
        [Description("This sample uses Skip to get all but the first four elements of the array.")]
        public static void Linq22()
        {
            var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            allButFirst4Numbers.ForEach(Console.WriteLine);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses Take to get all but the first 2 orders from customers in Washington.")]
        public static void Linq23()
        {
            var customers = GetCustomerList();

            var waOrders = customers
                .Where(c => c.Region == "WA")
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .Select(x => new { x.customer.CustomerID, x.order.OrderID, x.order.OrderDate });

            var allButFirst2Orders = waOrders.Skip(2);

            Console.WriteLine("All but first 2 orders in WA:");
            ObjectDumper.Write(allButFirst2Orders);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is read whose value is not less than 6.")]
        public static void Linq24()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");
            firstNumbersLessThan6.ForEach(Console.WriteLine);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is less than its position in the array.")]
        public static void Linq25()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("First numbers not less than their position:");
            firstSmallNumbers.ForEach(Console.WriteLine);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses SkipWhile to get the elements of the array starting from the first element divisible by 3.")]
        public static void Linq26()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("All elements starting from first element divisible by 3:");
            allButFirst3Numbers.ForEach(Console.WriteLine);
        }

        [Category("Partitioning Operators")]
        [Description("This sample uses SkipWhile to get the elements of the array starting from the first element less than its position.")]
        public static void Linq27()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("All elements starting from first element less than its position:");
            laterNumbers.ForEach(Console.WriteLine);
        }
    }
}
