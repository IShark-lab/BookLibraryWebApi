using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Ganre { get; set; }
        public string? Author { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}
