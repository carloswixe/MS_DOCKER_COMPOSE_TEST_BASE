using DataAccesLayer.Models;
using DataAccesLayer.Services;
using DataAccesLayer.UnitOfWork;


namespace NET_TEST_BASE.Services
{
    public class PagoService : IPagoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Pago>> GetAllPagos() => await _unitOfWork.Pagos.GetAllPagos();

        public async Task<Pago> GetPagoById(int id) {

            var pago=await _unitOfWork.Pagos.GetPagoById(id);
            return pago;
         }

        public async Task AddPago(Pago pago)
        {
            await _unitOfWork.Pagos.AddPago(pago);
            await _unitOfWork.Complete();
        }

        public async Task UpdatePagoEstatus(int id, string nuevoEstatus)
        {
            var pago = await _unitOfWork.Pagos.GetPagoById(id);
            if (pago != null)
            {
                pago.Estatus = nuevoEstatus;
                _unitOfWork.Pagos.UpdatePago(pago);
                await _unitOfWork.Complete();
            }
        }
    }
}
