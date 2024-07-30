using AutoMapper;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;

namespace StockTracking.Business
{
    public class SuppliersService
    {
        private readonly IRepository<Suppliers> _SuppliersRepository;
        private readonly IMapper _mapper;

        public SuppliersService(IRepository<Suppliers> SuppliersRepository, IMapper mapper)
        {
            _SuppliersRepository = SuppliersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SuppliersDTO>> GetSuppliersAsync()
        {
            var Suppliers = await _SuppliersRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SuppliersDTO>>(Suppliers);
        }

        public async Task<SuppliersDTO> GetSuppliersByIdAsync(int id)
        {
            var Suppliers = await _SuppliersRepository.GetByIdAsync(id);
            return _mapper.Map<SuppliersDTO>(Suppliers);
        }

        public async Task AddSuppliersAsync(SuppliersDTO SuppliersDTO)
        {
            var Suppliers = _mapper.Map<Suppliers>(SuppliersDTO);
            await _SuppliersRepository.AddAsync(Suppliers);
        }

        public async Task UpdateSuppliersAsync(int id, SuppliersDTO SuppliersDTO)
        {
            var Suppliers = _mapper.Map<Suppliers>(SuppliersDTO);
            await _SuppliersRepository.UpdateAsync(id, Suppliers);
        }

        public async Task DeleteSuppliersAsync(int id)
        {
            await _SuppliersRepository.DeleteAsync(id);
        }
    }
}
