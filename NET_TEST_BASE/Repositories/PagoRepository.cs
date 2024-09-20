using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Data;
using DataAccesLayer.Models;
using DataAccesLayer.Repositories;

namespace NET_TEST_BASE.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pago>> GetAllPagos() => await _context.Pagos.Include(f => f.Ordenante).Include(f => f.Beneficiario).ToListAsync();

        public async Task<Pago> GetPagoById(int id) => await _context.Pagos.Where(f => f.Id == id).Include(f => f.Ordenante).Include(f => f.Beneficiario).FirstOrDefaultAsync();

        public async Task AddPago(Pago pago) => await _context.Pagos.AddAsync(pago);

        public void UpdatePago(Pago pago) => _context.Pagos.Update(pago);
    }
}
