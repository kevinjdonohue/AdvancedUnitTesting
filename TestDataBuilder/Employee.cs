using System;

namespace TestDataBuilder
{
    public class Employee
    {
        private readonly int _id;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly DateTime _birthDate;
        private readonly Address _address;

        public Employee(int id, string firstName, string lastName, DateTime birthDate, Address address)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
            _address = address;
        }

        public string getFullName()
        {
            return string.Format("{0} {1}", this._firstName, this._lastName);
        }

        public int getAge()
        {
            DateTime today = DateTime.Today;
            int age = (today.Year - _birthDate.Year);
            if (_birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
            //return (_birthDate > today.AddYears(-age)) ? age-- : age;
        }
    }
}
