using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryDto category)
        {
            try
            {
                await categoryRepository.CreateAsync(mapper.Map<Category>(category));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            try
            {
                return mapper.Map<CategoryDto>(await categoryRepository.GetByIdAsync(id));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                return mapper.Map<IEnumerable<CategoryDto>>(await categoryRepository.GetCategoriesAsync());
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Remove(CategoryDto category)
        {
            try
            {
                await categoryRepository.RemoveAsync(mapper.Map<Category>(category));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task Update(CategoryDto category)
        {
            try
            {
                await categoryRepository.UpdateAsync(mapper.Map<Category>(category));
            }
            catch (System.Exception ex)
            {
                 throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}