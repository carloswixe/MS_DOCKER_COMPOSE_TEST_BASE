using DataAccesLayer.Models;

namespace DataAccesLayer.Services
{
    public interface IOrdenanteService
    {
        Task<IEnumerable<Ordenante>> GetAllOrdenantes();
        Task<Ordenante> GetOrdenanteById(int id);
        Task AddOrdenante(Ordenante ordenante);
        Task UpdateOrdenanteNombre(int id, string nombre);
    }
}
