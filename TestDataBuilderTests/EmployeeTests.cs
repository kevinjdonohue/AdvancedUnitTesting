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

            //ORIGINAL - Using just the constructor:

            //string expectedFirstName = "Kevin";
            //string expectedLastName = "Donohue";
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
            actualFullName.Should().Be("Kevin Donohue");
        }

        [Fact]
        public void GetAge_ShouldReturnCorrectValue()
        {
            //arrange
            Employee employee = new EmployeeBuilder().WithBirthDate(new DateTime(1973, 8, 19));

            //act
            int actualAge = employee.GetAge();

            //assert
            actualAge.Should().Be(42);
        }

        [Fact]
        public void GetAddress_ShouldReturnCorrectValue()
        {
            //arrange
            Address employeeAddress = new AddressBuilder().WithCity("Burien").WithState("Washington").WithZipCode(98166).WithLine1("16429 11th Ave SW").WithLine2("");
            Employee employee = new EmployeeBuilder().WithAddress(employeeAddress);

            //act
            Address actualAddress = employee.GetAddress();

            //assert
            actualAddress.Should().NotBeNull();
            actualAddress.Line1.Should().Be("16429 11th Ave SW");
            actualAddress.Line2.Should().Be("");
            actualAddress.City.Should().Be("Burien");
            actualAddress.State.Should().Be("Washington");
            actualAddress.ZipCode.Should().Be(98166);
        }

        [Fact]
        public void GetAddress_AddressesShouldBeEqual()
        {
            //arrange
            Address expectedAddress = new AddressBuilder().WithCity("Burien").WithState("Washington").WithZipCode(98166).WithLine1("16429 11th Ave SW").WithLine2("");
            Address employeeAddress = new AddressBuilder().WithCity("Burien").WithState("Washington").WithZipCode(98166).WithLine1("16429 11th Ave SW").WithLine2("");
            Employee employee = new EmployeeBuilder().WithAddress(employeeAddress);

            //act
            Address actualAddress = employee.GetAddress();

            //assert
            actualAddress.ShouldBeEquivalentTo(expectedAddress);  //object graph comparison - equally named properties with the same value
            //actualAddress.Should().Be(expectedAddress);
        }
    }
}
