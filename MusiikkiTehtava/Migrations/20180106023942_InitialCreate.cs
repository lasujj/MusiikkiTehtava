using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace MusiikkiTehtava.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albumit",
                columns: table => new
                {
                    AlbumiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Julkaisuvuosi = table.Column<int>(nullable: false),
                    Nimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumit", x => x.AlbumiId);
                });

            migrationBuilder.CreateTable(
                name: "Artistit",
                columns: table => new
                {
                    ArtistiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true),
                    Nimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistit", x => x.ArtistiId);
                });

            migrationBuilder.CreateTable(
                name: "Kappaleet",
                columns: table => new
                {
                    KappaleId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumiId = table.Column<int>(nullable: true),
                    ArtistiId = table.Column<int>(nullable: true),
                    Kesto = table.Column<int>(nullable: false),
                    Nimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kappaleet", x => x.KappaleId);
                    table.ForeignKey(
                        name: "FK_Kappaleet_Albumit_AlbumiId",
                        column: x => x.AlbumiId,
                        principalTable: "Albumit",
                        principalColumn: "AlbumiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kappaleet_Artistit_ArtistiId",
                        column: x => x.ArtistiId,
                        principalTable: "Artistit",
                        principalColumn: "ArtistiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kappaleet_AlbumiId",
                table: "Kappaleet",
                column: "AlbumiId");

            migrationBuilder.CreateIndex(
                name: "IX_Kappaleet_ArtistiId",
                table: "Kappaleet",
                column: "ArtistiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kappaleet");

            migrationBuilder.DropTable(
                name: "Albumit");

            migrationBuilder.DropTable(
                name: "Artistit");
        }
    }
}
