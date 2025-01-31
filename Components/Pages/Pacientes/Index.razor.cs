﻿using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Pacientes
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPacienteRepository repository { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public bool HideButtons { get; set; }

        public async Task DeletePaciente(Paciente paciente)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                    (
                        "ATENÇÃO",
                         $"Deseja excluir o {paciente.Nome}?",
                         yesText: "Sim",
                         cancelText: "Não"
                    );
                if (result is true)
                {
                    await repository.DeleteAsync(paciente.IdPaciente);
                    Snackbar.Add($"Paciente {paciente.Nome} excluído com sucesso!", Severity.Success);
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
            NavigationManager.NavigateTo($"/pacientes/update/{id}");
        }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Atendente");

            Pacientes = await repository.GetAllAsync();
        }
    }
}
