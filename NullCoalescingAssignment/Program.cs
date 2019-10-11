using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace NullCoalescingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //NullCoalescingAssignment();
            //UsingStatement();
            //ReadonlyMembers();
            //StaticLocalFunctions();
            //InterpolatedVerbatimStrings();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void UnmanagedConstraint()
        {
            throw new NotImplementedException();
        }

        private static void InterpolatedVerbatimStrings()
        {
            var name = "John";
            var query = @$"SELECT *
                            FROM CUSTOMER
                            WHERE NAME = '{name}'";

            var query2 = $@"SELECT *
                            FROM CUSTOMER
                            WHERE NAME = '{name}'";
        }

        private static void StaticLocalFunctions()
        {
            int M()
            {
                int y;
                LocalFunction();
                return y;

                void LocalFunction() => y = 0;
            }

            int M2()
            {
                int y = 5;
                int x = 7;
                return Add(x, y);

                static int Add(int left, int right) => left + right;
            }
        }

        private static void ReadonlyMembers()
        {
            throw new NotImplementedException();
        }

        private static void NullCoalescingAssignment()
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

        private static void UsingStatement()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Update))
                {

                    using (var streamWriter = new StreamWriter(archive.CreateEntry("").Open(), Encoding.UTF8))
                    {
                        streamWriter.Write(new char[0]);
                    }
                }
            }



            //using var memoryStream = new MemoryStream();
            //using var archive = new ZipArchive(memoryStream, ZipArchiveMode.Update);
            //using var streamWriter = new StreamWriter(archive.CreateEntry("").Open(), Encoding.UTF8);
            //await streamWriter.WriteAsync(new char[0]);
        }

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Distance => Math.Sqrt(X * X + Y * Y);

            public override readonly string ToString() =>
                $"({X}, {Y}) is {Distance} from the origin";
        }
    }
}
