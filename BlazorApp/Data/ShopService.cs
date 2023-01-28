using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ShopService : IShopService
    {
        private readonly DataContext _context;

        public ShopService(DataContext context)
        {
            _context = context;
        }
        public async Task<Shop> CreateAsync(Shop shop)
        {
            await _context.shops.AddAsync(shop);
            await _context.SaveChangesAsync();
            return shop;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var shop = await _context.shops.FirstOrDefaultAsync(s => s.Id == id);
            if(shop == null)
            {
                return false;
            }
            _context.shops.Remove(shop);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Shop>> GetAllAsync()
        {
            return await _context.shops.ToListAsync();
        }

        public async Task<Shop> GetByIdAsync(int id)
        {
            var shop = await _context.shops.FirstOrDefaultAsync(s => s.Id == id);
            if (shop == null)
            {
                return null;
            }
            return shop;
        }

        public async Task<Shop> UpdateAsync(Shop shop)
        {
            var editShop = await _context.shops.FirstOrDefaultAsync(s => s.Id == shop.Id);
            if(editShop == null) 
            { 
                return null;
            }
            editShop.Name = shop.Name;
            editShop.Country = shop.Country;
            editShop.Address = shop.Address;

            _context.shops.Update(editShop);
            await _context.SaveChangesAsync();
            return editShop;
        }
    }
}
