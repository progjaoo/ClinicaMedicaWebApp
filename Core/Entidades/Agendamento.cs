namespace ClinicManageWebApp.Core.Entidades
{
    public class Agendamento
    {
        public int IdAgendamento { get; private set; }
        public string? Observacao { get; private set; }
        public TimeSpan HoraConsulta { get; private set; }
        public DateTime? DataConsulta { get; private set; }

        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public Medico Medico { get; set; } = null!;
        public Paciente Paciente { get; set; } = null!;
    }
}
