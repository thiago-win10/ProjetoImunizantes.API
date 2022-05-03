using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoImunobiologico.Infraestrutura.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imunizantes",
                columns: table => new
                {
                    ImunizanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fabricante = table.Column<string>(type: "varchar(200)", nullable: false),
                    AnoLote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imunizantes", x => x.ImunizanteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imunizantes");
        }
    }
}
