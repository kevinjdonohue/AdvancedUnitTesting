using FluentAssertions;
using System;
using TestDataBuilder;
using Xunit;

namespace TestDataBuilderTests
{

    public class EmployeeTests
    {
        [Fact]
        public void GetFullName_ShouldReturnFullNameCombination()
        {
            //arrange
            const string expectedFirstName = "Kevin";
            const string expectedLastName = "Donohue";
            string expectedFullName = string.Format("{0} {1}", expectedFirstName, expectedLastName);

            //ORIGINAL - Using just the constructor:
            //DateTime expectedBirthDate = new DateTime(1973, 8, 19);
            //Address expectedAddress = new Address("16429 11TH AVE SW", "", "BURIEN", "WASHINGTON", 98166);
            //Employee employee = new Employee(1, expectedFirstName, expectedLastName, expectedBirthDate, expectedAddress);

            //SECOND GEN - Using the test data builder pattern:
            //EmployeeBuilder employeeBuilder = new EmployeeBuilder().WithFirstName("Kevin").WithLastName("Donohue");
            //Employee employee = employeeBuilder.Build();

            //FINAL GEN - Using the test data builder pattern w/ an operator overload
            Employee employee = new EmployeeBuilder().WithFirstName("Kevin").WithLastName("Donohue");

            //act
            string actualFullName = employee.GetFullName();

            //assert
            actualFullName.Should().Be(expectedFullName);
        }

        [Fact]
        public void GetAge_ShouldReturnCorrectValue()
        {
            //arrange
            const int expectedAge = 42;
            Employee employee = new EmployeeBuilder().WithBirthDate(new DateTime(1973, 8, 19));

            //act
            int actualAge = employee.GetAge();

            //assert
            actualAge.Should().Be(expectedAge);
        }

        [Fact]
        public void GetAddress_AddressesShouldBeEqual()
        {
            //arrange
            Address expectedAddress = new AddressBuilder().WithCity("Burien").WithState("Washington").WithZipCode(98166).WithLine1("16429 11th Ave SW").WithLine2("");
            Address employeeAddress = new AddressBuilder().WithCity("Burien").WithState("Washington").WithZipCode(98166).WithLine1("16429 11th Ave SW").WithLine2("");
            Employee employee = new EmployeeBuilder().WithAddress(employeeAddress);

            //act
            Address actualAddress = employee.Address;

            //assert
            actualAddress.ShouldBeEquivalentTo(expectedAddress);  //object graph comparison - equally named properties with the same value
        }

        [Fact]
        public void EqualsReturnsCorrectResult()
        {
            //arrange
            Employee sut = new Employee(1, "Kevin", "Donohue", new DateTime(1973, 9, 19), new Address("line 1", "line 2", "city", "state", 12345));

            //act
            bool actual = sut.Equals(new Employee(1, "Kevin", "Donohue", new DateTime(1973, 9, 19), new Address("line 1", "line 2", "city", "state", 12345)));

            //assert
            actual.Should().Be(true);
        }

        [Fact]
        public void EqualsAnyOtherObjectReturnsFalse()
        {
            //arrange
            Employee sut = new Employee(1, "Kevin", "Donohue", new DateTime(1973, 9, 19), new Address("line 1", "line 2", "city", "state", 12345));
            object someObject = "foo";

            //act
            bool actual = sut.Equals(someObject);

            //assert
            actual.Should().Be(false);
        }

        [Fact]
        public void EmployeesShouldBeEqual()
        {
            //arrange
            Employee expected = new Employee(1, "Kevin", "Donohue", new DateTime(1973, 9, 19), new Address("line 1", "line 2", "city", "state", 12345));

            //act
            Employee actual = new Employee(1, "Kevin", "Donohue", new DateTime(1973, 9, 19), new Address("line 1", "line 2", "city", "state", 12345));

            //assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
