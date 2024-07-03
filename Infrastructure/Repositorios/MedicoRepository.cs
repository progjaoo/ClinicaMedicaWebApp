using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManageWebApp.Infrastructure.Repositorios
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public MedicoRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Medico>> GetAllAsync()
        {
            return await _dbcontext.Medicos
                .Include(m => m.Especialidade)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _dbcontext.Medicos.SingleOrDefaultAsync(p => p.IdMedico == id);
        }

        public async Task AddAsync(Medico medico)
        {
            await _dbcontext.AddAsync(medico);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Medico medico)
        {
            _dbcontext.Update(medico);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await _dbcontext.Medicos.FindAsync(id);
            _dbcontext.Medicos.Remove(medico);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
