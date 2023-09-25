using ASH_Test.Models;

namespace ASH_Test.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<string> CreateEmployee(Employee employee);

    }
}
