using System.ComponentModel.DataAnnotations.Schema;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
