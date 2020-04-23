using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models {
    public class Wedding {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        public string Bride { get; set; }

        [Required]

        public string Groom { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [FutureDate]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<User> RSVPs { get; set; }

    }
}