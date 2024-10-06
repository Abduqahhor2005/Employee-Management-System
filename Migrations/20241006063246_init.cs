using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam9.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    lastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    hireDate = table.Column<DateTime>(type: "date", nullable: false),
                    position = table.Column<string>(type: "varchar(100)", nullable: false),
                    salary = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    departmentName = table.Column<string>(type: "varchar(100)", nullable: false),
                    managerName = table.Column<string>(type: "varchar(100)", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    address = table.Column<string>(type: "varchar(255)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    country = table.Column<string>(type: "varchar(100)", nullable: false),
                    createdAt = table.Column<string>(type: "varchar(100)", nullable: false, defaultValueSql: "current_timestamp"),
                    updatedAt = table.Column<string>(type: "varchar(100)", nullable: false, defaultValueSql: "current_timestamp")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.UniqueConstraint("AK_employees_email", x => x.email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
