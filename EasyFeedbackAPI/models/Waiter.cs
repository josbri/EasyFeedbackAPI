using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFeedbackAPI.models
{
    public class Waiter
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } = "";
        public int RestauranteID { get; set; }
        public Restaurant Restaurante { get; set; }


#nullable disable
        public Waiter()
        {
        }
    }
}
