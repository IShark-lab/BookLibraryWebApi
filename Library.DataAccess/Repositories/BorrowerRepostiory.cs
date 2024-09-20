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
    public class BorrowerRepostiory : Repository<Borrower>, IRepositoryBorrower
    {
        public BorrowerRepostiory(LibraryContext libraryContext) : base(libraryContext) 
        {
            
        }

        
    }
}
