using System;

namespace pr_01_01_01
{
    class Program
    {
        struct Person
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public Person(string firstName, string lastName, int age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }
            public override string ToString() 
            {
                return FirstName + " " + LastName + ", age " + Age;
            }
        }
        static void Main(string[] args)
        {
            Person p = new Person("Tony", "Allen", 32);
            Console.WriteLine(p);
        }
    }
}