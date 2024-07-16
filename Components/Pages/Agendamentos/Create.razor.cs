using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Infrastructure.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Agendamentos
{
    public class CreateAgendamentoPage : ComponentBase
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

        public AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();
        public List<Medico> Medicos { get; set; } = new List<Medico>();
        public List<Paciente> Pacientes { get; set;} = new List<Paciente> ();
        public TimeSpan? Time = new TimeSpan(09, 00, 00);
        public DateTime? Date { get; set; } = DateTime.Now.Date;
        public DateTime MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento
                    {
                        Observacao = model.Observacao,
                        HoraConsulta = Time!.Value,
                        DataConsulta = Date!.Value,
                        MedicoId = model.MedicoId,
                        PacienteId = model.PacienteId
                    };

                    await AgendamentoRepository.AddAsync(agendamento);
                    Snackbar.Add("Agendamento realizado com Sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/agendamentos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Success);
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();
        }
    }
}
