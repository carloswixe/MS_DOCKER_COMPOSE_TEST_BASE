using DataAccesLayer.Models;
using NET_TEST_BASE.DTOs;

namespace NET_TEST_BASE.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> GetAllPagos();
        Task<Pago> GetPagoById(int id);
        Task AddPago(Pago pago);
        Task UpdatePagoEstatus(int id, string nuevoEstatus);
    }
}
