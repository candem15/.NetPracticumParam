using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4.Odev8.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GenreTitle { get; set; }
    }
}
