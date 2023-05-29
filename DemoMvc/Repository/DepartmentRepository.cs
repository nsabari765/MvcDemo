using DemoMvc.Data;
using DemoMvc.Models;
using DemoMvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _dataContext;

        public DepartmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> GetDepartmentNameById(int? id)
        {
            var department = await _dataContext.Departments.FindAsync(id);

            if (department != null)
            {
                return department.Name;
            }

            return string.Empty;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dataContext.Departments.ToListAsync();
        }
    }
}