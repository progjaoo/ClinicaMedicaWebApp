using ClinicManageWebApp.Core.Entidades;

namespace ClinicManageWebApp.Core.Interfaces
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> GetAllAsync();
        Task<Medico> GetByIdAsync(int id);
        Task AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
