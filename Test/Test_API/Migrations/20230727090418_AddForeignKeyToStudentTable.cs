using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Razmjene",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Razmjene_StudentId",
                table: "Razmjene",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Razmjene_Students_StudentId",
                table: "Razmjene",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Razmjene_Students_StudentId",
                table: "Razmjene");

            migrationBuilder.DropIndex(
                name: "IX_Razmjene_StudentId",
                table: "Razmjene");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Razmjene");
        }
    }
}
