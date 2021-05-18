using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Traders.Employees.Infrastructure.IServices;
using Northwind.Traders.Employees.Logging;
using Northwind.Traders.Employees.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly INLogManager logger;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService, INLogManager logger)
        {
            this.logger = logger;
            this.employeeService = employeeService;
        }


        /// <summary>
        /// Gets the list of all Employees
        /// </summary>
        /// <response code="201"> All Employee items</response>
        [HttpGet("Employees")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Employee>>> Employees()
        {
           var employees = await this.employeeService.GetAllEmployees();
           
           if (employees == null)
           {
               logger.Warn("No employees data not found in the datbase");
               return this.NotFound("Employees data not found");
           }

           logger.Info("Employees request successfully completed");
           return this.Ok(employees);
        }
    }
}
