using System;
namespace pr_06
{
    public class Person
    {
        private string _name;
        private string _surname;
        private DateTime _birthDate;

        public Person(string name, string surname, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
        }

        public Person()
        {
            _name = "DefaultName";
            _surname = "DefaultSurname";
            _birthDate = DateTime.UnixEpoch;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public int BirthYear
        {
            get => _birthDate.Year;
            set
            {
                var newDate = new DateTime(value, _birthDate.Month, _birthDate.Day);
                _birthDate = newDate;
            }
        }
        public override string ToString()
        {
            return _name + ' ' + _surname + ' ' + _birthDate.ToString("dd/MM/yyyy");
        }

        public string ToShortString()
        {
            return _name + ' ' + _surname;
        }
    }
}