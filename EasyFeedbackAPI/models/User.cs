using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string CognitoID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
#nullable enable
        public List<UsersRestaurants>? UsersRestaurants { get; set; }
#nullable disable    
        public bool Admin { get; set; }

        public User() { }

    }
}
