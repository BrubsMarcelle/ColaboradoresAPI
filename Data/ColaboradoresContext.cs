using ColaboradoresAPI.Enums;
using ColaboradoresAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace ColaboradoresAPI.Data
{
    public class ColaboradoresContext : DbContext
    {
        public ColaboradoresContext(DbContextOptions<ColaboradoresContext> options) : base(options) { }

        public DbSet<ColaboradoresModel> COLABORADORES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity("ColaboradoresAPI.model.ColaboradoresModel", b =>
            {
                b.ToTable("COLABORADORES");
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                b.Property<string>("NOME")
                    .HasColumnType("varchar(100)");

                b.Property<string>("CPF")
                    .HasColumnType("varchar(11)");

                b.Property<DateTime>("dataNascimento")
                    .HasColumnType("date");

                b.Property<string>("EMAIL")
                    .HasColumnType("varchar(60)");

                b.Property<string>("TELEFONE")
                    .HasColumnType("varchar(13)");

                b.Property<Contratacao>("CONTRATACAO")
                    .HasColumnType("int");

                b.Property<string>("CARGO")
                    .HasColumnType("varchar(50)");

                b.Property<string>("SQUAD")
                    .HasColumnType("varchar(50)");

                b.Property<DateTime>("dataAdmissao")
                    .HasColumnType("date");

                b.Property<string>("dataDesligamento")
                    .HasColumnType("varchar(50)");

                b.Property<Status>("SITUACAO")
                    .HasColumnType("int");

                b.Property<string>("EMPRESA")
                    .HasColumnType("varchar(50)");

                b.Property<string>("gestorDireto")
                    .HasColumnType("varchar(100)");

                b.Property<Status>("ALURA")
                    .HasColumnType("int");

                b.Property<string>("OBSERVACAO")
                    .HasColumnType("varchar(350)");

                b.HasKey("Id");

            });
        }
    }
}
