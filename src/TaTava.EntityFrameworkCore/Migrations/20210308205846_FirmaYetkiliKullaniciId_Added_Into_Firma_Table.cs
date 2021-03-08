using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaTava.EntityFrameworkCore.Migrations
{
    public partial class FirmaYetkiliKullaniciId_Added_Into_Firma_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FirmaYetkiliKullaniciId",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_FirmaYetkiliKullaniciId",
                table: "Firmalar",
                column: "FirmaYetkiliKullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firmalar_Users_FirmaYetkiliKullaniciId",
                table: "Firmalar",
                column: "FirmaYetkiliKullaniciId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firmalar_Users_FirmaYetkiliKullaniciId",
                table: "Firmalar");

            migrationBuilder.DropIndex(
                name: "IX_Firmalar_FirmaYetkiliKullaniciId",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "FirmaYetkiliKullaniciId",
                table: "Firmalar");
        }
    }
}
