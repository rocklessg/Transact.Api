using Microsoft.AspNetCore.Mvc;
using Transact.Application.DTOs.Requests;
using Transact.Application.Interfaces;

namespace Transact.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
    {
        var result = await _transactionService.ProcessTransferAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("airtime")]
    public async Task<IActionResult> BuyAirtime([FromBody] BuyAirtimeRequest request)
    {
        var result = await _transactionService.ProcessAirtimePurchaseAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("history/{accountNumber}")]
    public async Task<IActionResult> GetTransactionHistory(string accountNumber)
    {
        var result = await _transactionService.GetTransactionHistoryAsync(accountNumber);
        
        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}
