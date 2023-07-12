using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> AddDepartment(Department department);

        Task<Department> GetDepartmentById(int id);

        Task<Department> UpdateDepartment(int id, Department UpdateDepartment);

        Task<Department> DeleteDepartment(int id);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _dataContext;

        public DepartmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            var data = new Department()
            {
                DepartmentHODName = department.DepartmentHODName,
                DepartmentName = department.DepartmentName
            };
            await _dataContext.Department.AddAsync(data);
            await _dataContext.SaveChangesAsync();
            return data;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var find = await _dataContext.Department.FindAsync(id);
            if (find != null)
            {
                _dataContext.Remove(find);
                await _dataContext.SaveChangesAsync();
                return find;
            }
            return null;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dataContext.Department.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var find = await _dataContext.Department.FindAsync(id);

            if (find != null)
            {
                return find;
            }

            return null;
        }

        public async Task<Department> UpdateDepartment(int id, Department UpdateDepartment)
        {
            var find = await _dataContext.Department.FindAsync(id);

            if (find != null)
            {
                find.DepartmentHODName = UpdateDepartment.DepartmentHODName;
                find.DepartmentName = UpdateDepartment.DepartmentName;

                await _dataContext.SaveChangesAsync();
                return find;
            }
            return null;
        }
    }
}