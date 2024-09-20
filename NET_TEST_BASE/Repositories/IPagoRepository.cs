using DataAccesLayer.Models;

namespace NET_TEST_BASE.Repositories
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllPagos();
        Task<Pago> GetPagoById(int id);
        Task AddPago(Pago pago);
        void UpdatePago(Pago pago);
    }
}
