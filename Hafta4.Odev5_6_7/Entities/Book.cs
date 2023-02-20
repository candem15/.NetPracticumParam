using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4.Odev5_6_7.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
