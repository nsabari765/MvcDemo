using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly DataContext _dataContext;
        public readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(DataContext dataContext, IDepartmentRepository departmentRepository)
        {
            _dataContext = dataContext;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _departmentRepository.GetDepartments());
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            return Ok(await _departmentRepository.AddDepartment(department));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            return Ok(await _departmentRepository.GetDepartmentById(id));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, Department UpdateDepartment)
        {
            return Ok(await _departmentRepository.UpdateDepartment(id, UpdateDepartment));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            return Ok(await _departmentRepository.DeleteDepartment(id));
        }
    }
}