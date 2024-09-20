using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllPagos();
        Task<Pago> GetPagoById(int id);
        Task AddPago(Pago pago);
        void UpdatePago(Pago pago);
    }
}
