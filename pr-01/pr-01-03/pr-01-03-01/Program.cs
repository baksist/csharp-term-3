using System;

namespace pr_01_03_01
{
    class Program
    {
        class Person
        {
            public enum Genders : int
            {
                Male,
                Female
            };

            public string firstName;
            public string lastName;
            public int age;
            public Genders gender;

            public Person(string _firstName, string _lastName, int _age, Genders _gender)
            {
                firstName = _firstName;
                lastName = _lastName;
                age = _age;
                gender = _gender;
            }

            public override string ToString()
            {
                return firstName + " " + lastName + " (" + gender + "), age " + age;
            }
        }

        class Manager : Person
        {
            public string phoneNumber;
            public string officeLocation;

            public Manager(string _firstName, string _lastName, int _age, Genders _gender, string _phoneNumber,
                string _office_location) : base(_firstName, _lastName, _age, _gender)
            {
                phoneNumber = _phoneNumber;
                officeLocation = _office_location;
            }

            public override string ToString()
            {
                return base.ToString() + ", " + phoneNumber + ", " + officeLocation;
            }
        }

        static void Main(string[] args)
        {
            Manager m = new Manager("Tony", "Allen", 32, Person.Genders.Male, "88005553535",
                "Pushkina St., Kolotushkina house");
            Console.WriteLine(m);
        }
    }
}