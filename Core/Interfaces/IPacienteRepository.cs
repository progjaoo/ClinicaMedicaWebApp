using ClinicManageWebApp.Core.Entidades;

namespace ClinicManageWebApp.Core.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
