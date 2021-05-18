using Northwind.Traders.Employees.DataAccess.Wrapper;
using Northwind.Traders.Employees.Infrastructure.IServices;
using Northwind.Traders.Employees.Logging;
using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly INLogManager logger;
        private IUnitOfWork unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork, INLogManager logger)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            logger.Info("Retrieving all employees data");
            var allEmployees = await this.unitOfWork.EmployeeRepository.GetAllAsync();
            return allEmployees;
        }
    }
}
