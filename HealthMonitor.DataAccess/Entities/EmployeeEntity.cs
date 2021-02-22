using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthMonitor.DataAccess.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key]
        [Required]
        public Guid UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        public ICollection<EmployeeSensorHistoryEntity> EmployeeSensorHistory { get; set; }
    }
}
