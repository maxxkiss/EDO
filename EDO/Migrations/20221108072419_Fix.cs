using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDO.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Document_Stage_pkey",
                table: "Document_Stage");

            migrationBuilder.AddPrimaryKey(
                name: "Document_Stage_pkey",
                table: "Document_Stage",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Document_Stage_pkey",
                table: "Document_Stage");

            migrationBuilder.AddPrimaryKey(
                name: "Document_Stage_pkey",
                table: "Document_Stage",
                column: "VerifierId");
        }
    }
}
