using API_Morada.Context;
using API_Morada.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Morada.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Login>> GetLogins()
        {
            try
            {
                return await _context.Login.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Login> GetLogin(int id)
        {
            try
            {
                var login = await _context.Login.FindAsync(id);
                return login;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task InsertLogin(Login login)
        {
            try
            {
                _context.Login.Add(login);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateLogin(Login login)
        {
            try
            {
                _context.Entry(login).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteLogin(Login login)
        {
            try
            {
                _context.Login.Remove(login);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
