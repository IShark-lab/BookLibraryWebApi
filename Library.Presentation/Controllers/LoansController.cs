using Library.Domain.Models;
using Library.Services.Interaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IServiceLoan _serviceLoan;

        public LoansController(IServiceLoan serviceLoan)
        {
            this._serviceLoan = serviceLoan;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> Getloans()
        {
            var loan = await _serviceLoan.GetAllAsync();
            if (loan is null)
                return NotFound();

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> Getloan(int id)
        {
            var loan = await _serviceLoan.GetAsync(id);
            if (loan == null)
                return NotFound();

            return loan;
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> Postloan(LoanDto loan)
        {
            var result = await _serviceLoan.CreateAsync(loan);

            if (result.IsSuccess)
                return Ok();

            return NotFound(result);
        }

        [HttpPut]
        public async Task<ActionResult<LoanDto>> Putloan(int id, LoanDto loan)
        {
            var result = await _serviceLoan.UpdateAsync(id, loan);
            if (result.IsSuccess)
                return NoContent();

            return NotFound();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<LoanDto>> Deleteloan(int id)
        {
            await _serviceLoan.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("books/{borrowerId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByBorrowerId(int borrowerId)
        {
            var books = await _serviceLoan.GetBooksByBorrowerId(borrowerId);
            if(books == null) 
                return NotFound();

            return Ok(books);
        }
    }
}
