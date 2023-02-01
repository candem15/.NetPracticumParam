using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta1.Odev1.RestfulApi.Entities
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
