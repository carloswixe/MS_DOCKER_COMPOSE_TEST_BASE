using NET_TEST_BASE.Repositories;

namespace NET_TEST_BASE.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPagoRepository Pagos { get; }
        Task<int> Complete();
    }
}
