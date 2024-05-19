using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoriyRepository : ICategoryRepository
    {
        private readonly ApplicationContext context;

        public CategoriyRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                await context.AddAsync(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            try
            {
                return await context.Categories.FindAsync(id);
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                return await context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            try
            {
                context.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            try
            {
                context.Update(category);
                await context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}