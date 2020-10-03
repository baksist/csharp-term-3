using System;

namespace pr_01_01_02
{
    class Program
    {
        struct Person
        {
            public enum Genders : int
            {
                Male,
                Female
            };
            
            public string FirstName;
            public string LastName;
            public int Age;
            public Genders Gender;

            public Person(string firstName, string lastName, int age, Genders gender)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Gender = gender;
            }
            public override string ToString() 
            {
                return FirstName + " " + LastName + " (" + Gender + "), age " + Age;
            }
        }
        static void Main(string[] args)
        {
            Person p = new Person("Tony", "Allen", 32, Person.Genders.Male);
            Console.WriteLine(p);
        }
    }
}