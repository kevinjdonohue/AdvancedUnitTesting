using FluentAssertions;
using Moq;
using System.Collections.Generic;
using TestDataBuilder;
using Xunit;

namespace TestDataBuilderTests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void GetAllEmployees_ShouldReturnEmployeesFromTheDB()
        {
            //arrange
            EmployeeService employeeService = new EmployeeServiceBuilder().WithRealServices();

            //act
            List<Employee> allEmployees = employeeService.GetAllEmployees();

            //assert
            allEmployees.Should().HaveCount(2);
            allEmployees.Should().Contain(e => e.FirstName == "Kevin" && e.LastName == "Donohue")
                                 .And.Contain(e => e.FirstName == "Kim" && e.LastName == "Stantus");
        }

        [Fact]
        public void GetAllEmployees_ShouldReturnCorrectValues_Builder()
        {
            //arrange
            Mock<IEmployeeRepository> mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(er => er.RetrieveAllEmployees()).Returns(GetFakeEmployees());
            EmployeeService employeeService = new EmployeeServiceBuilder().WithRepository(mockEmployeeRepository.Object);

            //act
            List<Employee> allEmployees = employeeService.GetAllEmployees();

            //assert
            allEmployees.Should().HaveCount(3);
            allEmployees.Should().Contain(e => e.FirstName == "Fred" && e.LastName == "Flintstone");
            mockEmployeeRepository.Verify(er => er.RetrieveAllEmployees());
        }

        [Fact]
        public void GetAllEmployees_ShouldReturnCorrectValues_Fixture()
        {
            //arrange
            EmployeeServiceFixture fixture = new EmployeeServiceFixture();
            EmployeeService employeeService = fixture.CreateSut();
            Mock<IEmployeeRepository> mockEmployeeRepository = fixture.EmployeeRepository.AsMock();
            mockEmployeeRepository.Setup(er => er.RetrieveAllEmployees()).Returns(GetFakeEmployees());

            //act
            List<Employee> allEmployees = employeeService.GetAllEmployees();

            //assert
            allEmployees.Should().HaveCount(3);
            allEmployees.Should().Contain(e => e.FirstName == "Fred" && e.LastName == "Flintstone");
            mockEmployeeRepository.Verify(er => er.RetrieveAllEmployees());
        }


        private static List<Employee> GetFakeEmployees()
        {
            return new List<Employee>()
            {
                new EmployeeBuilder().WithFirstName("Fred").WithLastName("Flintstone"),
                new EmployeeBuilder().WithFirstName("Wilma").WithLastName("Flintstone"),
                new EmployeeBuilder().WithFirstName("Barney").WithLastName("Rubble")
            };
        }
    }
}
