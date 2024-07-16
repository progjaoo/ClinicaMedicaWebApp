namespace ClinicManageWebApp.Core.Entidades
{
    public class Agendamento
    {
        public int IdAgendamento { get;  set; }
        public string? Observacao { get; set; }
        public TimeSpan HoraConsulta { get;  set; }
        public DateTime DataConsulta { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public Medico Medico { get; set; } = null!;
        public Paciente Paciente { get; set; } = null!;
    }
}
