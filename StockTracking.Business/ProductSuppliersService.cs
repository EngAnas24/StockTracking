using AutoMapper;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;

namespace StockTracking.Business
{
    public class ProductSuppliersService
    {
        private readonly IRepository<ProductSuppliers> _ProductSuppliersRepository;
        private readonly IMapper _mapper;

        public ProductSuppliersService(IRepository<ProductSuppliers> ProductSuppliersRepository, IMapper mapper)
        {
            _ProductSuppliersRepository = ProductSuppliersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductSuppliersDTO>> GetProductSuppliersAsync()
        {
            var ProductSuppliers = await _ProductSuppliersRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductSuppliersDTO>>(ProductSuppliers);
        }

        public async Task<ProductSuppliersDTO> GetProductSuppliersByIdAsync(int id)
        {
            var ProductSuppliers = await _ProductSuppliersRepository.GetByIdAsync(id);
            return _mapper.Map<ProductSuppliersDTO>(ProductSuppliers);
        }

        public async Task AddProductSuppliersAsync(ProductSuppliersDTO ProductSuppliersDTO)
        {
            var ProductSuppliers = _mapper.Map<ProductSuppliers>(ProductSuppliersDTO);
            await _ProductSuppliersRepository.AddAsync(ProductSuppliers);
        }

        public async Task UpdateProductSuppliersAsync(int id, ProductSuppliersDTO ProductSuppliersDTO)
        {
            var ProductSuppliers = _mapper.Map<ProductSuppliers>(ProductSuppliersDTO);
            await _ProductSuppliersRepository.UpdateAsync(id, ProductSuppliers);
        }

        public async Task DeleteProductSuppliersAsync(int id)
        {
            await _ProductSuppliersRepository.DeleteAsync(id);
        }
    }
}
