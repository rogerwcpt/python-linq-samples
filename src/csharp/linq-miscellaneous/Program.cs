using System;
using System.Linq;
using System.ComponentModel;
using linqshared;

namespace linq_miscellaneous
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq94();
        //    Linq95();
        //    Linq96();
        //    Linq97();
        }

        [Category("Miscellaneous Operators")]
        [Description("This sample creates a contatenation of each array's values, one after the other.")]
        static void Linq94()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var allNumbers = numbersA.Concat(numbersB);

            Console.WriteLine("All numbers from both arrays:");
            allNumbers.ForEach(Console.WriteLine);
        }

[       Category("Miscellaneous Operators")]
        [Description("This sample creates a contatenation that contains the names of all customers and products, including any duplicates.")]
        static void Linq95()
        {
            var customers = GetCustomerList();
            var products = GetProductList();

            var customerNames = customers.Select(cust => cust.CompanyName);
            var productNames = products.Select(prod => prod.ProductName);

            var allNames = customerNames.Concat(productNames);

            Console.WriteLine("Customer and product names:");
            allNames.ForEach(Console.WriteLine);
        }

        [Category("Miscellaneous Operators")]
        [Description("This sample checks if two sequences match on all elements in the same order.")]
        static void Linq96()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "cherry", "apple", "blueberry" };

            var match = wordsA.SequenceEqual(wordsB);

            Console.WriteLine($"The sequences match: {match}");
        }

        [Category("Miscellaneous Operators")]
        [Description("This sample checks if two sequences match on all elements in the same order.")]
        static void Linq97()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "apple", "blueberry", "cherry" };

            var match = wordsA.SequenceEqual(wordsB);

            Console.WriteLine($"The sequences match: {match}");
        }          
    }
}
