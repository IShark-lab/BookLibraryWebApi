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
    public class BorrowerMapper : IMapper<BorrowerDto, Borrower>
    {
        public BorrowerDto ToDto(Borrower entity)
        {
            return new BorrowerDto
            {
                FullName = entity.FullName,
                Email = entity.Email
            };
        }

        public BorrowerDto ToDtoWithId(Borrower entity)
        {
            return new BorrowerDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email
            };
        }

        public Borrower ToEntity(BorrowerDto entity)
        {
            return new Borrower
            {
                FullName = entity.FullName,
                Email = entity.Email
            };
        }

        public Borrower ToEntityWithId(BorrowerDto entityDto)
        {
            return new Borrower
            {
                Id = entityDto.Id,
                FullName = entityDto.FullName,
                Email = entityDto.Email
            };
        }
    }
}
