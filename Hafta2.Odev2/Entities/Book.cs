using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta2.Odev2.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
