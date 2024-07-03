using ClinicManageWebApp.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaMedica.WebApp.Infrastructure.Configuracoes
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(p => p.IdMedico);

            builder.Property(p => p.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Cpf)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(p => p.Crm)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(8)");

            builder.Property(p => p.Celular)
                .IsRequired(true)
                .HasColumnType("NVARCHA(11)");

            builder.Property(p => p.EspecialidadeId)
                .IsRequired(true);

            builder.HasIndex(p => p.Cpf).IsUnique();

            builder.HasMany(p => p.Agendamentos)
                .WithOne(p => p.Medico)
                .HasForeignKey(p => p.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
