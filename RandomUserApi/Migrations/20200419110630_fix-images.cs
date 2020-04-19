using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class fiximages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserEntityId",
                table: "ProfileImageEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserEntityId",
                table: "ProfileImageEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "ProfileImageEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImagesId",
                table: "UserEntities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_ProfileImagesId",
                table: "UserEntities",
                column: "ProfileImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImagesId",
                table: "UserEntities",
                column: "ProfileImagesId",
                principalTable: "ProfileImageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserEntities_ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropColumn(
                name: "ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "ProfileImageEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserEntityId",
                table: "ProfileImageEntities",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserEntityId",
                table: "ProfileImageEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
