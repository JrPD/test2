using System;
using System.Collections.Generic;

namespace NullCoalescingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = null;
            int? a = null;

            numbers ??= new List<int>();
            numbers.Add(5);
            Console.WriteLine(string.Join(" ", numbers));  // output: 5

            numbers.Add(a ??= 0);
            Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
            Console.WriteLine(a);  // output: 0

            Console.ReadKey();
        }
    }
}
