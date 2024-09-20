using Library.Domain.Models;
using Library.Services.Interaces;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly IServiceBorrower _serviceBorrower;
        public BorrowerController(IServiceBorrower serviceBorrower)
        {
            this._serviceBorrower = serviceBorrower;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowerDto>>> GetBorrowers()
        {
            var borrower = await _serviceBorrower.GetAllAsync();
            if (borrower is null)
                return NotFound();

            return Ok(borrower);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowerDto>> GetBorrower(int id)
        {
            var borrower = await _serviceBorrower.GetAsync(id);
            if(borrower == null)
                return NotFound();

            return borrower;
        }

        [HttpPost]
        public async Task<ActionResult<BorrowerDto>> PostBorrower(BorrowerDto borrower)
        {
            var result = await _serviceBorrower.CreateAsync(borrower);

            if (result.IsSuccess)
                return Ok();

            return NotFound(result);
        }

        [HttpPut]
        public async Task<ActionResult<BorrowerDto>> PutBorrower(int id, BorrowerDto borrower)
        {
            var result = await _serviceBorrower.UpdateAsync(id, borrower);
            if (result.IsSuccess)
                return NoContent();

            return NotFound();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<BorrowerDto>> DeleteBorrower(int id)
        {
            await _serviceBorrower.DeleteAsync(id);
            return NoContent();
        }

    }
}
