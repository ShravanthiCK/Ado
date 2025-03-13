using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System;
using WebApiDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {

        private readonly EmpContext _context;
        public EmpController(EmpContext context)
        {
            _context = context;
        }
        public static List<Employee> emps = new List<Employee>()
            {
                new Employee{Id=1,Name="kiran",place="Bangalore"},
                new Employee{Id=2,Name="mahesh",place="chennai"},
                new Employee{Id=3,Name="santosh",place="Delhi"},
            };
        [HttpGet]
        public async Task< ActionResult< List<Employee>>> GetEmployees()
        {

            // return Ok(emps);
            return Ok(await _context.Employees.ToListAsync());
        }

        //two post methods based on return type for employee
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
           // emps.Add(employee);
           _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            //return Ok(emps);
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost("emp_Post2")]
        public async Task<ActionResult<Employee>> AddEmployee2(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            // emps.Add(employee);
            return Ok(employee);
        }

        //I want to search one employee base on empid the code is like this 
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            //  var employee=emps.Find(x => x.Id == id);
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
            else
            {
                return Ok(employee);
            }
        }

//        Now i want to update any employee which is nothing but put method again here based on 
//return type of method i will write two put methods and also i will give url different to avoid confusion to swagger ui
//one put is returing that employee which is modified after modifying and another put is modifying and tellig us to see that i am giving a list check there
//whether modified or not okay

 [HttpPut]
 public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            //  var employee1 = emps.Find(x => x.Id == employee.Id);
            var employee1 = await _context.Employees.FindAsync(employee.Id);
            if (employee1 == null)
            {
                return BadRequest("Employee Not Found");
            }
            employee1.Name = employee.Name;
            employee1.place = employee.place;
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut("put2")]
        public async Task<ActionResult<Employee>> UpdateEmployee2(Employee employee)
        {
            // var employee1 = emps.Find(x => x.Id == employee.Id);
            var employee1 = await _context.Employees.FindAsync(employee.Id);
            if (employee1 == null)
            {
                return BadRequest("Employee Not Found");
            }
            employee1.Name = employee.Name;
            employee1.place = employee.place;
            await _context.SaveChangesAsync();
            return Ok(employee1);
        }

//        Now code for delete based on id

//Now i want to delete any employee which is nothing but delete method again here based on 
//return type of method i will write two delete methods and also i will give url different to avoid confusion to swagger ui
//one delete is returing that employee which is deleted after deleting and another delete  is deleting and tellig us to see that i am giving a list check there
//whether deleetd  or not okay

 [HttpDelete("{id}")]
 public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee1 = await _context.Employees.FindAsync(id);
            //  var employee1 = emps.Find(x => x.Id == id);
            if (employee1 == null)
            {
                return BadRequest("Employee Not Found");
            }
            emps.Remove(employee1);
            await _context.SaveChangesAsync();
            return Ok(employee1);
        }
        [HttpDelete("del2/{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee2(int id)
        {
            //  var employee1 = emps.Find(x => x.Id == id);
            var employee1 = await _context.Employees.FindAsync(id);
            if (employee1 == null)
            {
                return BadRequest("Employee Not Found");
            }
            emps.Remove(employee1);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }


    }
}
