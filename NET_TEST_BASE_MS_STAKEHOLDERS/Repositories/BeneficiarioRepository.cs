using DataAccesLayer.Data;
using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Repositories
{
    public class BeneficiarioRepository : IBeneficiarioRepository
    {
        private readonly AppDbContext _context;
        public BeneficiarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beneficiario>> GetAllBeneficiarios() => await _context.Beneficiario.ToListAsync();


        public async Task<Beneficiario> GetBeneficiarioById(int id) => await _context.Beneficiario.Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task AddBeneficiario(Beneficiario beneficiario)
        {
           await _context.Beneficiario.AddAsync(beneficiario);
           await _context.SaveChangesAsync();
        }

        public void UpdateBeneficiario(Beneficiario beneficiario){
            _context.Beneficiario.Update(beneficiario);
            _context.SaveChanges();
        }
    }
}
