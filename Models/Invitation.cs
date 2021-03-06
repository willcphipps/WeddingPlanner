using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models {
    public class Invitation {
        [Key]
        public int InviteId { get; set; }
        public int UserId { get; set; }
        public int WeddingId { get; set; }
        public Wedding Event { get; set; }
        public User Attending { get; set; }
    }
}