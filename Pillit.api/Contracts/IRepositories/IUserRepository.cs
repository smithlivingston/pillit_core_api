using Pillit.api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pillit.api.Contracts.IRepositories
{
    public interface IUserRepository
    {
        public User CreateUser();
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid userId);
        Task<User> CreateAsync(User User);
        Task<User> UpdateAsync(Guid id, User user);
        Task<bool> DeleteAsync(Guid userId);
        Task<User> GetUserByEmail(string email);
    }
}
