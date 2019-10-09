using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

namespace IndexesAndRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexesAndRanges();
            RangesImplementationExample();
        }

        public static void IndexesAndRanges()
        {
            var words = new string[]
                        {
                            // index from start    index from end
                            "The",    // 0                   ^9
                            "quick",  // 1                   ^8
                            "brown",  // 2                   ^7
                            "fox",    // 3                   ^6
                            "jumped", // 4                   ^5
                            "over",   // 5                   ^4
                            "the",    // 6                   ^3
                            "lazy",   // 7                   ^2
                            "dog"     // 8                   ^1
                        };            // 9 (or words.Length) ^0

            Console.WriteLine($"The last word is {words[^1]}");

            var obsolete = words.ToList().GetRange(1, 3);

            // initialization
            var x = new Index(1, true);
            var y = ^1;
            var z = words.Length-1;
            Console.WriteLine($"x : {words[x]}, y: {words[y]}, z: {words[z]}");

            // range examples
            var a = 1..8;
            var b = 1..;
            var c = 0..8;
            var d = 0..;
            var e = ..;

            //var e = words[8..1]; throw ArgumentOutOfRangeException
            Console.WriteLine($"a length : {words[a].Length}, b length: {words[b].Length}");


            var lazyDog       = words[^2..^0];

            var allWords    = words[..];  // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase  = words[6..]; // contains "the", "lazy" and "dog"

            // declare as a variable
            Range phrase = 1..4;

            // The range can then be used inside the [ and ] characters
            var text = words[phrase];
        }

        /// <summary>
        /// For each hundred, print min, max and average values for first and last 10 elements
        /// </summary>
        public static void RangesImplementationExample()
        {
            int[] sequence = Sequence(100);

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = start..(start + 10);
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:    \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = ^(start + 10)..^start;
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:  \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            (int min, int max, double average) MovingAverage(int[] subSequence, Range range) =>
                (
                    subSequence[range].Min(),
                    subSequence[range].Max(),
                    subSequence[range].Average()
                );

            int[] Sequence(int count) =>
                Enumerable.Range(0, count).Select(x => (int) (Math.Sqrt(x) * 100)).ToArray();
        }
    }
}
