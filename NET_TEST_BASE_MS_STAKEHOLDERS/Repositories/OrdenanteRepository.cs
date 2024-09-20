using DataAccesLayer.Data;
using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Repositories
{
    public class OrdenanteRepository : IOrdenanteRepository
    {
        private readonly AppDbContext _context;
        public OrdenanteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ordenante>> GetAllOrdenantes() => await _context.Ordenante.ToListAsync();


        public async Task<Ordenante> GetOrdenanteById(int id) => await _context.Ordenante.Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task AddOrdenante(Ordenante ordenante)
        {
            await _context.Ordenante.AddAsync(ordenante);
            await _context.SaveChangesAsync();
        }

        public void UpdateOrdenante(Ordenante ordenante)
        {
            _context.Ordenante.Update(ordenante);
            _context.SaveChanges();
        }
    }
}
