using DemoMvc.Models;
using NuGet.Common;

namespace DemoMvc.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<string> GetDepartmentNameById(int? id);

        Task<Department> Department(Department department);

        Task<Department> Get(int id);

        Task<IEnumerable<Department>> GetAllDepartment();

        Task<Department> UpdateDepartment(Department department);

        Task<Department> Delete(int id);
    }
}