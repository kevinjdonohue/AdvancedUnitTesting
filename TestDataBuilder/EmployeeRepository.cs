using System.Collections.Generic;

namespace TestDataBuilder
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> RetrieveAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee(1, "Kevin", "Donohue", new System.DateTime(1973, 8, 19), new Address("123 Main St", "", "Burien", "Washington", 98166)),
                new Employee(2, "Kim", "Stantus", new System.DateTime(1970, 10, 8), new Address("456 Maple Ave", "", "Portland", "Oregon", 97201))
            };
        }
    }
}
