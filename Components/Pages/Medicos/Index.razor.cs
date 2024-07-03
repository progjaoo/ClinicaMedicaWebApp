using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Medicos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IMedicoRepository repository { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        public List<Medico> Medicos { get; set; } = new List<Medico>();

        public async Task DeleteMedico(Medico medico)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                    (
                        "ATENÇÃO",
                         $"Deseja excluir o {medico.Nome}?",
                         yesText: "Sim",
                         cancelText: "Não"
                    );
                if (result is true)
                {
                    await repository.DeleteAsync(medico.IdMedico);
                    Snackbar.Add($"Paciente {medico.Nome} excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/medicos/update/{id}");
        }
        protected override async Task OnInitializedAsync()
        {
            Medicos = await repository.GetAllAsync();
        }
    }
}
