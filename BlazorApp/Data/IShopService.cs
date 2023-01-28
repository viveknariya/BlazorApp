using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IShopService
    {
        public Task<List<Shop>> GetAllAsync();
        public Task<Shop> GetByIdAsync(int id);
        public Task<Shop> CreateAsync(Shop shop);
        public Task<Shop> UpdateAsync(Shop shop);
        public Task<bool> DeleteAsync(int id);
    }
}
