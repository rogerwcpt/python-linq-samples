using System;
using System.Linq;
using System.ComponentModel;
using linqshared;

namespace linq_element
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq58();
        //    Linq59();
        //    Linq61();
        //    Linq62();
        //    Linq64();        
        }

        [Category("Element Operators")]
        [Description("This sample returns the first matching element as a Product, instead of as a sequence containing a Product.")]
        static void Linq58()
        {
            var products = GetProductList();

            var product12 = products.First(p => p.ProductID == 12);

            ObjectDumper.Write(product12);
        }

        [Category("Element Operators")]
        [Description("This sample finds the first element in the array that starts with 'o'.")]
        static void Linq59()
        {
             var strings = new []{ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var startsWithO = strings.First(s => s.StartsWith('o'));

            Console.WriteLine("A string starting with 'o': {0}", startsWithO);
        }


        [Category("Element Operators")]
        [Description("This sample returns the first or default if nothing is found, to try to return the first element of the sequence unless there are no elements, in which case the default value for that type is returned.")]
        static void Linq61()
        {
            var numbers = new int[0];

            var firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);
        }

        [Category("Element Operators")]
        [Description("This sample returns the first or default if nothing is found, to return the first product whose ProductID is 789 as a single Product object, unless there is no match, in which case null is returned.")]
        static void Linq62()
        {
            var products = GetProductList();

            var product789 = products.FirstOrDefault(p => p.ProductID == 789);

            Console.WriteLine("Product 789 exists: {0}", product789 != null);
        }

        [Category("Element Operators")]
        [Description("This sample retrieve the second number greater than 5 from an array.")]
        static void Linq64()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var fourthLowNum = numbers
                .Where(num => num > 5)
                .ElementAt(1);

            Console.WriteLine("Second number > 5: {0}", fourthLowNum);
        }           
    }
}
