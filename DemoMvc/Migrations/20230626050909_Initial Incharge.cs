﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMvc.Migrations
{
    public partial class InitialIncharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incharge",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Incharges",
                newName: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Incharges_DepartmentId",
                table: "Incharges",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incharges_Departments_DepartmentId",
                table: "Incharges",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incharges_Departments_DepartmentId",
                table: "Incharges");

            migrationBuilder.DropIndex(
                name: "IX_Incharges_DepartmentId",
                table: "Incharges");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Incharges",
                newName: "SerialNumber");

            migrationBuilder.AddColumn<int>(
                name: "Incharge",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
