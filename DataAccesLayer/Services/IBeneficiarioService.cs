using DataAccesLayer.Models;

namespace DataAccesLayer.Services
{
    public interface IBeneficiarioService
    {
        Task<IEnumerable<Beneficiario>> GetAllBeneficiarios();
        Task<Beneficiario> GetBeneficiarioById(int id);
        Task AddBeneficiario(Beneficiario beneficiario);
        Task UpdateBeneficiarioNombre(int id, string nombre);
    }
}
