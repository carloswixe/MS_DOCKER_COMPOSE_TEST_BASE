using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories
{
    public interface IBeneficiarioRepository
    {
        Task<IEnumerable<Beneficiario>> GetAllBeneficiarios();
        Task<Beneficiario> GetBeneficiarioById(int id);
        Task AddBeneficiario(Beneficiario beneficiario);
        void UpdateBeneficiario(Beneficiario beneficiario);
    }
}
