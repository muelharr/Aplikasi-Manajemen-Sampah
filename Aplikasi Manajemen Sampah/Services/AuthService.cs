using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Aplikasi_Manajemen_Sampah.Models;
using System.Diagnostics;

namespace Aplikasi_Manajemen_Sampah.Services
{
    public class AuthService
    {
        private readonly IMongoCollection<User> _users;

        public AuthService()
        {
            var mongo = new MongoService();
            _users = mongo.Users;
        }

        public async Task<bool> CreateUserAsync(string username, string plainPassword, string role = "Petugas")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(plainPassword))
                    throw new ArgumentException("Username dan Password wajib diisi.");

                var exists = await _users.Find(u => u.Username == username).AnyAsync();
                if (exists) throw new InvalidOperationException($"Username '{username}' sudah terdaftar.");

                var user = new User
                {
                    Username = username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword),
                    Role = role
                };

                await _users.InsertOneAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error CreateUser: {ex.Message}");
                throw;
            }
        }

        public async Task<User?> LoginAsync(string username, string plainPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(plainPassword)) return null;

                var user = await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
                if (user == null) return null;

                bool verified = BCrypt.Net.BCrypt.Verify(plainPassword, user.PasswordHash);
                return verified ? user : null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Login: {ex.Message}");
                return null;
            }
        }
    }
}