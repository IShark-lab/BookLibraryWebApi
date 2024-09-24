using Library.Domain.Models;
using Library.Services.Interaces;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceAuthor _authorServices;

        public AuthorsController(IServiceAuthor authorServices)
        {
            this._authorServices = authorServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorServices.GetAllAsync();
            if (authors is null)
                return NotFound();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorServices.GetAsync(id);
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> PostAuthor(AuthorDto author)
        {
            
            var result = await _authorServices.CreateAsync(author);

            if (result.IsSuccess)
                return Ok();



            return NotFound(result);
        }



        [HttpPut]
        public async Task<ActionResult<AuthorDto>> PutAuthor(int id, AuthorDto author)
        {
            var result = await _authorServices.UpdateAsync(id, author);
            if (result.IsSuccess)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDto>> DeleteAuthor(int id)
        {
            await _authorServices.DeleteAsync(id);
            return NoContent();
        }



        [HttpGet("/books/{bookId}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorByBook(int bookId)
        {
            var author = await _authorServices.GetAuthorByBookAsync(bookId);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

    }
}
