using System;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_sets
{
    class Program: ProgramBase
    {
        static void Main(string[] args)
        {
            Linq46();
//            Linq47();
//            Linq48();
//            Linq49();
//            Linq50();
//            Linq51();
//            Linq52();
//            Linq53();
        }


        [Category("Set Operators")]
        [Description("This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.")]
        static void Linq46()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Prime factors of 300:");
            uniqueFactors.ForEach(Console.WriteLine);
        }

        [Category("Set Operators")]
        [Description("This sample uses Distinct to find the unique Category names.")]
        static void Linq47()
        {
            var products = GetProductList();

            var categoryNames = products
                .Select(p => p.Category)
                .Distinct();

            Console.WriteLine("Category names:");
            categoryNames.ForEach(Console.WriteLine);
        }

        [Category("Set Operators")]
        [Description("This sample uses Union to create one sequence that contains the unique values from both arrays.")]
        static void Linq48()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            uniqueNumbers.ForEach(Console.WriteLine);
        }        
        
        [Category("Set Operators")]
        [Description("This sample uses the Union method to create one sequence that contains the unique first letter from both product and customer names")]
        static void Linq49()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars = customers.Select(c => c.CompanyName[0]);

            var uniqueFirstChars = productFirstChars.Union(customerFirstChars);

            Console.WriteLine("Unique first letters from Product names and Customer names:");
            uniqueFirstChars.ForEach(Console.WriteLine);
        }

        [Category("Set Operators")]
        [Description("This sample uses Intersect to create one sequence that contains the common values shared by both arrays.")]
        static void Linq50()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            commonNumbers.ForEach(Console.WriteLine);
        }

        [Category("Set Operators")]
        [Description("This sample uses Intersect to create one sequence that contains the common first lette from both product and customer names.")]
        private static void Linq51()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars = customers.Select(c => c.CompanyName[0]);

            var commonFirstChars = productFirstChars.Intersect(customerFirstChars);

            Console.WriteLine("Common first letters from Product names and Customer names:");
            commonFirstChars.ForEach(Console.WriteLine);
        } 

        
        [Category("Set Operators")]
        [Description("This sample uses Except to create a sequence that contains the values from numbersA that are not also in numbersB.")]
        private static void Linq52()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("Numbers in first array but not second array:");
            aOnlyNumbers.ForEach(Console.WriteLine);
        }

        [Category("Set Operators")]
        [Description("This sample uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names.")]
        private static void Linq53()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars = customers.Select(c => c.CompanyName[0]);

            var productOnlyFirstChars = productFirstChars.Except(customerFirstChars);

            Console.WriteLine("First letters from Product names, but not from Customer names:");
            productOnlyFirstChars.ForEach(Console.WriteLine);
        }        
       
    }
}
