using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthMonitor.DataAccess.DataContext;
using HealthMonitor.DataAccess.Entities;
using HealthMonitor.Api.Models;

namespace HealthMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDataContext _context;

        public EmployeeController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployee()
        {
            return await _context.Employee.Select(emp => emp.ToEmployeeModel()).ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeEntity(Guid id)
        {
            var employeeEntity = await _context.Employee.FindAsync(id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            return employeeEntity.ToEmployeeModel();
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeEntity(Guid id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.UId)
            {
                return BadRequest();
            }

            _context.Entry(employeeModel.ToEmployeeEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeEntity(EmployeeModel employeeModel)
        {
            employeeModel.UId = Guid.NewGuid();
            _context.Employee.Add(employeeModel.ToEmployeeEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeEntity", new { id = employeeModel.UId }, employeeModel);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeEntity(Guid id)
        {
            var employeeEntity = await _context.Employee.FindAsync(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employeeEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeEntityExists(Guid id)
        {
            return _context.Employee.Any(e => e.UId == id);
        }
    }

    public static class EmployeeExtensions
    {
        public static EmployeeModel ToEmployeeModel(this EmployeeEntity employeeEntity)
        {
            return new EmployeeModel()
            {
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                Gender = employeeEntity.Gender,
                Height = employeeEntity.Height,
                UId = employeeEntity.UId,
                Weight = employeeEntity.Weight
            };
        }
        public static EmployeeEntity ToEmployeeEntity(this EmployeeModel employeeModel)
        {
            return new EmployeeEntity()
            {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Gender = employeeModel.Gender,
                Height = employeeModel.Height,
                UId = employeeModel.UId,
                Weight = employeeModel.Weight
            };
        }
    }
}
