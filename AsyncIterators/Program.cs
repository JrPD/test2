using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncIterators
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            await Demo();

            Console.ForegroundColor = ConsoleColor.White;
        }

        private async static Task Demo()
        {
            await foreach (var item in GetResponses())
            {
                Console.WriteLine($"The time is {DateTime.Now:hh:mm:ss}. Retreived {item}");
            }
        }

        private static async IAsyncEnumerable<string> GetResponses()
        {
            for (int i = 0; i < 50; i++)
            {
                if (i % 5 == 0)
                {
                    await Task.Delay(2000);
                }
                yield return RandomString(30);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
