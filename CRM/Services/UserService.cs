using CRM.Data;
using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Example method
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Retrieves a user by its identifier.
        /// </summary>
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <summary>
        /// Creates a new user entry in the database.
        /// </summary>
        /// <param name="user">User details to insert.</param>
        /// <returns>The created user with its database generated values.</returns>
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a user by its identifier.
        /// </summary>
        public async Task DeleteUserAsync(int id)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing != null)
            {
                _context.Users.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
