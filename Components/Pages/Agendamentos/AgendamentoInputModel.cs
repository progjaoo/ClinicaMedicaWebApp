using System.ComponentModel.DataAnnotations;

namespace ClinicManageWebApp.Components.Pages.Agendamentos
{
    public class AgendamentoInputModel
    {
        [MaxLength(250, ErrorMessage = "O campo {0} deve conter até no máximo {1} caracteres")]
        public string? Observacao { get; set; }
        
        [Required(ErrorMessage = "{0} deve ser fornecida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int PacienteId { get; set; }
        
        [Required(ErrorMessage = "{0} deve ser fornecida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int MedicoId { get; set; }
        
        [Required(ErrorMessage = "{0} deve ser fornecida")]
        public TimeSpan HoraConsulta { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecida")]
        public DateTime DataConsulta { get; set; }
    }
}
