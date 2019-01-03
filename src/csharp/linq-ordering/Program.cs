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
            Linq28();
//            Linq29();
//            Linq30();
//            Linq31();
//            Linq32();
//            Linq33();
//            Linq34();
//            Linq35();
//            Linq36();
//            Linq37();
//            Linq38();
//            Linq39();
        }


        [Category("Ordering Operators")]
        [Description("This sample uses ordering to sort a list of words alphabetically.")]
        static void Linq28()
        {
            var words = new [] { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(w => w);

            Console.WriteLine("The sorted list of words:");
            sortedWords.ForEach(Console.WriteLine);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses ordering to sort a list of words by length.")]
        static void Linq29()
        {
            var words = new [] { "cherry", "apple", "blueberry" };
        
            var sortedWords = words.OrderBy(w => w.Length);
        
            Console.WriteLine("The sorted list of words (by length):"); 
            sortedWords.ForEach(Console.WriteLine);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses ordering to sort a list of products by name.")]
        static void Linq30()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderBy(p => p.ProductName);

            ObjectDumper.Write(sortedProducts);
        }
        
        [Category("Ordering Operators")]
        [Description("This sample uses case-insensitive ordering to sort the words in an array.")]
        static void Linq31()
        {
            var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 

            var sortedWords = words.OrderBy(a => a, StringComparer.CurrentCultureIgnoreCase); 
        
            ObjectDumper.Write(sortedWords); 
        }

        [Category("Ordering Operators")]
        [Description("This sample uses reverse ordering to sort a list of doubles from highest to lowest.")]
        static void Linq32()
        {
            var doubles = new[]{ 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = doubles.OrderByDescending(d => d);

            Console.WriteLine("The doubles from highest to lowest:");
            sortedDoubles.ForEach(Console.WriteLine);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses reverse ordering to sort a list of products by units in stock from highest to lowest.")]
        static void Linq33()
        {
            var products = GetProductList();

            var sortedProducts = products.OrderByDescending(p => p.UnitsInStock);

            ObjectDumper.Write(sortedProducts);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses reverse case-insensitive ordering to sort the words in an array.")]
        static void Linq34()
        {
            var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderByDescending(a => a, StringComparer.CurrentCultureIgnoreCase); 

            ObjectDumper.Write(sortedWords);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses nested ordering, first by length of their name, and then alphabetically by the name itself.")]
        static void Linq35()
        {
            var digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits
                .OrderBy(d => d.Length)
                .ThenBy(d => d);

            Console.WriteLine("Sorted digits:");
            sortedDigits.ForEach(Console.WriteLine);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses case-insensitive nested ordering, with a custom comparer to sort first by word length and then by a case-insensitive sort of the words in an array.")]
        static void Linq36()
        {
            var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words
                .OrderBy(a => a.Length)
                .ThenBy(a => a, StringComparer.CurrentCultureIgnoreCase);

            ObjectDumper.Write(sortedWords);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses nested ordering to sort a list of products, first by category, and then by unit price, from highest to lowest.")]
        static void Linq37()
        {
           var products = GetProductList();

            var sortedProducts = products
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            ObjectDumper.Write(sortedProducts);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses uses case-insensitive reverse nested ordering to sort first by word length and then by a case-insensitive descending sort of the words in an array.")]
        static void Linq38()
        {
            var words = new [] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words
                .OrderBy(a => a.Length)
                .ThenByDescending(a => a, StringComparer.CurrentCultureIgnoreCase);

            ObjectDumper.Write(sortedWords);
        }

        [Category("Ordering Operators")]
        [Description("This sample uses reverse ordering to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.")]
        static void Linq39()
        {
            var digits = new [] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = digits
                .Where(d => d[1] == 'i')
                .Reverse();

            Console.WriteLine("A backwards list of the digits with a second character of 'i':");
            reversedIDigits.ForEach(Console.WriteLine);
        }

    }
}
