using AutoMapper;
using StockTracking.Data;
using StockTracking.Models;
using StockTracking.Models.DTOs;
using System.Linq;

namespace StockTracking.Business
{
    public class TransactionsService
    {
        private readonly IRepository<Transactions> _TransactionsRepository;
        private readonly IMapper _mapper;

        public TransactionsService(IRepository<Transactions> TransactionsRepository, IMapper mapper)
        {
            _TransactionsRepository = TransactionsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionsDTO>> GetTransactionsAsync()
        {
            var Transactions = await _TransactionsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionsDTO>>(Transactions);
        }

        public async Task<TransactionsDTO> GetTransactionsByIdAsync(int id)
        {
            var Transactions = await _TransactionsRepository.GetByIdAsync(id);
            return _mapper.Map<TransactionsDTO>(Transactions);
        }

        public async Task AddTransactionsAsync(TransactionsDTO TransactionsDTO)
        {
            var Transactions = _mapper.Map<Transactions>(TransactionsDTO);
             Transactions.CalculateAmounts();
            await _TransactionsRepository.AddAsync(Transactions);
        }

        public async Task UpdateTransactionsAsync(int id,TransactionsDTO TransactionsDTO)
        {
            var Transactions = _mapper.Map<Transactions>(TransactionsDTO);
            Transactions.CalculateAmounts();
            await _TransactionsRepository.UpdateAsync(id, Transactions);
        }

        public async Task DeleteTransactionsAsync(int id)
        {
            await _TransactionsRepository.DeleteAsync(id);
        }
    }
}
