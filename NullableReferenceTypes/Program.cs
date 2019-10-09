using System;

namespace NullableReferenceTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person("Ivan", null, "Tsurkan");
            Console.WriteLine(person.GetPersonNameLength);
        }
    }

    public class Person
    {
        public string  FirstName  { get; set; }
        public string? MiddleName { get; set; }
        public string  LastName   { get; set; }

        public Person(string firstName, string? middleName, string lastName) =>
            (FirstName, MiddleName, LastName) = (firstName, middleName, lastName);

        public int GetPersonNameLength => FirstName.Length + GetMiddleNameLength() + LastName.Length;

        private int GetMiddleNameLength()
        {
            return MiddleName.Length;
        }
    }
}
