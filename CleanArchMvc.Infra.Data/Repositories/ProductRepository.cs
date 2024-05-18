using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                context.Remove(product);
                await context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            try
            {
                return await context.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            try
            {
                return await context.Products.Where(x => x.Id == id).Include(x => x.Category).FirstAsync();
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            try
            {
                context.Remove(product);
                await context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
             try
            {
                context.Update(product);
                await context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}