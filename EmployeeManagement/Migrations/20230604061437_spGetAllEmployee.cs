using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class spGetAllEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure = @"create procedure spGetAllEmployee
                               as
                               begin
                                  select * 
                                  from dbo.Employees e, dbo.Departments d
                                  where e.DepartmentId = d.DepartmentId
                               end";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop procedure spGetAllEmployee";

            migrationBuilder.Sql(procedure);
        }
    }
}
