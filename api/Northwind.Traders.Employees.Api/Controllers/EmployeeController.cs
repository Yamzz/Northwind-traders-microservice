using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Traders.Employees.Api.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly INLogManager _logger;

        public EmployeeController(INLogManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.Info("Here is info message from the controller.");
            _logger.Debug("Here is debug message from the controller.");
            _logger.Warn("Here is warn message from the controller.");
            _logger.Error("Here is error message from the controller.");
            _logger.Error("Here is error message from the controller.", new Exception("TEST EXCEPTION"));


            throw new Exception("Exception while fetching all the students from the storage.");

            return new List<string>();
        }
    }
}
