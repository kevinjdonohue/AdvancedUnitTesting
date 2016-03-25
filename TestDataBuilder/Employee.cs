using System;

namespace TestDataBuilder
{
    public class Employee
    {
        private readonly int _id;
        private readonly DateTime _birthDate;
        private readonly Address _address;

        public string FirstName { get; }

        public string LastName { get; }

        public Employee(int id, string firstName, string lastName, DateTime birthDate, Address address)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            _birthDate = birthDate;
            _address = address;
        }

        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - _birthDate.Year;
            if (_birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public Address GetAddress()
        {
            return _address;
        }
    }
}
