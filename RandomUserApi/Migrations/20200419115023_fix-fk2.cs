using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class fixfk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserEntities_ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.DropColumn(
                name: "ProfileImagesId",
                table: "UserEntities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileImageEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImageId",
                table: "UserEntities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_ProfileImageId",
                table: "UserEntities",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImageId",
                table: "UserEntities",
                column: "ProfileImageId",
                principalTable: "ProfileImageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImageId",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserEntities_ProfileImageId",
                table: "UserEntities");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "UserEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImagesId",
                table: "UserEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ProfileImageEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_ProfileImagesId",
                table: "UserEntities",
                column: "ProfileImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_ProfileImagesId",
                table: "UserEntities",
                column: "ProfileImagesId",
                principalTable: "ProfileImageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
