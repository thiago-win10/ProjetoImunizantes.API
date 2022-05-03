﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoImunobiologico.Infraestrutura.Configuration;

namespace ProjetoImunobiologico.Infraestrutura.Migrations
{
    [DbContext(typeof(ImunizanteContext))]
    partial class ImunizanteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoImunobiologico.Entidades.Models.Imunizante", b =>
                {
                    b.Property<int>("ImunizanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoLote")
                        .HasColumnType("int");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("ImunizanteId");

                    b.ToTable("Imunizantes");
                });
#pragma warning restore 612, 618
        }
    }
}
