using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoImunobiologico.Infraestrutura.Migrations
{
    public partial class PopularBaseDadosImunizantes : Migration
    {
        protected override void Up(MigrationBuilder db)
        {
            db.Sql("Insert into Imunizantes(Fabricante, AnoLote) Values('SINOVAC', 2020)");
            db.Sql("Insert into Imunizantes(Fabricante, AnoLote) Values('PFIZER', 2020)");
            db.Sql("Insert into Imunizantes(Fabricante, AnoLote) Values('SINOVAC', 2021)");

        }

        protected override void Down(MigrationBuilder db)
        {
            db.Sql("Delete from Imunizantes");

        }
    }
}
