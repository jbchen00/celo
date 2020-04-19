using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomUserApi.Migrations
{
    public partial class fixfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImageEntities_UserEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImageEntities_UserId",
                table: "ProfileImageEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_Id",
                table: "UserEntities",
                column: "Id",
                principalTable: "ProfileImageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_ProfileImageEntities_Id",
                table: "UserEntities");

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
    }
}
