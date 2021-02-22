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
    public class EmployeeSensorHistoriesController : ControllerBase
    {
        private readonly AppDataContext _context;

        public EmployeeSensorHistoriesController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSensorHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSensorHistoryModel>>> GetEmployeeSensorHistory()
        {
            return await _context.EmployeeSensorHistory.Select(entity => entity.ToEmployeeSensorHistoryModel()).ToListAsync();
        }

        // GET: api/EmployeeSensorHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSensorHistoryEntity>> GetEmployeeSensorHistory(Guid id)
        {
            var employeeSensorHistory = await _context.EmployeeSensorHistory.FindAsync(id);

            if (employeeSensorHistory == null)
            {
                return NotFound();
            }

            return employeeSensorHistory;
        }

        // PUT: api/EmployeeSensorHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSensorHistory(Guid id, EmployeeSensorHistoryModel employeeSensorHistory)
        {
            if (id != employeeSensorHistory.UId)
            {
                return BadRequest();
            }

            _context.Entry(employeeSensorHistory.ToEmployeeSensorHistoryEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSensorHistoryExists(id))
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

        // POST: api/EmployeeSensorHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeSensorHistoryEntity>> PostEmployeeSensorHistory(EmployeeSensorHistoryModel employeeSensorHistory)
        {
            employeeSensorHistory.UId = Guid.NewGuid();
            _context.EmployeeSensorHistory.Add(employeeSensorHistory.ToEmployeeSensorHistoryEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSensorHistory", new { id = employeeSensorHistory.UId }, employeeSensorHistory);
        }

        // DELETE: api/EmployeeSensorHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeSensorHistory(Guid id)
        {
            var employeeSensorHistory = await _context.EmployeeSensorHistory.FindAsync(id);
            if (employeeSensorHistory == null)
            {
                return NotFound();
            }

            _context.EmployeeSensorHistory.Remove(employeeSensorHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeSensorHistoryExists(Guid id)
        {
            return _context.EmployeeSensorHistory.Any(e => e.UId == id);
        }
    }

    public static class EmployeeSesorExtensions
    {
        public static EmployeeSensorHistoryModel ToEmployeeSensorHistoryModel(this EmployeeSensorHistoryEntity entity)
        {
            return new EmployeeSensorHistoryModel()
            {
                UId = entity.UId,
                BloodPressure = entity.BloodPressure,
                BodyTemperature = entity.BodyTemperature,
                DeviceUId = entity.DeviceUId,
                EmployeeUId = entity.EmployeeUId,
                Gulucose = entity.Gulucose,
                HeartRate = entity.HeartRate,
                OxygenSaturation = entity.OxygenSaturation,
                Respiration = entity.Respiration
            };
        }
        public static EmployeeSensorHistoryEntity ToEmployeeSensorHistoryEntity(this EmployeeSensorHistoryModel employeeModel)
        {
            return new EmployeeSensorHistoryEntity()
            {
                UId = employeeModel.UId,
                BloodPressure = employeeModel.BloodPressure,
                BodyTemperature = employeeModel.BodyTemperature,
                DeviceUId = employeeModel.DeviceUId,
                EmployeeUId = employeeModel.EmployeeUId,
                Gulucose = employeeModel.Gulucose,
                HeartRate = employeeModel.HeartRate,
                OxygenSaturation = employeeModel.OxygenSaturation,
                Respiration = employeeModel.Respiration
            };
        }
    }
}
