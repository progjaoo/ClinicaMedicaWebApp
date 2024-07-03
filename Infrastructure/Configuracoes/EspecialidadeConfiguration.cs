using ClinicManageWebApp.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaMedica.WebApp.Infrastructure.Configuracoes
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.HasKey(e => e.IdEspecialidade);

            builder.Property(p => p.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasColumnType("VARCHAR(150)");

            builder.HasMany(m => m.Medicos)
                .WithOne(e => e.Especialidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}