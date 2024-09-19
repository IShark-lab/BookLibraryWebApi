using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }


        public int BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public Borrower Borrower { get; set; }


        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
