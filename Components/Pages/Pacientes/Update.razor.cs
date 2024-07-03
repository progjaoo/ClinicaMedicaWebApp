using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Pacientes
{
    public class UpdatePacientePage : ComponentBase
    {
        [Inject]
        public IPacienteRepository PacienteRepository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Parameter]
        public int Id { get; set; } 
        public PacienteInputModel PacienteInputModel { get; set; } = new PacienteInputModel();
        public DateTime? DataNasc { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var paciente = await PacienteRepository.GetByIdAsync(Id);
            if (paciente != null)
            {
                PacienteInputModel = new PacienteInputModel
                {
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    Celular = paciente.Celular,
                    Email = paciente.Email,
                    Endereco = paciente.Endereco,
                    DataNasc = paciente.DataNasc
                };
                DataNasc = paciente.DataNasc;
            }
            else
            {
                Snackbar.Add("Paciente não encontrado!", Severity.Error);
                NavigationManager.NavigateTo("/pacientes");
            }
        }
        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = await PacienteRepository.GetByIdAsync(Id);
                    if (paciente != null)
                    {
                        paciente.Nome = model.Nome;
                        paciente.Cpf = model.Cpf.SomenteCaracteres();
                        paciente.Celular = model.Celular.SomenteCaracteres();
                        paciente.Email = model.Email;
                        paciente.Endereco = model.Endereco;
                        paciente.DataNasc = model.DataNasc.Value;

                        await PacienteRepository.UpdateAsync(paciente);
                        Snackbar.Add("Paciente atualizado com Sucesso!", Severity.Success);
                        NavigationManager.NavigateTo("/pacientes");
                    }
                    else
                    {
                        Snackbar.Add("Paciente não encontrado!", Severity.Error);
                    }
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
