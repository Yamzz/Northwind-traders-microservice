using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Infrastructure.IServices
{
    public interface IEmployeeService
    {
       Task<IEnumerable<Employee>> GetAllEmployees();
    }
}
