using AutoMapper;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;

namespace StockTracking.Business
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategorysAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddCategoryAsync(CategoryDTO CategoryDTO)
        {
            var category = _mapper.Map<Category>(CategoryDTO);
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(int id,CategoryDTO CategoryDTO)
        {
            var Category = _mapper.Map<Category>(CategoryDTO);
            await _categoryRepository.UpdateAsync(id,Category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
