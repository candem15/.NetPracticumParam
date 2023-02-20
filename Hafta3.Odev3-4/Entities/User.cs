﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta3.Odev3_4.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}
