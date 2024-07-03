using ClinicManageWebApp.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaMedica.WebApp.Infrastructure.Configuracoes
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(e => e.IdAgendamento);

            builder.Property(p => p.Observacao)
                .IsRequired(false)
                .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.PacienteId)
                .IsRequired();
            builder.Property(p => p.MedicoId)
                .IsRequired();
        }
    }
}
