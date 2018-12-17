using System;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_ordering
{
    class Program: ProgramBase
    {
        static void Main(string[] args)
        {
            Linq29();
            Linq30();
        }

        [Category("Ordering Operators")]
        [Description("This sample uses orderby to sort a list of words alphabetically.")]
        public static void Linq29()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(w => w);

            Console.WriteLine("The sorted list of words:");
            sortedWords.ForEach(Console.WriteLine);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses orderby to sort a list of products by name. Use the \"descending\" keyword at the end of the clause to perform a reverse ordering.")]
        public static void Linq30()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderBy(p => p.ProductName);

            ObjectDumper.Write(sortedProducts);
        }
    }
}
