using ClinicManageWebApp.Components.Pages.Medicos;
using ClinicManageWebApp.Components.Pages.Pacientes;
using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Infrastructure.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Agendamentos
{
    public class UpdateAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;
        [Inject]
        private IPacienteRepository PacienteRepository { get; set; } = null!;
        [Inject]
        private IMedicoRepository MedicoRepository { get; set; } = null!;
        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public int Id { get; set; }
        public AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();
        public List<Medico> Medicos { get; set; } = new List<Medico>();
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public TimeSpan? Time = new TimeSpan(09, 00, 00);
        public DateTime? Date { get; set; } = DateTime.Now.Date;
        public DateTime MinDate { get; set; } = DateTime.Now.Date;

        protected override async Task OnInitializedAsync()
        {
            var agendamento = await AgendamentoRepository.GetByIdAsync(Id);
            if (agendamento != null)
            {
                InputModel = new AgendamentoInputModel
                {
                    Observacao = agendamento.Observacao,
                    HoraConsulta = agendamento.HoraConsulta,
                    DataConsulta = agendamento.DataConsulta,
                    MedicoId = agendamento.MedicoId,
                    PacienteId = agendamento.PacienteId
                };
            }
            else
            {
                Snackbar.Add("Agendamento não encontrado!", Severity.Error);
                NavigationManager.NavigateTo("/agendamentos");
            }

            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = await AgendamentoRepository.GetByIdAsync(Id);
                    if (agendamento != null)
                    {
                        agendamento.Observacao = model.Observacao;
                        agendamento.HoraConsulta = model.HoraConsulta;
                        agendamento.DataConsulta = model.DataConsulta;
                        agendamento.MedicoId = model.MedicoId;
                        agendamento.PacienteId = model.PacienteId;

                        await AgendamentoRepository.UpdateAsync(agendamento);
                        Snackbar.Add("Agendamento atualizado com sucesso!", Severity.Success);
                        NavigationManager.NavigateTo("/agendamentos");
                    }
                    else
                    {
                        Snackbar.Add("Agendamento não encontrado!", Severity.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
