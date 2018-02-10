using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jp.tamagotchi.data.Entities
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

    }
}