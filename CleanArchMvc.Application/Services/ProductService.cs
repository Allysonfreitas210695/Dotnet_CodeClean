using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task Add(ProductDto product)
        {
             try
            {
                await productRepository.CreateAsync(mapper.Map<Product>(product));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ProductDto> GetById(int? id)
        {
             try
            {
                return mapper.Map<ProductDto>(await productRepository.GetByIdAsync(id));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ProductDto> GetProductCategory(int? id)
        {
             try
            {
                return mapper.Map<ProductDto>(await productRepository.GetProductCategoryAsync(id));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
             try
            {
                return mapper.Map<IEnumerable<ProductDto>>(await productRepository.GetProductsAsync());
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Remove(ProductDto product)
        {
             try
            {
                await productRepository.RemoveAsync(mapper.Map<Product>(product));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Update(ProductDto product)
        {
             try
            {
                await productRepository.UpdateAsync(mapper.Map<Product>(product));            
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}