using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_July.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomeModelChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Usluge",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KontaktMail",
                table: "Usluge",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_KategorijaId",
                table: "Usluge",
                column: "KategorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluge_Kategorije_KategorijaId",
                table: "Usluge",
                column: "KategorijaId",
                principalTable: "Kategorije",
                principalColumn: "kategorija_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usluge_Kategorije_KategorijaId",
                table: "Usluge");

            migrationBuilder.DropIndex(
                name: "IX_Usluge_KategorijaId",
                table: "Usluge");

            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Usluge");

            migrationBuilder.DropColumn(
                name: "KontaktMail",
                table: "Usluge");
        }
    }
}
