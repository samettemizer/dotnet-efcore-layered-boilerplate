using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class UstKategoriId_Property_Became_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "UstKategoryId",
                table: "UrunKategorileri",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "UstKategoryId",
                table: "UrunKategorileri",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);
        }
    }
}
