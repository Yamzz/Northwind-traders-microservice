using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.DataAccess.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
