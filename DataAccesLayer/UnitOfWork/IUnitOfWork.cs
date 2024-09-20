using DataAccesLayer.Repositories;

namespace DataAccesLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPagoRepository Pagos { get; }
        Task<int> Complete();
    }
}
