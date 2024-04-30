using Pillit.api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pillit.api.Contracts.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid userId);
        Task<User> CreateUser(User User);
        Task UpdateAsync(Guid userId, User User);
        Task<bool> DeleteAsync(Guid userId);
    }
}
