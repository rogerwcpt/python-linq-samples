using System;
using System.Linq;
using System.ComponentModel;

using linqshared;

namespace linq_quantifiers
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            //Linq67();
            //Linq69();
            //Linq70();
            Linq72();
        }

        [Category("Quantifiers")]
        [Description(@"This sample uses Any to determine if any of the words in the array
                       contain the substring 'ei'.")]
        static void Linq67()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine($"There is a word in the list that contains 'ei': {iAfterE}");
        }

        [Category("Quantifiers")]
        [Description(@"This sample uses Any to return a grouped a list of products only for categories
                       that have at least one product that is out of stock.")]
        static void Linq69()
        {
            var products = GetProductList();

            var productGroups = products
                .GroupBy(prod => prod.Category)
                .Where(prodGroup => prodGroup.Any(p => p.UnitsInStock == 0))
                .Select(prodGroup => new { Category = prodGroup.Key, Products = prodGroup });

            ObjectDumper.Write(productGroups, 1);
        }

        [Category("Quantifiers")]
        [Description("This sample uses All to determine whether an array contains only odd numbers.")]
        static void Linq70()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            bool onlyOdd = numbers.All(n => n % 2 == 1);

            Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
        }

        [Category("Quantifiers")]
        [Description(@"This sample uses All to return a grouped a list of products only for categories
                       that have all of their products in stock.")]
        static void Linq72()
        {
            var products = GetProductList();

            var productGroups = products
                .GroupBy(prod => prod.Category)
                .Where(prodGroup => prodGroup.All(p => p.UnitsInStock > 0))
                .Select(prodGroup => new { Category = prodGroup.Key, Products = prodGroup });

            ObjectDumper.Write(productGroups, 1);
        }
    }
}
