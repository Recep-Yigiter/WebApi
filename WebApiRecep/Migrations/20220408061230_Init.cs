using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiRecep.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MALIYET");

            migrationBuilder.CreateTable(
                name: "ALIS_TIPI",
                schema: "MALIYET",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SonDegisiklikYapan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALIS_TIPI", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALIS_TIPI_TipAdi",
                schema: "MALIYET",
                table: "ALIS_TIPI",
                column: "TipAdi",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALIS_TIPI",
                schema: "MALIYET");
        }
    }
}
