using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly DataContactAPI _dataContext;

        public DepartmentController(DataContactAPI dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _dataContext.Department.ToListAsync());
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            await _dataContext.Department.AddAsync(department);
            await _dataContext.SaveChangesAsync();
            return Ok(department);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var find = await _dataContext.Department.FindAsync(id);

            if (find != null)
            {
                return Ok(find);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, Department UpdateDepartment)
        {
            var find = await _dataContext.Department.FindAsync(id);

            if (find != null)
            {
                find.DepartmentName = UpdateDepartment.DepartmentName;
                find.DepartmentHODName = UpdateDepartment.DepartmentHODName;

                await _dataContext.SaveChangesAsync();
                return Ok(find);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var find = await _dataContext.Department.FindAsync(id);

            if (find != null)
            {
                _dataContext.Remove(find);
                await _dataContext.SaveChangesAsync();
                return Ok(find);
            }
            return NotFound("This Id is Not Found");
        }
    }
}