using ClinicManageWebApp.Core.Entidades;
using ClinicManageWebApp.Core.Interfaces;
using ClinicManageWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManageWebApp.Infrastructure.Repositorios
{
    public class EspecialideRepository : IEspecialideRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EspecialideRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Especialidade>> GetAllAsync()
        {
            return await _dbcontext.Especialidades.AsNoTracking().ToListAsync();
        }
    }
}
