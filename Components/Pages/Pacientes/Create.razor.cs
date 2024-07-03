using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Pacientes
{
    public class CreatePacientePage : ComponentBase
    {
        [Inject]
        public IPacienteRepository PacienteRepository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        public PacienteInputModel PacienteInputModel { get; set; } = new PacienteInputModel();
        public DateTime? DataNasc { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = new Paciente
                    {
                        Nome = model.Nome,
                        Cpf = model.Cpf.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        Email = model.Email,
                        Endereco = model.Endereco,
                        DataNasc = model.DataNasc.Value
                    };
                    await PacienteRepository.AddAsync(paciente);
                    Snackbar.Add("Paciente cadastrado com Sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);

                throw;
            }
        }
    }
}
