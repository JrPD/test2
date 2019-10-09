using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace PatternMatchingImprovement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Switch();
            //Property();
            //Tuple();
            //Positional();

            Console.ForegroundColor = ConsoleColor.Black;
        }

        #region Switch

        public static void Switch()
        {
            var color = FromRainbow(Rainbow.Blue);
            Console.WriteLine($"Color: {color.R} {color.G} {color.B}");
        }

        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        internal class RGBColor
        {
            public int R;
            public int G;
            public int B;

            public RGBColor(int r, int g, int b)
            {
                this.R = r;
                this.G = g;
                this.B = b;
            }
        }

        public static RGBColor FromRainbow(Rainbow colorBand)
        {
            switch (colorBand)
            {
                case Rainbow.Red:
                    return new RGBColor(0xFF, 0x00, 0x00);
                case Rainbow.Orange:
                    return new RGBColor(0xFF, 0x7F, 0x00);
                case Rainbow.Yellow:
                    return new RGBColor(0xFF, 0xFF, 0x00);
                case Rainbow.Green:
                    return new RGBColor(0x00, 0xFF, 0x00);
                case Rainbow.Blue:
                    return new RGBColor(0x00, 0x00, 0xFF);
                case Rainbow.Indigo:
                    return new RGBColor(0x4B, 0x00, 0x82);
                case Rainbow.Violet:
                    return new RGBColor(0x94, 0x00, 0xD3);
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
            }

            ;
        }

        #endregion

        #region Property

        private static void Property()
        {
            var address = new Address() { State = "MN" };
            Console.WriteLine($"Tax: {ComputeSalesTax(address, 10)}");

            var addressWithWrongState = new Address() { State = "NA" };
            Console.WriteLine($"Tax for address with wrong state: {ComputeSalesTax(addressWithWrongState, 10)}");
        }

        public class Address
        {
            public string State { get; set; }
        }

        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
            location switch
            {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.75M,
                { State: "MI" } => salePrice * 0.05M,
                _ => 0M
            };

        #endregion

        #region Tuple

        private static void Tuple()
        {
            Console.WriteLine($"Game result for paper, rock: {RockPaperScissors("paper", "rock")}");
            Console.WriteLine($"Game result for scissors, paper: {RockPaperScissors("scissors", "paper")}");
            Console.WriteLine($"Game result for scissors, scissors: {RockPaperScissors("scissors", "scissors")}");
        }

        public static string RockPaperScissors(string first, string second)
            => (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                ("paper", "rock") => "paper covers rock. Paper wins.",
                ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };

        #endregion

        #region Positional

        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) =>
                (x, y) = (X, Y);
        }

        public enum Quadrant
        {
            Unknown,
            Origin,
            One,
            Two,
            Three,
            Four,
            OnBorder
        }

        static Quadrant GetQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };

        private static void Positional()
        {
            var point = new Point(0, 0);
            Console.WriteLine($"For point {point.X}, {point.Y} - quadrant is {GetQuadrant(point)}");
            
            point  = new Point(8,-3);
            Console.WriteLine($"For point {point.X}, {point.Y} - quadrant is {GetQuadrant(point)}");

        }

        #endregion
    }
}
