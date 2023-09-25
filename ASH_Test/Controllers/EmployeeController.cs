using ASH_Test.Interfaces;
using ASH_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASH_Test.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public async Task<List<Employee>> Get()
        {
                return await _employeeService.GetAllEmployees();
        }

        [HttpPost("createEmployee")]
        public async Task<string> CreateEmployee([FromBody] Employee employee) 
        {
            return await _employeeService.CreateEmployee(employee);
            
        }

    }
}