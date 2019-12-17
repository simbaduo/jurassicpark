using Microsoft.EntityFrameworkCore.Migrations;

namespace jurassicpark.Migrations
{
    public partial class TryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinosaur",
                table: "Dinosaur");

            migrationBuilder.RenameTable(
                name: "Dinosaur",
                newName: "Dinosaurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinosaurs",
                table: "Dinosaurs",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinosaurs",
                table: "Dinosaurs");

            migrationBuilder.RenameTable(
                name: "Dinosaurs",
                newName: "Dinosaur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinosaur",
                table: "Dinosaur",
                column: "ID");
        }
    }
}
