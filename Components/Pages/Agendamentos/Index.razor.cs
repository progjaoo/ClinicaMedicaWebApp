using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace ClinicManageWebApp.Components.Pages.Agendamentos
{
    public class IndexAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;
        
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]

        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public bool HideButtons { get; set; }


        public async Task DeleteAgendamento(Agendamento agendamento)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                    (
                        "ATENÇÃO",
                         $"Deseja excluir o agendamento?",
                         yesText: "Sim",
                         cancelText: "Não"
                    );
                if (result is true)
                {
                    await AgendamentoRepository.DeleteAsync(agendamento.IdAgendamento);
                    Snackbar.Add($"Agendamento excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Atendente");

            Agendamentos = await AgendamentoRepository.GetAllAsync();
        }
        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/agendamentos/update/{id}");
        }
    }
}
