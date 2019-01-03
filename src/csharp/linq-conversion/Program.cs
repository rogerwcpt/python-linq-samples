using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_conversion
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq54();
//            Linq55();
//            Linq56();
//            Linq57();
        }

        [Category("Conversion Operators")]
        [Description("This sample converts a list to an array.")]
        static void Linq54()
        {
            var list = new List<double> { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var doublesArray = list
                .OrderByDescending(d => d)
                .ToArray();
                
            Console.WriteLine("Every other double from highest to lowest:");
            for (var d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }


        [Category("Conversion Operators")]
        [Description("This sample converts an array to a list")]
        static void Linq55()
        {
            var words = new[] { "cherry", "apple", "blueberry" };

            var wordList = words
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine("The sorted word list:");
            wordList.ForEach(Console.WriteLine);
        }

        [Category("Conversion Operators")]
        [Description("This sample converts an array of records to a dictionary")]
        static void Linq56()
        {
            var scoreRecords = 
                new[] 
                { 
                    new {Name = "Alice", Score = 50},
                    new {Name = "Bob"  , Score = 40},
                    new {Name = "Cathy", Score = 45}
                };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
        }
            
        [Category("Conversion Operators")]
        [Description("This sample filters all elements that matches the type double.")]
        static void Linq57()
        {
            var numbers = new object[]{ null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            doubles.ForEach(Console.WriteLine);
        }        

    }
}
