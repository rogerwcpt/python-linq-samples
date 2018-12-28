using System;
using System.Linq;
using System.ComponentModel;

using linqshared;

namespace linq_query
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            // Linq99();
            //Linq100();
            Linq101();
        }

        [Category("Query Execution")]
        [Description("The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.")]
        static void Linq99()
        {
            // Queries are not executed until you enumerate over them.
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var simpleQuery = numbers
                .Select(x => i++);

            // The local variable 'i' is not incremented until the query is executed in the foreach loop.
            Console.WriteLine($"The current value of i is {i}"); //i is still zero

            simpleQuery.ForEach(item => Console.WriteLine($"v = {item}, i = {i}")); // now i is incremented          
        }

        [Category("Query Execution")]
        [Description("The following sample shows how queries can be executed immediately, and their results stored in memory, with methods such as ToList.")]
        static void Linq100()
        {
            // Methods like ToList(), Max(), and Count() cause the query to be executed immediately.            
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var immediateQuery = numbers
                .Select(x =>  ++i)
                .ToList();

            Console.WriteLine("The current value of i is {0}", i); //i has been incremented

            immediateQuery.ForEach(item => Console.WriteLine($"v = {item}, i = {i}"));
        }

        [Category("Query Execution")]
        [Description("The following sample shows how, because of deferred execution, queries can be used " +
                        "again after data changes and will then operate on the new data.")]
        static void Linq101()
        {
            // Deferred execution lets us define a query once and then reuse it later in various ways.
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var lowNumbers = numbers
                .Where(num => num <= 3);

            Console.WriteLine("First run numbers <= 3:");
            lowNumbers.ForEach(Console.WriteLine);

            // Modify the source data.
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = -numbers[i];
            }

            // During this second run, the same query object,
            // lowNumbers, will be iterating over the new state
            // of numbers[], producing different results:
            Console.WriteLine("Second run numbers <= 3:");
            lowNumbers.ForEach(Console.WriteLine);
        }        
    }
}
