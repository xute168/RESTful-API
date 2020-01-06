using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.RESTful.API.Data.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empls", x => x.EmployeeId);                   
                });

            migrationBuilder.CreateTable(
               name: "EmployeeTasks",
               columns: table => new
               {
                   EmployeeTaskId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),                   
                   TaskName = table.Column<string>(nullable: true),
                   StartDate = table.Column<DateTime>(nullable: false),
                   DeadLine = table.Column<DateTime>(nullable: false),                   
                   EmployeeId = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_EmployeeTasks", x => x.EmployeeTaskId);
                   table.ForeignKey(
                       name: "FK_EmployeeTasks_Employee_EmployeeId",
                       column: x => x.EmployeeId,
                       principalTable: "Employees",
                       principalColumn: "EmployeeId",
                       onDelete: ReferentialAction.Restrict);                   
               });
            

                        
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "HireDate", "LastName", "FirstName" },
                values: new object[] { 1, new DateTime(2020, 01, 04, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATL2018", "Atlanta Code Camp" });
            migrationBuilder.InsertData(
               table: "EmployeeTasks",
               columns: new[] { "EmployeeTaskId", "TaskName", "StartDate", "DeadLine", "EmployeeId" },
               values: new object[] { 1, "Entity Framework From Scratch", new DateTime(2020, 01, 04, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 01, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "EmployeeTaskId", "TaskName", "StartDate", "DeadLine", "EmployeeId" },
                values: new object[] { 2, "Writing Sample Data Made Easy", new DateTime(2020, 01, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 02, 04, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

           
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Employees");

            migrationBuilder.DropTable(
               name: "EmployeeTasks");
        }
    }
}
