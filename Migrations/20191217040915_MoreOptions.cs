using Microsoft.EntityFrameworkCore.Migrations;

namespace jurassicpark.Migrations
{
    public partial class MoreOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinos",
                table: "Dinos");

            migrationBuilder.RenameTable(
                name: "Dinos",
                newName: "Dinosaur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinosaur",
                table: "Dinosaur",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinosaur",
                table: "Dinosaur");

            migrationBuilder.RenameTable(
                name: "Dinosaur",
                newName: "Dinos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinos",
                table: "Dinos",
                column: "ID");
        }
    }
}
