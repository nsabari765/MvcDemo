using DemoMvc.Models;

namespace DemoMvc.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<string> GetDepartmentNameById(int? id);
    }
}