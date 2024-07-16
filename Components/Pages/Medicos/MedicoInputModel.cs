using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicManageWebApp.Components.Pages.Medicos
{
    public class MedicoInputModel
    {
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "Nome deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} Deve ter no máx {1} caracteres")]
        public string Nome { get; set; } = null!;

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Documento precisa ser fornecido")]
        public string Cpf { get; set; } = null!;

        [DisplayName("CRM")]
        [Required(ErrorMessage = "CRM precisa ser fornecido")]
        public string Crm { get; set; } = null!;

        [Required(ErrorMessage = "Celular precisa ser fornecido")]
        public string Celular { get; set; } = null!;
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Especialidade deve ser fornecida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int EspecialidadeId { get; set; }
    }
}
