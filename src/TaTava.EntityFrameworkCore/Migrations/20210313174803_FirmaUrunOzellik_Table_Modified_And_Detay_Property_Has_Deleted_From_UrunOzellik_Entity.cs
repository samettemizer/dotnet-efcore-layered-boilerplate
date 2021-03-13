using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class FirmaUrunOzellik_Table_Modified_And_Detay_Property_Has_Deleted_From_UrunOzellik_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detay",
                table: "UrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "OzellikTuru",
                table: "UrunOzellikleri");

            migrationBuilder.AddColumn<string>(
                name: "Detay",
                table: "FirmaUrunOzellikleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "FirmaUrunOzellikleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "OzellikTuru",
                table: "FirmaUrunOzellikleri",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "UrunId",
                table: "FirmaUrunOzellikleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "UrunId1",
                table: "FirmaUrunOzellikleri",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UrunOzellikId",
                table: "FirmaUrunOzellikleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FirmaUrunOzellikleri_FirmaId",
                table: "FirmaUrunOzellikleri",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaUrunOzellikleri_UrunId1",
                table: "FirmaUrunOzellikleri",
                column: "UrunId1");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaUrunOzellikleri_UrunOzellikId",
                table: "FirmaUrunOzellikleri",
                column: "UrunOzellikId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmaUrunOzellikleri_Firmalar_FirmaId",
                table: "FirmaUrunOzellikleri",
                column: "FirmaId",
                principalTable: "Firmalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirmaUrunOzellikleri_Urunler_UrunId1",
                table: "FirmaUrunOzellikleri",
                column: "UrunId1",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FirmaUrunOzellikleri_UrunOzellikleri_UrunOzellikId",
                table: "FirmaUrunOzellikleri",
                column: "UrunOzellikId",
                principalTable: "UrunOzellikleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmaUrunOzellikleri_Firmalar_FirmaId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropForeignKey(
                name: "FK_FirmaUrunOzellikleri_Urunler_UrunId1",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropForeignKey(
                name: "FK_FirmaUrunOzellikleri_UrunOzellikleri_UrunOzellikId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropIndex(
                name: "IX_FirmaUrunOzellikleri_FirmaId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropIndex(
                name: "IX_FirmaUrunOzellikleri_UrunId1",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropIndex(
                name: "IX_FirmaUrunOzellikleri_UrunOzellikId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "Detay",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "OzellikTuru",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "UrunId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "UrunId1",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.DropColumn(
                name: "UrunOzellikId",
                table: "FirmaUrunOzellikleri");

            migrationBuilder.AddColumn<string>(
                name: "Detay",
                table: "UrunOzellikleri",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "OzellikTuru",
                table: "UrunOzellikleri",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
