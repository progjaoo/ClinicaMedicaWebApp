using System.ComponentModel;

namespace ClinicManageWebApp.Core.Entidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        public string Celular { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime? DataNasc { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
