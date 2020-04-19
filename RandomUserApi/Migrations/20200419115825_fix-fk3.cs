using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class fixfk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_Id",
                table: "UserEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ProfileImageEntities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileImageEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_Id",
                table: "UserEntities",
                column: "Id",
                principalTable: "ProfileImageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
