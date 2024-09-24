using Library.Domain.Models;
using Library.Services.Interaces;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Library.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceBook _bookService;

        public BooksController(IServiceBook bookServices)
        {
            this._bookService = bookServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks(string sortOrder = "title", int page = 1, int pageSize = 5)
        {
            var book = await _bookService.GetAllAsync(sortOrder, page, pageSize);
            if (book is null)
                return NotFound();

            return Ok(book);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(BookDto book)
        {

            var result = await _bookService.CreateAsync(book);

            if (result.IsSuccess)
                return Ok();



            return NotFound(result);
        }

        [HttpPut]
        public async Task<ActionResult<BookDto>> PutBook(int id, BookDto book)
        {
            var result = await _bookService.UpdateAsync(id, book);
            if (result.IsSuccess)
                return NoContent();

            return NotFound();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<BookDto>> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(int authorId)
        {
            var books = await _bookService.GetBooksByAuthorId(authorId);
            if (books is null)
                return NotFound();

            return Ok(books);
        }





    }
}
