using Northwind.Traders.Employees.DataAccess.IRepositories;
using Northwind.Traders.Employees.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly northwindtradersContext northwindtradersContext;

        public GenericRepository(northwindtradersContext northwindtradersContext)
        {
            this.northwindtradersContext = northwindtradersContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await this.northwindtradersContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.northwindtradersContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.northwindtradersContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await this.northwindtradersContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            this.northwindtradersContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.northwindtradersContext.Set<T>().Update(entity);
        }
    }
}
