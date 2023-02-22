using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4.Odev8.Entities
{
    public class ActorActress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
