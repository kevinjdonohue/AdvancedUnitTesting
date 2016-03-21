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
            string actualFullName = employee.getFullName();

            //assert
            actualFullName.Should().Be("Kevin Donohue");
        }

        [Fact]
        public void GetAge_ShouldReturnCorrectValue()
        {
            //arrange
            Employee employee = new EmployeeBuilder().WithBirthDate(new DateTime(1973, 8, 19));

            //act
            int actualAge = employee.getAge();

            //assert
            actualAge.Should().Be(42);
        }
    }
}
