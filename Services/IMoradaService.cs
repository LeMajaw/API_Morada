using API_Morada.Models;

namespace API_Morada.Services
{
    public interface IMoradaService
    {
        Task<IEnumerable<Morada>> GetMorada();
        Task<Morada> GetMorada(int id);

        Task InsertMorada(Morada morada);
        Task UpdateMorada(Morada morada);
        Task DeleteMorada(Morada morada);
    }
}
