using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTrackerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transactions = new List<FinanceTracker>
            {
                new FinanceTracker
                {
                    Id = 1,
                    TransactionName = "dummy transaction",
                    Amount = 250.99,
                    TransactionDate = new DateOnly(1, 1, 2001),
                    Description = "i bought something incredibly expensive"
                }
            };

            return Ok(transactions);
        }
    }
}
