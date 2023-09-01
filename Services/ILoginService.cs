using API_Morada.Models;

namespace API_Morada.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<Login>> GetLogins();
        Task<Login> GetLogin(int id);

        Task InsertLogin(Login login);
        Task UpdateLogin(Login login);
        Task DeleteLogin(Login login);
    }
}
