using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Library.DataAccess.Repositories;
using Library.Domain.Models;
using Library.Services.Interaces;
using Library.Services.Mapper;
using Library.Services.Repositories;
using Microsoft.EntityFrameworkCore.Query;


namespace Library.Services.Services
{
    public class AuthorServices : IServiceAuthor
    {

        private readonly IRepositoryAuthor _authorRepository;
        private readonly IMapper<AuthorDto, Author> _authorMapper;

        public AuthorServices(IRepositoryAuthor authorRepository, IMapper<AuthorDto, Author> mapper)
        {
            this._authorRepository = authorRepository;
            this._authorMapper = mapper;
        }



        public async Task<ServiceResult> CreateAsync(AuthorDto authorDto)
        {
            try
            {
                var book = _authorMapper.ToEntity(authorDto);

                await _authorRepository.CreateAsync(book);

                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to create book");
            }
        }

        
        public async Task DeleteAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }



        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            if (authors is null)
            {
                return Enumerable.Empty<AuthorDto>();
            }
            var authorsDto = authors.Select(x => _authorMapper.ToDtoWithId(x)).ToList();
             

            return authorsDto;
        }


        public async Task<AuthorDto> GetAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author is null)
            {
                return null;
            }

            var authorDto = _authorMapper.ToDtoWithId(author);

            return authorDto;
        }


        public async Task<AuthorDto> GetAuthorByBookAsync(int bookId)
        {
            var author = await _authorRepository.GetAuthorByBook(bookId);
            if (author is null)
                return null;
            
            var authorDto = _authorMapper.ToDto(author);
            return authorDto;
        }


        public async Task<ServiceResult> UpdateAsync(int id, AuthorDto authorDto)
        {
            try
            {
                var author = _authorMapper.ToEntity(authorDto);
                author.Id = id;

                await _authorRepository.UpdateAsync(id, author);
                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to update book");
            }
        }
    }
}
