namespace Library.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Ganre { get; set; }
        public string? Author { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}
