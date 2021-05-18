using Northwind.Traders.Employees.DataAccess.IRepositories;
using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.DataAccess.Wrapper
{
    public interface IUnitOfWork : IDisposable
    {
        // Each repository property checks whether the repository already exists.
        // If not, it instantiates the repository, passing in the context instance.
        // As a result, all repositories share the same context instance.
        IEmployeeRepository EmployeeRepository { get; }
        Task Save();
    }
}
