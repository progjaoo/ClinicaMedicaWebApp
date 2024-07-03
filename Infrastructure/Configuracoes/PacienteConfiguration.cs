using ClinicManageWebApp.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaMedica.WebApp.Infrastructure.Configuracoes
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.IdPaciente);

            builder.Property(p => p.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Cpf)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(p => p.Email)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Celular)
                .IsRequired(true)
                .HasColumnType("NVARCHA(11)");

            builder.HasIndex(p => p.Cpf).IsUnique();

            builder.HasMany(p => p.Agendamentos)
                .WithOne(p => p.Paciente)
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
