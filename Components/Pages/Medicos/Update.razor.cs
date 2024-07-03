using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Extensions;
using ClinicManageWebApp.Infrastructure.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Medicos
{
    public class UpdateMedicoPage : ComponentBase
    {
        [Inject]
        public IMedicoRepository MedicoRepository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Parameter]
        public int Id { get; set; }
        public MedicoInputModel MedicoInputModel { get; set; } = new MedicoInputModel();
        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

        [Inject]
        public IEspecialideRepository EspecialidadeRepository { get; set; } = null!;
        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadeRepository.GetAllAsync();
            var medico = await MedicoRepository.GetByIdAsync(Id);
            if (medico != null)
            {
                MedicoInputModel = new MedicoInputModel
                {
                    Nome = medico.Nome,
                    Cpf = medico.Cpf,
                    Celular = medico.Celular,
                    Crm = medico.Crm,
                    EspecialidadeId = medico.EspecialidadeId,
                    DataCadastro = medico.DataCadastro,
                };
            }
            else
            {
                Snackbar.Add("Medico não encontrado!", Severity.Error);
                NavigationManager.NavigateTo("/medicos");
            }
        }
        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    var medico = await MedicoRepository.GetByIdAsync(Id);
                    if (medico != null)
                    {
                        medico.Nome = medico.Nome;
                        medico.Cpf = medico.Cpf.SomenteCaracteres();
                        medico.Celular = medico.Celular.SomenteCaracteres();
                        medico.Crm = medico.Crm.SomenteCaracteres();
                        medico.EspecialidadeId = medico.EspecialidadeId;
                        medico.DataCadastro = medico.DataCadastro;

                        await MedicoRepository.UpdateAsync(medico);
                        Snackbar.Add("Médico atualizado com Sucesso!", Severity.Success);
                        NavigationManager.NavigateTo("/medicos");
                    }
                    else
                    {
                        Snackbar.Add("Médico não encontrado!", Severity.Error);
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
