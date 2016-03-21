using System;
using TestDataBuilder;

namespace TestDataBuilderTests
{
    public class EmployeeBuilder
    {
        private int _id = 1;
        private string _firstName = "first";
        private string _lastName = "last";
        private DateTime _birthDate = DateTime.Today;
        private Address _address = new AddressBuilder().Build();

        public Employee Build()
        {
            return new Employee(_id, _firstName, _lastName, _birthDate, _address);
        }

        //Fluent API - Modification Methods:

        public EmployeeBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public EmployeeBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public EmployeeBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public EmployeeBuilder WithBirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
            return this;
        }

        public EmployeeBuilder WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        //Operator Overload
        public static implicit operator Employee(EmployeeBuilder employeeBuilder)
        {
            return employeeBuilder.Build();
        }
    }
}
