using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthMonitor.DataAccess.Migrations
{
    public partial class emphistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSensorHisotry",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BodyTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BloodPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Respiration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gulucose = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeartRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OxygenSaturation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSensorHisotry", x => x.UId);
                    table.ForeignKey(
                        name: "FK_EmployeeSensorHisotry_Employees_EmployeeUId",
                        column: x => x.EmployeeUId,
                        principalTable: "Employees",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSensorHisotry_EmployeeUId",
                table: "EmployeeSensorHisotry",
                column: "EmployeeUId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSensorHisotry");
        }
    }
}
