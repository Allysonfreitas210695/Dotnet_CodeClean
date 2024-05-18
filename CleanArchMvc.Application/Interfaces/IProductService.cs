using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.Dtos;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetById(int? id);
        Task<ProductDto> GetProductCategory(int? id);
        Task Add(ProductDto product);
        Task Update(ProductDto product);
        Task Remove(ProductDto product);
    }
}