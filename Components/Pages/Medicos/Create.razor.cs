using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClinicManageWebApp.Components.Pages.Medicos
{
    public class CreatePacientePage : ComponentBase
    {
        [Inject]
        public IEspecialideRepository EspecialidadeRepository { get; set; } = null!;

        [Inject]
        public IMedicoRepository MedicoRepository { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        public MedicoInputModel MedicoInputModel { get; set; } = new MedicoInputModel();
        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadeRepository.GetAllAsync();
        }
        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Cpf = model.Cpf.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        Crm = model.Crm.SomenteCaracteres(),
                        EspecialidadeId = model.EspecialidadeId,
                        DataCadastro = model.DataCadastro
                    };
                    await MedicoRepository.AddAsync(medico);
                    Snackbar.Add("Médico cadastrado com Sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
