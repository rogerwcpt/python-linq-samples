using System;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_aggregate
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq73();
//            Linq74();
//            Linq76();
//            Linq77();
//            Linq78();
//            Linq79();
//            Linq80();
//            Linq81();
//            Linq82();
//            Linq83();
//            Linq84();
//            Linq85();
//            Linq86();
//            Linq87();
//            Linq88();
//            Linq89();
//            Linq90();
//            Linq91();
//            Linq92();
//            Linq93();

        }

        [Category("Aggregate Operators")]
        [Description("This sample gets the number of unique prime factors of 300.")]
        static void Linq73()
        {
            var primeFactorsOf300 = new [] { 2, 2, 3, 5, 5 };

            var uniqueFactors = primeFactorsOf300.Distinct().Count();

            Console.WriteLine($"There are {uniqueFactors} unique prime factors of 300.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample gets the number of odd ints in the array.")]
        static void Linq74()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine($"There are {oddNumbers} odd numbers in the list.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Count to return a list of customers and how many orders each has.")]
        static void Linq76()
        {
            var customers = GetCustomerList();

            var orderCounts = customers
                .Select(cust => 
                    new
                    {
                        cust.CustomerID, 
                        OrderCount = cust.Orders.Count()
                    });

            ObjectDumper.Write(orderCounts);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Count to return a list of categories and how many products each has.")]
        static void Linq77()
        {
            var products = GetProductList();

            var categoryCounts = products
                .GroupBy(prod => prod.Category)
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        ProductCount = prodGroup.Count()
                    });

            ObjectDumper.Write(categoryCounts);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Sum to add all the numbers in an array.")]
        static void Linq78()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numSum = numbers.Sum();

            Console.WriteLine($"The sum of the numbers is {numSum}.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Sum to get the total number of characters of all words in the array.")]
        static void Linq79()
        {
            var  words = new [] { "cherry", "apple", "blueberry" };

            var totalChars = words.Sum(w => w.Length);

            Console.WriteLine($"There are a total of {totalChars} characters in these words.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Sum to get the total units in stock for each product category.")]
        static void Linq80()
        {
            var products = GetProductList();

            var categories = products
                .GroupBy(prod => prod.Category)
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock)
                    });

            ObjectDumper.Write(categories);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Min to get the lowest number in an array.")]
        static void Linq81()
        {
            var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var minNum = numbers.Min();

            Console.WriteLine($"The minimum number is {minNum}.");
        } 

        [Category("Aggregate Operators")]
        [Description("This sample uses Min to get the length of the shortest word in an array.")]
        static void Linq82()
        {
            var words = new [] { "cherry", "apple", "blueberry" };

            var shortestWord = words.Min(w => w.Length);

            Console.WriteLine($"The shortest word is {shortestWord} characters long.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Min to get the cheapest price among each category's products.")]
        static void Linq83()
        {
            var products = GetProductList();

            var categories = products
                .GroupBy(prod => prod.Category)
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        CheapestPrice = prodGroup.Min(p => p.UnitPrice)
                    });

            ObjectDumper.Write(categories);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Min to get the products with the lowest price in each category.")]
        static void Linq84()
        {
            var products = GetProductList();

            var categories = products.GroupBy(prod => prod.Category)
                .Select(prodGroup => new {prodGroup, minPrice = prodGroup.Min(p => p.UnitPrice)})
                .Select(x => 
                    new
                    {
                        Category = x.prodGroup.Key,
                        CheapestProducts = x.prodGroup.Where(p => p.UnitPrice == x.minPrice)
                    });

            ObjectDumper.Write(categories, 1);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Max to get the highest number in an array. Note that the method returns a single value.")]
        static void Linq85()
        {
            var numbers = new []{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var maxNum = numbers.Max();

            Console.WriteLine($"The maximum number is {maxNum}.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Max to get the length of the longest word in an array.")]
        static void Linq86()
        {
            var words = new [] { "cherry", "apple", "blueberry" };

            var longestLength = words.Max(w => w.Length);

            Console.WriteLine($"The longest word is {longestLength} characters long.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Max to get the most expensive price among each category's products.")]
        static void Linq87()
        {
            var products = GetProductList();

            var categories = products
                .GroupBy(prod => prod.Category)
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        MostExpensivePrice = prodGroup.Max(p => p.UnitPrice)
                    });

            ObjectDumper.Write(categories);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Max to get the products with the most expensive price in each category.")]
        static void Linq88()
        {
            var products = GetProductList();

            var categories = products.GroupBy(prod => prod.Category)
                .Select(prodGroup => new {prodGroup, maxPrice = prodGroup.Max(p => p.UnitPrice)})
                .Select(x => 
                    new
                    {
                        Category = x.prodGroup.Key,
                        MostExpensiveProducts = x.prodGroup.Where(p => p.UnitPrice == x.maxPrice)
                    });

            ObjectDumper.Write(categories, 1);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Average to get the average of all numbers in an array.")]
        static void Linq89()
        {
            var numbers = new [] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var averageNum = numbers.Average();

            Console.WriteLine($"The average number is {averageNum}.");
        }


        [Category("Aggregate Operators")]
        [Description("This sample uses Average to get the average length of the words in the array.")]
        static void Linq90()
        {
            var words = new [] { "cherry", "apple", "blueberry" };

            var averageLength = words.Average(w => w.Length);

            Console.WriteLine($"The average word length is {averageLength} characters.");
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Average to get the average price of each category's products.")]
        static void Linq91()
        {
            var  products = GetProductList();

            var categories = products
                .GroupBy(prod => prod.Category)
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        AveragePrice = prodGroup.Average(p => p.UnitPrice)
                    });

            ObjectDumper.Write(categories);
        }

        [Category("Aggregate Operators")]
        [Description("This sample uses Aggregate to create a running product on the array that calculates the total product of all elements.")]
        static void Linq92()
        {
            var doubles = new [] { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

            Console.WriteLine($"Total product of all numbers: {product}");
        }

        [Category("Aggregate Operators")]
        [Description(@"This sample uses Aggregate to create a running account balance that
                     subtracts each withdrawal from the initial balance of 100, as long as
                     the balance never drops below 0.")]
        static void Linq93()
        {
            var startBalance = 100.0;

            var attemptedWithdrawals = new []{ 20, 10, 40, 50, 10, 70, 30 };

            var endBalance = attemptedWithdrawals
                .Aggregate(startBalance, 
                           (balance, nextWithdrawal) =>
                            ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

            Console.WriteLine($"Ending balance: {endBalance}");
        }           

    }
}
