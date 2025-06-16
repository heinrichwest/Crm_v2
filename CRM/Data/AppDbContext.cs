using Microsoft.EntityFrameworkCore;
using CRM.Models;

namespace CRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Services.Client> Clients => Set<Services.Client>();
        public DbSet<User> Users => Set<User>();
    }
}
