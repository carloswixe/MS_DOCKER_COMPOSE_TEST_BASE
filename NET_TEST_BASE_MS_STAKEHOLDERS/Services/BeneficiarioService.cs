using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using DataAccesLayer.Services;
using DataAccesLayer.UnitOfWork;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Services
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        public BeneficiarioService(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        public async Task<IEnumerable<Beneficiario>> GetAllBeneficiarios() =>await _beneficiarioRepository.GetAllBeneficiarios();

        public async Task<Beneficiario> GetBeneficiarioById(int id)
        {
            return await _beneficiarioRepository.GetBeneficiarioById(id);            
        }

        public async Task AddBeneficiario(Beneficiario beneficiario)
        {
            await _beneficiarioRepository.AddBeneficiario(beneficiario);            
        }

        public async Task UpdateBeneficiarioNombre(int id, string nombre)
        {
            var beneficiario = await _beneficiarioRepository.GetBeneficiarioById(id);
            if (beneficiario != null)
            {
                beneficiario.Nombre = nombre;
                _beneficiarioRepository.UpdateBeneficiario(beneficiario);                
            }
        }
    }
}
