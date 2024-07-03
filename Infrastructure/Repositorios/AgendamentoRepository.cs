using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManageWebApp.Infrastructure.Repositorios
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public AgendamentoRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Agendamento?>> GetAllAsync()
        {
            return await _dbcontext.Agendamentos
                .Include(m => m.Medico)
                .Include(m => m.Paciente)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Agendamento> GetByIdAsync(int id)
        {
            return await _dbcontext.Agendamentos
                .Include(m => m.Medico)
                .Include(m => m.Paciente)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.IdAgendamento == id);
        }
        public async Task AddAsync(Agendamento agendamento)
        {
            await _dbcontext.AddAsync(agendamento);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Agendamento agendamento)
        {
            _dbcontext.Update(agendamento);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agendamento = await _dbcontext.Agendamentos.FindAsync(id);
            _dbcontext.Agendamentos.Remove(agendamento);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
