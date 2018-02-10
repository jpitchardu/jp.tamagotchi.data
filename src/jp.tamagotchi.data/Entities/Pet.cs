using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jp.tamagotchi.data.Entities {
    public class Pet {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Package { get; set; }

        [Required]
        public Developer Developer { get; set; }

    }
}