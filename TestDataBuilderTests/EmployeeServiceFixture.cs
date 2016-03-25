using Moq;
using TestDataBuilder;

namespace TestDataBuilderTests
{
    public class EmployeeServiceFixture
    {
        private readonly ILogger _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public IEmployeeRepository EmployeeRepository { get { return _employeeRepository; } }

        public ILogger Logger { get { return _logger; } }

        public EmployeeServiceFixture()
        {
            _logger = new Mock<ILogger>().Object;
            _employeeRepository = new Mock<IEmployeeRepository>().Object;
        }

        public EmployeeService CreateSut()
        {
            return new EmployeeService(_logger, _employeeRepository);
        }
    }
}
