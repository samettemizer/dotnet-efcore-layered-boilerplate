using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class InitialDb_ReklamAilesi_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FirmaUrunId",
                table: "TeklifDetaylari",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "MusteriId",
                table: "TeklifDetaylari",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "TeklifDetaylari");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaUrunId",
                table: "TeklifDetaylari",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
