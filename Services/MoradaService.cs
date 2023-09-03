﻿using API_Morada.Context;
using API_Morada.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Morada.Services
{
    public class MoradaService : IMoradaService
    {
        private readonly AppDbContext _context;

        public MoradaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Morada>> GetMorada()
        {
            try
            {
                return await _context.Morada.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Morada> GetMorada(int id)
        {
            try
            {
                var morada = await _context.Morada.FindAsync(id);
                return morada;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Morada>> SearchMorada(string searchInput)
        {
            // Query your database based on the search input. 
            // You can customize this query to match your entity structure.
            return await _context.Morada
                .Where(m =>
                    m.morada.Contains(searchInput) ||
                    m.codigoPostal.Contains(searchInput) ||
                    m.rua.Contains(searchInput) ||
                    m.freguesia.Contains(searchInput) ||
                    m.concelho.Contains(searchInput) ||
                    m.distrito.Contains(searchInput) ||
                    m.pais.Contains(searchInput))
                .ToListAsync();
        }

        public async Task InsertMorada(Morada morada)
        {
            try
            {
                _context.Morada.Add(morada);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateMorada(Morada morada)
        {
            try
            {
                _context.Entry(morada).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteMorada(Morada morada)
        {
            try
            {
                _context.Morada.Remove(morada);
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