using System;
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
        [Description("This sample uses ToArray to immediately evaluate a sequence into an array.")]
        static void Linq54()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = doubles.OrderByDescending(d => d);
                
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (var d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }


        [Category("Conversion Operators")]
        [Description("This sample uses ToList to immediately evaluate a sequence into a List<T>.")]
        static void Linq55()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(x => x);

            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            wordList.ForEach(Console.WriteLine);
        }

        [Category("Conversion Operators")]
        [Description("This sample uses ToDictionary to immediately evaluate a sequence and a related key expression into a dictionary.")]
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
        [Description("This sample uses OfType to return only the elements of the array that are of type double.")]
        static void Linq57()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            doubles.ForEach(Console.WriteLine);
        }        

    }
}
