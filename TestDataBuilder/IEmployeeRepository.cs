using System.Collections.Generic;

namespace TestDataBuilder
{
    public interface IEmployeeRepository
    {
        List<Employee> RetrieveAllEmployees();
    }
}