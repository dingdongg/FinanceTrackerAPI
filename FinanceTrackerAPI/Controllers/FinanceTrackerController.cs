using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<List<FinanceTracker>>> Get()
        {
            return Ok(transactions);
        }

        [HttpGet]
        public async Task<ActionResult<FinanceTracker>> GetTransactionById(int id)
        {
            var transaction = transactions.Find(x => x.Id == id);
            if (transaction == null)
            {
                return BadRequest($"Transaction #{id} was not found.");
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<FinanceTracker>> AddTransaction(FinanceTracker transaction)
        {
            transactions.Add(transaction);
            return Ok(transaction);
        }
    }
}
