namespace Hafta4.Odev5_6_7.Dtos.BookOperations
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
}
