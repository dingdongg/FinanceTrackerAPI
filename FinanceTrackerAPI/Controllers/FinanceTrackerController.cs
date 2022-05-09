using AutoMapper;
using FinanceTrackerAPI.DTOs;
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
        private readonly IMapper _mapper;
        private readonly ITransactionRepo _repository;

        public FinanceTrackerController(IMapper mapper, ITransactionRepo repo)
        {
            _mapper = mapper;

            // inject dependency on ITransactionRepo into FinanceTrackerController
            _repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionReadDTO>>> GetAllTransactions()
        {
            var transactions = _repository.GetAllTransactions();
            return Ok(_mapper.Map<IEnumerable<TransactionReadDTO>>(transactions));
            //return Ok(await _context.FinanceTrackers.ToListAsync());
        }

        [HttpGet("{id}", Name = "GetTransactionById")]
        //[Route("{id}")]  -->  redundant; Route() is better used to route HTTP requests to a particular controller, not a specific method
        public async Task<ActionResult<TransactionReadDTO>> GetTransactionById(int id)
        {
            var transaction = _repository.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound($"Transaction #{id} was not found. (GET)");
            }
            var returnDTO = _mapper.Map<TransactionReadDTO>(transaction);
            return Ok(returnDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionReadDTO>> AddTransaction(TransactionCreateDTO inputDTO)
        {
            var modelTransaction = _mapper.Map<Transaction>(inputDTO);
            _repository.CreateTransaction(modelTransaction);
            _repository.SaveChanges();

            var readDTO = _mapper.Map<TransactionReadDTO>(modelTransaction);

            return CreatedAtRoute(nameof(GetTransactionById), new { Id = readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction(int id, TransactionUpdateDTO inputDTO)
        {
            var transactionModel = _repository.GetTransactionById(id);
            if (transactionModel == null)
            {
                return NotFound($"Transaction #{id} was not found. (PUT)");
            }

            _mapper.Map(inputDTO, transactionModel);
            _repository.UpdateTransaction(transactionModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> TweakTransaction(int id, JsonPatchDocument<TransactionUpdateDTO> patchDoc)
        {
            var transactionModel = _repository.GetTransactionById(id);
            if (transactionModel == null)
            {
                return NotFound($"Transaction #{id} was not found. (PUT)");
            }

            var DTOtoPatch = _mapper.Map<TransactionUpdateDTO>(transactionModel);
            patchDoc.ApplyTo(DTOtoPatch, ModelState);

            if (!TryValidateModel(DTOtoPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(DTOtoPatch, transactionModel);
            _repository.UpdateTransaction(transactionModel);
            _repository.SaveChanges();

            return NoContent();

        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteTransaction(int id)
        //{
        //    var transaction = await _context.Transactions.FindAsync(id);
        //    if (transaction == null)
        //    {
        //        return NotFound($"Transaction #{id} was not found. (DELETE)");
        //    }
        //    _context.Transactions.Remove(transaction);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
