using Northwind.Traders.Employees.DataAccess.IRepositories;
using Northwind.Traders.Employees.Model.Entities;

namespace Northwind.Traders.Employees.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(northwindtradersContext northwindtradersContext) 
            : base(northwindtradersContext)
        {
        }
    }
}
