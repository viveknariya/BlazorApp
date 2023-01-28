using BlazorApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorApp.Data
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public  async Task<List<User>> GetAllAsync()
        {
            return await _context.users.ToListAsync();
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                return false;
            }
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            var editUser = await _context.users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (editUser == null)
            {
                return null;
            }
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Password = user.Password;
            editUser.Role = user.Role;
            _context.users.Update(editUser);
            return editUser;
        }
        public async Task<User> LoginAsync(LoginDto login)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null)
            {
                return null;
            }
            if(user.Password != login.Password)
            {
                return null;
            }
            return user;
        }
        public async Task<List<User>> GetAllByConAsync(int skip, int take)
        {
            return await _context.users.Skip(skip).Take(take).ToListAsync();
        }
    }
}
