using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFeedbackAPI.models
{
    public class Table
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID  { get; set; }
        public int ComensalesNum { get; set; }
        public int? NumMesa { get; set; }


        public ICollection<Comment> CommentsList { get; set; }

#nullable disable
        public Table()
        {
        }
    }
}
