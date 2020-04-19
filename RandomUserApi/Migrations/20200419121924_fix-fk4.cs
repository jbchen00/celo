using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class fixfk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ProfileImageEntities",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ProfileImageEntities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId",
                unique: true);
        }
    }
}
