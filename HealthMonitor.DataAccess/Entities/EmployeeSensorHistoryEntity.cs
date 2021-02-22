using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthMonitor.DataAccess.Entities
{
    [Table("EmployeeSensorHisotry")]
    public class EmployeeSensorHistoryEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid UId { get; set; }
        public Guid EmployeeUId { get; set; }
        public Guid DeviceUId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BodyTemperature { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BloodPressure { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Respiration { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gulucose { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HeartRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OxygenSaturation { get; set; }

        public EmployeeEntity Employee { get; set; }
    }
}
