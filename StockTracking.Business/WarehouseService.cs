using AutoMapper;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;

namespace StockTracking.Business
{
    public class WarehouseService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IRepository<Warehouse> warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDTO>> GetWarehousesAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseDTO>>(warehouses);
        }

        public async Task<WarehouseDTO> GetWarehouseByIdAsync(int id)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id);
            return _mapper.Map<WarehouseDTO>(warehouse);
        }

        public async Task AddWarehouseAsync(WarehouseDTO warehouseDto)
        {
            var warehouse = _mapper.Map<Warehouse>(warehouseDto);
            await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task UpdateWarehouseAsync(int id,WarehouseDTO warehouseDto)
        {
            var warehouse = _mapper.Map<Warehouse>(warehouseDto);
            await _warehouseRepository.UpdateAsync(id, warehouse);
        }

        public async Task DeleteWarehouseAsync(int id)
        {
            await _warehouseRepository.DeleteAsync(id);
        }
    }
}
