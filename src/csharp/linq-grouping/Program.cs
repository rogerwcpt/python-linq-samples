using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_grouping
{
    class Program: ProgramBase
    {
        static void Main(string[] args)
        {
            Linq40();
//            Linq41();
//            Linq42();
//            Linq43();
//            Linq44();
//            Linq45();
        }

        private class AnagramEqualityComparer : IEqualityComparer<string> 
        { 
            public bool Equals(string x, string y) 
            { 
                return GetCanonicalString(x) == GetCanonicalString(y); 
            } 
        
            public int GetHashCode(string obj) 
            { 
                return GetCanonicalString(obj).GetHashCode(); 
            } 
        
            private string GetCanonicalString(string word) 
            { 
                var wordChars = word.ToCharArray(); 
                Array.Sort<char>(wordChars); 
                return new string(wordChars); 
            } 
        } 
        
        [Category("Grouping Operators")]
        [Description("This sample uses group by to partition a list of numbers by their remainder when divided by 5.")]
        private static void Linq40()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 

            var numberGroups = numbers
                .GroupBy(n => n % 5)
                .Select(x => 
                    new
                    {
                        Remainder = x.Key, 
                        Numbers = x
                    });

            numberGroups.ForEach((g) => 
            {
                 Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                 g.Numbers.ForEach(Console.WriteLine);
            });
        }

        [Category("Grouping Operators")]
        [Description("This sample uses group by to partition a list of words by their first letter.")]
        private static void Linq41()
        {
            var words = new [] { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }; 

            var wordGroups = words
                .GroupBy(w => w[0])
                .Select(g => 
                    new
                    {
                        FirstLetter = g.Key, 
                        Words = g
                    });

            wordGroups.ForEach((g) => 
            {
                Console.WriteLine($"Words that start with the letter '{g.FirstLetter}':");
                g.Words.ForEach(Console.WriteLine);
            });
        }

        [Category("Grouping Operators")]
        [Description("This sample uses group by to partition a list of products by category.")]
        private static void Linq42()
        {
            var products = GetProductList(); 
            
            var orderGroups = products
                .GroupBy(p => p.Category)
                .Select(g => 
                    new
                    {
                        Category = g.Key, 
                        Products = g
                    }); 
        
            ObjectDumper.Write(orderGroups, 1); 
        }

        [Category("Grouping Operators")]
        [Description("This sample uses group by to partition a list of each customer's orders, first by year, and then by month.")]
        private static void Linq43()
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

        [Category("Grouping Operators")]
        [Description("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other.")]
        private static void Linq44()
        {
            var anagrams = new [] { "from    ", " salt", " earn ", "  last   ", " near ", " form  " }; 
            var orderGroups = anagrams
                .GroupBy(w => w.Trim(), new AnagramEqualityComparer());

            ObjectDumper.Write(orderGroups, 1); 
        }

        [Category("Grouping Operators")]
        [Description("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other, and then converts the results to uppercase.")]
        private static void Linq45()
        {
            var anagrams = new [] { "from   ", " salt", " earn ", "  last   ", " near ", " form  " }; 
        
            var orderGroups = anagrams.GroupBy( 
                        w => w.Trim(),
                        a => a.ToUpper(), 
                        new AnagramEqualityComparer() 
                        ); 
        
            ObjectDumper.Write(orderGroups, 1); 
        }            
    }
}
