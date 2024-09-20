using DataAccesLayer.Data;
using DataAccesLayer.Repositories;
using DataAccesLayer.UnitOfWork;
using NET_TEST_BASE.Repositories;


namespace NET_TEST_BASE.UnitOfWork
{
    public class UnitOfWorkT : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPagoRepository Pagos { get; private set; }

        public UnitOfWorkT(AppDbContext context)
        {
            _context = context;
            Pagos = new PagoRepository(_context);
        }

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
