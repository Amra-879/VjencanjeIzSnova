using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_July.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    kategorija_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    opis = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__487607FB19F75645", x => x.kategorija_id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    user_type = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ProfilnaSlikaUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnic__B9BE370F03FE7D68", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    klijent_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prezime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    grad = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    datum_vjenčanja = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Klijent__9D7F1ACABE38AB79", x => x.klijent_id);
                    table.ForeignKey(
                        name: "FK__Klijent__user_id__3B75D760",
                        column: x => x.user_id,
                        principalTable: "Korisnici",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    partner_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    mobitel = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    kategorija_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partner__576F1B27720B1D72", x => x.partner_id);
                    table.ForeignKey(
                        name: "FK__Partner__kategor__4222D4EF",
                        column: x => x.kategorija_id,
                        principalTable: "Kategorije",
                        principalColumn: "kategorija_id");
                    table.ForeignKey(
                        name: "FK__Partner__user_id__412EB0B6",
                        column: x => x.user_id,
                        principalTable: "Korisnici",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Planer",
                columns: table => new
                {
                    planer_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    br_trenutnih_klijenata = table.Column<int>(type: "INTEGER", nullable: true),
                    zoom_meeting_link = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Planer__BF194A6C68A607B5", x => x.planer_id);
                    table.ForeignKey(
                        name: "FK__Planer__user_id__45F365D3",
                        column: x => x.user_id,
                        principalTable: "Korisnici",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Košarica",
                columns: table => new
                {
                    košarica_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    client_id = table.Column<int>(type: "INTEGER", nullable: true),
                    naziv_artikla = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cijena = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Košarica__4C4EEBFCF74FD176", x => x.košarica_id);
                    table.ForeignKey(
                        name: "FK__Košarica__client__5812160E",
                        column: x => x.client_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                });

            migrationBuilder.CreateTable(
                name: "Plaćanja",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    client_id = table.Column<int>(type: "INTEGER", nullable: true),
                    iznos = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    placanje_datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    transakcija_id = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Plaćanja__ED1FC9EA615C8B2E", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK__Plaćanja__client__5535A963",
                        column: x => x.client_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    recenzija_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    klijent_id = table.Column<int>(type: "INTEGER", nullable: true),
                    partner_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ocjena = table.Column<double>(type: "REAL", nullable: true),
                    komentar = table.Column<string>(type: "TEXT", nullable: true),
                    datum = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recenzij__020681BA242E6DDA", x => x.recenzija_id);
                    table.ForeignKey(
                        name: "FK__Recenzije__klijent__5165187F",
                        column: x => x.klijent_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK__Recenzije__usluga__52593CB8",
                        column: x => x.partner_id,
                        principalTable: "Partner",
                        principalColumn: "partner_id");
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    usluga_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    partner_id = table.Column<int>(type: "INTEGER", nullable: false),
                    naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    opis = table.Column<string>(type: "TEXT", nullable: true),
                    cjenovniRang = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    infoOKompaniji = table.Column<string>(type: "TEXT", nullable: false),
                    detalji = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usluge__188C4FFA9282855A", x => x.usluga_id);
                    table.ForeignKey(
                        name: "FK__Usluge__partner___48CFD27E",
                        column: x => x.partner_id,
                        principalTable: "Partner",
                        principalColumn: "partner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanerKlijenti",
                columns: table => new
                {
                    planer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    client_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanerKl__E4EB502E5A1C619D", x => new { x.planer_id, x.client_id });
                    table.ForeignKey(
                        name: "FK__PlanerKli__clien__5BE2A6F2",
                        column: x => x.client_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK__PlanerKli__plane__5AEE82B9",
                        column: x => x.planer_id,
                        principalTable: "Planer",
                        principalColumn: "planer_id");
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    rezervacije_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    klijent_id = table.Column<int>(type: "INTEGER", nullable: true),
                    usluga_id = table.Column<int>(type: "INTEGER", nullable: true),
                    datum = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true, defaultValue: "pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rezervac__4F18667E0FB39479", x => x.rezervacije_id);
                    table.ForeignKey(
                        name: "FK__Rezervacije__klijent__4CA06362",
                        column: x => x.klijent_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK__Rezervacije__usluga__4D94879B",
                        column: x => x.usluga_id,
                        principalTable: "Usluge",
                        principalColumn: "usluga_id");
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Url = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SlikaId = table.Column<int>(type: "INTEGER", nullable: false),
                    usluga_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Slike__5B5B1F5A0E5504C4", x => x.Url);
                    table.ForeignKey(
                        name: "FK__Slike__usluga_id",
                        column: x => x.usluga_id,
                        principalTable: "Usluge",
                        principalColumn: "usluga_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Klijent__B9BE370E02949A1F",
                table: "Klijent",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Korisnic__AB6E6164532F21D4",
                table: "Korisnici",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Košarica_client_id",
                table: "Košarica",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_kategorija_id",
                table: "Partner",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Partner__B9BE370ECFCA0A5E",
                table: "Partner",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plaćanja_client_id",
                table: "Plaćanja",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Planer__B9BE370EEF0010D4",
                table: "Planer",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanerKlijenti_client_id",
                table: "PlanerKlijenti",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_klijent_id",
                table: "Recenzije",
                column: "klijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_partner_id",
                table: "Recenzije",
                column: "partner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_klijent_id",
                table: "Rezervacije",
                column: "klijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_usluga_id",
                table: "Rezervacije",
                column: "usluga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_usluga_id",
                table: "Slike",
                column: "usluga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_partner_id",
                table: "Usluge",
                column: "partner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Košarica");

            migrationBuilder.DropTable(
                name: "Plaćanja");

            migrationBuilder.DropTable(
                name: "PlanerKlijenti");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Planer");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
