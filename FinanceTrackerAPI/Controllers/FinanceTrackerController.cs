using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTrackerController : ControllerBase
    {
        private static List<FinanceTracker> transactions = new List<FinanceTracker>
        {
            new FinanceTracker
            {
                Id = 1,
                TransactionName = "dummy transaction",
                Amount = 250.99,
                Year = 2001,
                Month = 1,
                Day = 1,
                Description = "i bought something incredibly expensive"
            },
            new FinanceTracker
            {
                Id = 2,
                TransactionName = "another dummy transaction",
                Amount = 1234.66,
                Year = 2022,
                Month = 5,
                Day = 9,
                Description = "some description!"
            }
        };
        private readonly DataContext _context;

        public FinanceTrackerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FinanceTracker>>> Get()
        {
            return Ok(await _context.FinanceTrackers.ToListAsync());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]  -->  redundant; Route() is better used to route HTTP requests to a particular controller, not a specific method
        public async Task<ActionResult<FinanceTracker>> GetTransactionById(int id)
        {
            var transaction = await _context.FinanceTrackers.FindAsync(id);
            if (transaction == null)
            {
                return NotFound($"Transaction #{id} was not found. (GET)");
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<FinanceTracker>> AddTransaction(FinanceTracker transaction)
        {
            _context.FinanceTrackers.AddAsync(transaction);
            // submit the changes to the database
            await _context.SaveChangesAsync();
            // change to return 201 code later
            return Ok(transaction);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTransaction(FinanceTracker transaction)
        {
            var oldTransaction = transactions.Find(x => x.Id == transaction.Id);
            if (oldTransaction == null)
            {
                // 404
                return NotFound($"Transaction #{transaction.Id} was not found. (PUT)");
            }

            // switch to automapper implementation for this later
            oldTransaction.TransactionName = transaction.TransactionName;
            oldTransaction.Amount = transaction.Amount;
            oldTransaction.Year = transaction.Year;
            oldTransaction.Month = transaction.Month;
            oldTransaction.Day = transaction.Day;
            oldTransaction.Description = transaction.Description;

            // 204
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);
            if (transaction == null)
            {
                return NotFound($"Transaction #{transaction.Id} was not found. (DELETE)");
            }
            transactions.Remove(transaction);
            return NoContent();
        }
    }
}
