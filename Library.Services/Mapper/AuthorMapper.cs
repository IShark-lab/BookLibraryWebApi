using Library.DataAccess.Entities;
using Library.Domain.Models;
using Library.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Mapper
{
    public class AuthorMapper : IMapper<AuthorDto, Author>
    {
        public AuthorDto ToDto(Author entity)
        {
            return new AuthorDto
            {
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }

        public AuthorDto ToDtoWithId(Author entity)
        {
            return new AuthorDto
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }

        public Author ToEntity(AuthorDto entity)
        {
            return new Author
            {
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }

        public Author ToEntityWithId(AuthorDto entityDto)
        {
            return new Author
            {
                Id = entityDto.Id,
                DateOfBirth = entityDto.DateOfBirth,
                FirstName = entityDto.FirstName,
                LastName = entityDto.LastName,
            };
        }
    }
}
