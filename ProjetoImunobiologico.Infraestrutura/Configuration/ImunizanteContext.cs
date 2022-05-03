using Microsoft.EntityFrameworkCore;
using ProjetoImunobiologico.Entidades.Models;
using ProjetoImunobiologico.Entidades.ViewModels;
using ProjetoImunobiologico.Infraestrutura.Mapping;

namespace ProjetoImunobiologico.Infraestrutura.Configuration
{
    public class ImunizanteContext : DbContext
    {
        public ImunizanteContext(DbContextOptions<ImunizanteContext> options)
        : base(options)
        {
        }

        public DbSet<Imunizante> Imunizantes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }

        }

        public string ObterStringConexao()
        {
            string conn = "Data Source=DESKTOP-H6JQJL4;Initial Catalog=ImunobiologicoAPI;Integrated Security=True";
            return conn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Configuration
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ImunizanteMap());
        }

    }
}
