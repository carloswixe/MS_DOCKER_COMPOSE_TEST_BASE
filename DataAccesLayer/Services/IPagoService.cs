using DataAccesLayer.Models;

namespace DataAccesLayer.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> GetAllPagos();
        Task<Pago> GetPagoById(int id);
        Task AddPago(Pago pago);
        Task UpdatePagoEstatus(int id, string nuevoEstatus);
    }
}
