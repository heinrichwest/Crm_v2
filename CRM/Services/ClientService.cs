using CRM.Data;
using CRM.Models;
using Microsoft.EntityFrameworkCore; // if you need access to AppDbContext

namespace CRM.Services
{
    public class ClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        // Example method
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
