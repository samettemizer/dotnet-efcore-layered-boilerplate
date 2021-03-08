using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class SektorId_Property_Added_To_Uruns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "SektorId",
                table: "Urunler",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SektorId",
                table: "Urunler");
        }
    }
}
