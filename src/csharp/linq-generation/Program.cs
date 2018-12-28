using System;
using System.ComponentModel;
using System.Linq;
using linqshared;

namespace linq_generation
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            //Linq65();
            Linq66();
        }

        [Category("Generation Operators")]
        [Description(@"This sample uses Range to generate a sequence of numbers from 100 to 149
                       that is used to find which numbers in that range are odd and even.")]
        static void Linq65()
        {
            var numbers = Enumerable.Range(100, 50)
                .Select(n => new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" });

            numbers.ForEach((n) => Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven));
        }

        [Category("Generation Operators")]
        [Description("This sample uses Repeat to generate a sequence that contains the number 7 ten times.")]
        static void Linq66()
        {
            var numbers = Enumerable.Repeat(7, 10);

            numbers.ForEach(Console.WriteLine);
        }        

    }
}
