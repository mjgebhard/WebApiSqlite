using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApiSqlite.Data;
using WebApiSqlite.Migrations;
using WebApiSqlite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly WebApiSqliteContext _context;
        public EmployeeController(WebApiSqliteContext context)
        {
            _context = context;
        }

        //[HttpGet("/api/Employee/test")]
        //public async Task<Employee> GetEmployeesTest()
        //{
        //    Department department = new Department()
        //    {
        //        Name = "IT"
        //    };

        //    _context.Departments.Add(department);
        //    await _context.SaveChangesAsync();

        //    Employee employee = new Employee()
        //    {
        //        DepartmentId = 1,
        //        HireDate = DateTime.Now,
        //        Name = "Hello",
        //        Occupation = "IT",
        //        Surname = "World"
        //    };

        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return employee;
        //}

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.Include(a => a.Department).ToListAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("/api/Employee/GetEmployeeByName/{name}/{surname}")]
        public async Task<ActionResult> GetEmployeeByName(string name, string surname)
        {
            var result = await _context.Employees
                .Where(e => e.Name.ToLower() == name.ToLower() & e.Surname.ToLower() == surname.ToLower())
                .Select(e => new { id = e.EmployeeId, deptId = e.DepartmentId }).ToListAsync();

            if (result == null | result?.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            Employee? developer = await _context.Employees
                .Include(a => a.Department)
                .FirstOrDefaultAsync(d => d.EmployeeId == id);

            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostAsync([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
