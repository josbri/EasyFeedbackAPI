using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class Settings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public Restaurant Restaurant { get; set; }

        public int PassRetorno { get; set; } = 0000;

        public int LicencesUsed { get; set; } = 0;
#nullable enable
        public int? LicensesLeft { get; set; }
#nullable disable
        public Settings() { }

    }
}
