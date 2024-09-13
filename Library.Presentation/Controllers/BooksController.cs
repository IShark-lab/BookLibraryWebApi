using Library.Services.Models;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Library.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookServices = new BookServices();



        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var book = await _bookServices.GetAllAsync();
            if (book is null)
                return NotFound();

            return Ok(book);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _bookServices.GetAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO book)
        {
            var result = await _bookServices.CreateAsync(book);
            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);

            return NotFound(result);
        }

        [HttpPut]
        public async Task<ActionResult<BookDTO>> PutBook(int id, BookDTO book)
        {
            var result = await _bookServices.UpdateAsync(id, book);
            if (result.IsSuccess)
                return NoContent();

            return NotFound();  
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<BookDTO>> DeleteBook(int id)
        {
            await _bookServices.DeleteAsync(id);
            return NoContent();
        }

    }
}
