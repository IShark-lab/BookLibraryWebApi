using Library.DataAccess.EF;
using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class LoanRepository : Repository<Loan>, IRepositoryLoan
    {
        public LoanRepository(LibraryContext context) : base(context) { }

    }
}
