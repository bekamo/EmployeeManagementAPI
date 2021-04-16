using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbContext _context;

        public EmployeeRepository(EmpDbContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            _context.Employees.Add(emp);
        }

        public void DeleteEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            _context.Employees.Remove(emp);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var list = await _context.Employees.ToListAsync();
            return list;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var getEmp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            return getEmp;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee emp)
        {
            if(_context != null)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }
        }
    }
}
