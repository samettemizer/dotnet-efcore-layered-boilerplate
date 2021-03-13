using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class Detay_Field_Became_Nullable_And_DetayTypes_Added_To_FirmaUrunOzellik_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detay",
                table: "FirmaUrunOzellikleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<byte>(
                name: "DetayTipi",
                table: "FirmaUrunOzellikleri",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetayTipi",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.AlterColumn<string>(
                name: "Detay",
                table: "FirmaUrunOzellikleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
