using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using Library.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public class BorrowerServices : BaseService<BorrowerDto, Borrower>, IServiceBorrower
    {
        public BorrowerServices(IRepositoryBorrower repository, IMapper<BorrowerDto, Borrower> mapper) : base(repository, mapper)
        {
        }


    }
}
