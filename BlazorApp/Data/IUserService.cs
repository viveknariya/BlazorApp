using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(string email);
        Task<User> LoginAsync(LoginDto login);
        Task<List<User>> GetAllByConAsync(int skip,int take);
    }
}
