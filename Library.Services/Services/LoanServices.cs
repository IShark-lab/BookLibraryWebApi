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
    public class LoanServices : BaseService<LoanDto, Loan>, IServiceLoan
    {
        public LoanServices(IRepositoryLoan repository, IMapper<LoanDto, Loan> mapper) : base(repository, mapper) { }

    }
}
