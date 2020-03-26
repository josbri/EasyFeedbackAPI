using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFeedbackAPI.models
{
    public class Restaurant
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }
        public int Tables { get; set; }
        public ICollection<Waiter> Waiters { get; set; }

#nullable disable
        public Restaurant()
        {
        }
    }
}
