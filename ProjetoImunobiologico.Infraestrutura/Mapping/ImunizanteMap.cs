using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoImunobiologico.Entidades.Models;

namespace ProjetoImunobiologico.Infraestrutura.Mapping
{
    public class ImunizanteMap : IEntityTypeConfiguration<Imunizante>
    {
        public void Configure(EntityTypeBuilder<Imunizante> builder)
        {
            builder.ToTable("Imunizantes");
            builder.HasKey(x => x.ImunizanteId);
            builder.Property(x => x.ImunizanteId)
              .ValueGeneratedOnAdd();
            builder.Property(x => x.Fabricante)
                .HasColumnType("varchar(200)");
            builder.Property(x => x.AnoLote)
                .HasColumnType("int");
        }

    }
}
