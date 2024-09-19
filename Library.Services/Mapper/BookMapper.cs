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
    public class BookMapper : IMapper<BookDto, Book>
    {
        public BookDto ToDtoWithId(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublicationDate = book.PublicationDate
            };
        }

        public Book ToEntityWithId(BookDto book)
        {
            return new Book
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublicationDate = book.PublicationDate
            };
        }
        public Book ToEntity(BookDto book)
        {
            return new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublicationDate = book.PublicationDate
            };
        }
        public BookDto ToDto(Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublicationDate = book.PublicationDate
            };
        }

    }
}
