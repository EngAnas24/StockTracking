using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTracking.Business;
using StockTracking.Models;
using StockTracking.Models.DTOs;
using System;

namespace StockTracking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService _TransactionsService;

        public TransactionsController(TransactionsService TransactionsService)
        {
           _TransactionsService = TransactionsService;
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var Transactions = await _TransactionsService.GetTransactionsAsync();
            return Ok(Transactions);
        }


        [HttpGet("GetTransaction/{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {
        var Transaction = await _TransactionsService.GetTransactionsByIdAsync(id);
        if (Transaction == null)
        {
            return NotFound();
        }
        return Ok(Transaction);
    }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction( TransactionsDTO TransactionDTO)
        {
          
            if (TransactionDTO == null)
            {
                return BadRequest("Transaction data is null.");
            }

            await _TransactionsService.AddTransactionsAsync(TransactionDTO);
            return CreatedAtAction(nameof(GetTransaction), new { id = TransactionDTO.Id }, TransactionDTO);
        }


        [HttpPut("UpdateTransaction/{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, TransactionsDTO TransactionDTO)
    {
        if (id != TransactionDTO.Id)
        {
            return BadRequest();
        }
            
            await _TransactionsService.UpdateTransactionsAsync(id, TransactionDTO);
           return Ok(TransactionDTO);
    }

    [HttpDelete("DeleteTransaction/{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        await _TransactionsService.DeleteTransactionsAsync(id);
        return Ok("Transaction deleted successfully");
    }
}
}
