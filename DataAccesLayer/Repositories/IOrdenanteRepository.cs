using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories
{
    public interface IOrdenanteRepository
    {
        Task<IEnumerable<Ordenante>> GetAllOrdenantes();
        Task<Ordenante> GetOrdenanteById(int id);
        Task AddOrdenante(Ordenante ordenante);
        void UpdateOrdenante(Ordenante ordenante);
    }
}
