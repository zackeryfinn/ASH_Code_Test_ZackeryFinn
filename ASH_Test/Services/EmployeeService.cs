using ASH_Test.DbContexts;
using ASH_Test.Interfaces;
using ASH_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ASH_Test.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _employeeContext;
        private ILogger _logger;

        public EmployeeService(EmployeeContext employeeContext, ILogger logger)
        {
            _employeeContext = employeeContext;
            _logger = logger;

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employeeContext.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Employee>();
            }
        }

        public async Task<string> CreateEmployee(Employee employee)
        {
            try
            {
                await _employeeContext.Employees.AddAsync(employee);

                return $"Successfully updated the following employee: {employee.FirstName} {employee.LastName}";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return $"An error occured updated the following employee: {employee.FirstName} {employee.LastName}. Error: {ex.Message}";
            }
        }
    }
}