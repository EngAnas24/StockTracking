using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;

namespace StockTracking.Business
{
    public class ProductWarehouseService
    {
        private readonly IRepository<ProductWarehouse> _ProductWarehouseRepository;
        private readonly IMapper _mapper;

        public ProductWarehouseService(IRepository<ProductWarehouse> ProductWarehouseRepository, IMapper mapper)
        {
            _ProductWarehouseRepository = ProductWarehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductWarehouseDTO>> GetProductWarehousesAsync()
        {
            var productWarehouses = await _ProductWarehouseRepository.GetAllAsync();

            var productWarehouseDTOs = _mapper.Map<IEnumerable<ProductWarehouseDTO>>(productWarehouses);

            return productWarehouseDTOs;
        }


        public async Task<ProductWarehouseDTO> GetProductWarehouseByIdAsync(int id)
        {
                var productWarehouses = await _ProductWarehouseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductWarehouseDTO>(productWarehouses);
        }

        public async Task AddProductWarehouseAsync(ProductWarehouse productWarehouse)
        {
            await _ProductWarehouseRepository.AddAsync(productWarehouse);
        }


        public async Task UpdateProductWarehouseAsync(int id, ProductWarehouseDTO ProductWarehouseDto)
        {
            var ProductWarehouse = _mapper.Map<ProductWarehouse>(ProductWarehouseDto);
            await _ProductWarehouseRepository.UpdateAsync(id, ProductWarehouse);
        }

        public async Task DeleteProductWarehouseAsync(int id)
        {
            await _ProductWarehouseRepository.DeleteAsync(id);
        }
    }
}
