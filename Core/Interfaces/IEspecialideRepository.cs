using ClinicManageWebApp.Core.Entidades;

namespace ClinicManageWebApp.Core.Interfaces
{
    public interface IEspecialideRepository
    {
        Task<List<Especialidade>> GetAllAsync();
    }
}
