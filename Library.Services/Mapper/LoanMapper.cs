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
    public class LoanMapper : IMapper<LoanDto, Loan>
    {
        public LoanDto ToDto(Loan entity)
        {
            return new LoanDto
            {
                BookId = entity.BookId,
                BorrowerId = entity.BorrowerId,
                LoanDate = entity.LoanDate,
                ReturnDate = entity.ReturnDate
            };
        }

        public LoanDto ToDtoWithId(Loan entity)
        {
            return new LoanDto
            {
                Id = entity.Id,
                BookId = entity.BookId,
                BorrowerId = entity.BorrowerId,
                LoanDate = entity.LoanDate,
                ReturnDate = entity.ReturnDate
            };
        }

        public Loan ToEntity(LoanDto entityDto)
        {
            return new Loan
            {
                BookId = entityDto.BookId,
                BorrowerId = entityDto.BorrowerId,
                LoanDate = entityDto.LoanDate,
                ReturnDate = entityDto.ReturnDate
            };
        }

        public Loan ToEntityWithId(LoanDto entityDto)
        {
            return new Loan
            {
                Id = entityDto.Id,
                BookId = entityDto.BookId,
                BorrowerId = entityDto.BorrowerId,
                LoanDate = entityDto.LoanDate,
                ReturnDate = entityDto.ReturnDate
            };
        }

    }
}
