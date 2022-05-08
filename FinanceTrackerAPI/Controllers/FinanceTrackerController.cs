using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTrackerController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<FinanceTracker>>> Get()
        {
            var transactions = new List<FinanceTracker>
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
                }
            };

            return Ok(transactions);
        }
    }
}
