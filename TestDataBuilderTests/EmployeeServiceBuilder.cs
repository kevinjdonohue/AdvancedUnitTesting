using Moq;
using TestDataBuilder;

namespace TestDataBuilderTests
{
    public class EmployeeServiceBuilder
    {
        private ILogger _logger;
        private IEmployeeRepository _employeeRepository;

        public EmployeeServiceBuilder()
        {
            _logger = new Mock<ILogger>().Object;
            _employeeRepository = new Mock<IEmployeeRepository>().Object;
        }

        public EmployeeServiceBuilder WithLogger(ILogger newLogger)
        {
            _logger = newLogger;
            return this;
        }

        public EmployeeServiceBuilder WithRepository(IEmployeeRepository newEmployeeRepository)
        {
            _employeeRepository = newEmployeeRepository;
            return this;
        }

        public EmployeeServiceBuilder WithRealServices()
        {
            _logger = new BasicLogger();
            _employeeRepository = new EmployeeRepository();
            return this;
        }

        public EmployeeService Build()
        {
            return new EmployeeService(_logger, _employeeRepository);
        }

        //Operator Overload
        public static implicit operator EmployeeService(EmployeeServiceBuilder employeeServiceBuilder)
        {
            return employeeServiceBuilder.Build();
        }
    }
}
