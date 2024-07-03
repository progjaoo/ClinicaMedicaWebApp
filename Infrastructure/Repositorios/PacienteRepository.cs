using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManageWebApp.Infrastructure.Repositorios
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public PacienteRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _dbcontext.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _dbcontext.Pacientes.SingleOrDefaultAsync(p => p.IdPaciente == id);
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _dbcontext.AddAsync(paciente);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Paciente paciente)
        {
            _dbcontext.Update(paciente);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await _dbcontext.Pacientes.FindAsync(id);
            _dbcontext.Pacientes.Remove(paciente);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
