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

        public async Task<Department> Delete(int id)
        {
            _dataContext.Department.Remove(_dataContext.Department.Find(id));
            _dataContext.Incharge.RemoveRange(_dataContext.Incharge.Where(x => x.DepartmentId == id).ToArray());

            await _dataContext.SaveChangesAsync();
            return new Department();
        }

        public async Task<string> GetDepartmentNameById(int? id)
        {
            var department = await _dataContext.Department.FindAsync(id);

            if (department != null)
            {
                return department.Name;
            }

            return string.Empty;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dataContext.Department.ToListAsync();
        }

        public async Task<Department> Department(Department department)
        {
            await _dataContext.Department.AddAsync(department);

            await _dataContext.SaveChangesAsync();

            var departmentId = (await _dataContext.Department.ToListAsync()).Max(x => x.Id);

            foreach (var incharge in department.Incharge)
            {
                if (!string.IsNullOrEmpty(incharge.InchargeName))
                {
                    incharge.DepartmentId = departmentId;
                    _dataContext.Incharge.Add(incharge);
                }
            }
            await _dataContext.SaveChangesAsync();
            return new Department();
        }

        public async Task<Department> Get(int id)
        {
            var department = await _dataContext.Department.FirstOrDefaultAsync(x => x.Id == id);
            return department;
        }

        public async Task<Department> UpdateDepartment(Department Department)
        {
            var department = await _dataContext.Department.FindAsync(Department.Id);
            if (department != null)
            {
                department.Name = Department.Name;

                await _dataContext.SaveChangesAsync();
            }
            return department;
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var departments = await _dataContext.Department.ToListAsync();
            return departments; ;
        }
    }
}