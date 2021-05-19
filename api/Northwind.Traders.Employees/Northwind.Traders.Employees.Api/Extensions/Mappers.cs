using Northwind.Traders.Employees.Model.Contracts;
using Northwind.Traders.Employees.Model.Entities;

namespace Northwind.Traders.Employees.Api.Extensions
{
    public static class Extensions
    {
        public static EmployeeDTO AsDTO(this Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath,
                ReportsToNavigation = employee.ReportsToNavigation /* Stop recursive mapping */,
                EmployeeTerritories = employee.EmployeeTerritories,
                InverseReportsToNavigation = employee.InverseReportsToNavigation
            };
        }
    }
}
