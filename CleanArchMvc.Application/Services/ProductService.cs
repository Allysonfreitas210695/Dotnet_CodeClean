using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
             try
            {
                var productQuery = new GetProductsQuery();

                if(productQuery == null)
                    throw new ArgumentNullException("Entity could not be loaded");

                var result = await mediator.Send(productQuery);
                return mapper.Map<IEnumerable<ProductDto>>(result);
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Add(ProductDto product)
        {
            try
            {
                var productCreateCommand = mapper.Map<ProductCreateCommand>(product);
                await mediator.Send(productCreateCommand);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ProductDto> GetById(int id)
        {
            try
            {
                var productQuery = new GetProductByIdQuery(id);
                var productEntity = await mediator.Send(productQuery);
                if (productEntity == null)
                {
                    throw new ArgumentNullException("Entity could not be loaded");
                }

                var result = mapper.Map<ProductDto>(productEntity);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var productRemoveCommand = new ProductRemoveCommand(id);
                await mediator.Send(productRemoveCommand);
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
                var productUpdateCommand = mapper.Map<ProductUpdateCommand>(product);
                await mediator.Send(productUpdateCommand);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}