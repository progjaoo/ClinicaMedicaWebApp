using System.ComponentModel;

namespace ClinicManageWebApp.Core.Entidades
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Celular { get; set; }
        public DateTime? DataCadastro { get;set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
