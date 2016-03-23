using System.Collections.Generic;

namespace TestDataBuilder
{
    public class EmployeeService
    {
        private ILogger _logger;
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(ILogger logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.RetrieveAllEmployees();
        }
    }
}
