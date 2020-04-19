using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class udpatecontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntity_UserEntity_UserEntityId",
                table: "ProfileImageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntity_UserEntity_UserId",
                table: "ProfileImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileImageEntity",
                table: "ProfileImageEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "UserEntities");

            migrationBuilder.RenameTable(
                name: "ProfileImageEntity",
                newName: "ProfileImageEntities");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileImageEntity_UserId",
                table: "ProfileImageEntities",
                newName: "IX_ProfileImageEntities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileImageEntity_UserEntityId",
                table: "ProfileImageEntities",
                newName: "IX_ProfileImageEntities_UserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileImageEntities",
                table: "ProfileImageEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserEntityId",
                table: "ProfileImageEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ProfileImageEntities_UserEntities_UserEntityId",
                table: "ProfileImageEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileImageEntities",
                table: "ProfileImageEntities");

            migrationBuilder.RenameTable(
                name: "UserEntities",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "ProfileImageEntities",
                newName: "ProfileImageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntity",
                newName: "IX_ProfileImageEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileImageEntities_UserEntityId",
                table: "ProfileImageEntity",
                newName: "IX_ProfileImageEntity_UserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileImageEntity",
                table: "ProfileImageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImageEntity_UserEntity_UserEntityId",
                table: "ProfileImageEntity",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImageEntity_UserEntity_UserId",
                table: "ProfileImageEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
