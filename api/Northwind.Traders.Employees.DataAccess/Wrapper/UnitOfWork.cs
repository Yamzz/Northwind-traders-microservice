using Northwind.Traders.Employees.DataAccess.IRepositories;
using Northwind.Traders.Employees.DataAccess.Repositories;
using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.DataAccess.Wrapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private northwindtradersContext northwindtradersContext;

        private IEmployeeRepository employeeRepository;

        public UnitOfWork(northwindtradersContext northwindtradersContext)
        {
            this.northwindtradersContext = northwindtradersContext;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if(employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(this.northwindtradersContext);
                }
                return this.employeeRepository;
            }
        }

        public async Task Save()
        {
            await this.northwindtradersContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    this.northwindtradersContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
