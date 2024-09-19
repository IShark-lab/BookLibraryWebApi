using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
