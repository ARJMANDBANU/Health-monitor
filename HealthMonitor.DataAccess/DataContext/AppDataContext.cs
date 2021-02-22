using HealthMonitor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.DataAccess.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<EmployeeSensorHistoryEntity> EmployeeSensorHistory { get; set; }
    }
}
