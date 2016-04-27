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

        public string FirstName
        {
            get
            {
                return _firstName;

            }
        }

        public string LastName
        {
            get
            {
                return _lastName;

            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
        }

        public Address Address
        {
            get
            {
                return _address;
            }
        }

        public Employee(int id, string firstName, string lastName, DateTime birthDate, Address address)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
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

        public override bool Equals(object obj)
        {
            Employee employee = obj as Employee;

            if (employee != null)
            {
                return this.FirstName == employee.FirstName
                    && this.LastName == employee.LastName;
            }

            return base.Equals(obj);
        }
    }
}
