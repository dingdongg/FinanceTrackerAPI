using FinanceTrackerAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTrackerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly MockTransactionRepo _repository = new MockTransactionRepo();

        public FinanceTrackerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            return Ok(_repository.GetAllTransactions());
            //return Ok(await _context.FinanceTrackers.ToListAsync());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]  -->  redundant; Route() is better used to route HTTP requests to a particular controller, not a specific method
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = _repository.GetTransactionById(id);
            return Ok(transaction);
            //var transaction = await _context.FinanceTrackers.FindAsync(id);
            //if (transaction == null)
            //{
            //    return NotFound($"Transaction #{id} was not found. (GET)");
            //}
            //return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> AddTransaction(Transaction transaction)
        {
            _context.FinanceTrackers.Add(transaction);
            // submit the changes to the database
            await _context.SaveChangesAsync();
            // change to return 201 code later
            return Ok(transaction);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTransaction(Transaction transaction)
        {
            var dbTransaction = await _context.FinanceTrackers.FindAsync(transaction.Id);
            if (dbTransaction == null)
            {
                // 404
                return NotFound($"Transaction #{transaction.Id} was not found. (PUT)");
            }

            // switch to automapper implementation for this later
            dbTransaction.Name = transaction.Name;
            dbTransaction.Amount = transaction.Amount;
            dbTransaction.Year = transaction.Year;
            dbTransaction.Month = transaction.Month;
            dbTransaction.Day = transaction.Day;
            dbTransaction.Description = transaction.Description;

            await _context.SaveChangesAsync();

            // 204
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.FinanceTrackers.FindAsync(id);
            if (transaction == null)
            {
                return NotFound($"Transaction #{id} was not found. (DELETE)");
            }
            _context.FinanceTrackers.Remove(transaction);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
