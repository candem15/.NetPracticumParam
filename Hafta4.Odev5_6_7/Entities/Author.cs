using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4.Odev5_6_7.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
