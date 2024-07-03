using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicManageWebApp.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} Deve ter no máx {1} caracteres")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Documento precisa ser fornecido")]
        public string Cpf { get; set; }
        
        [DisplayName("E-mail")]
        [Required(ErrorMessage = " E-mail deve ser fornecido")]
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        [MaxLength(50, ErrorMessage = " {0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Celular precisa ser fornecido")]
        public string Celular { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Endereço precisa ser fornecido")]
        public string Endereco { get; set; }
        
        [DisplayName("Data de Nascimento")]
        public DateTime? DataNasc { get; set; } = DateTime.Today;
    }
}


