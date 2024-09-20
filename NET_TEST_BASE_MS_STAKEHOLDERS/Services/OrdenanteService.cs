using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using DataAccesLayer.Services;
using NET_TEST_BASE_MS_STAKEHOLDERS.Repositories;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Services
{
    public class OrdenanteService : IOrdenanteService
    {
        private readonly IOrdenanteRepository _ordenanteRepository;
        public OrdenanteService(IOrdenanteRepository ordenanteRepository)
        {
            _ordenanteRepository = ordenanteRepository;
        }
        public async Task<IEnumerable<Ordenante>> GetAllOrdenantes() => await _ordenanteRepository.GetAllOrdenantes();

        public async Task<Ordenante> GetOrdenanteById(int id)
        {
            return await _ordenanteRepository.GetOrdenanteById(id);
        }

        public async Task AddOrdenante(Ordenante ordenante)
        {
            await _ordenanteRepository.AddOrdenante(ordenante);
        }

        public async Task UpdateOrdenanteNombre(int id, string nombre)
        {
            var ordenante = await _ordenanteRepository.GetOrdenanteById(id);
            if (ordenante != null)
            {
                ordenante.Nombre = nombre;
                _ordenanteRepository.UpdateOrdenante(ordenante);
            }
        }
    }
}
