using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jp.tamagotchi.data.Entities
{
    public class Developer : User
    {

        [Required]
        public string DeveloperKey { get; set; }
        public List<Pet> Pets { get; set; }

    }
}