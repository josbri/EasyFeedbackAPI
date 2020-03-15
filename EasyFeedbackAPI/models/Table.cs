using System;
using System.Collections.Generic;

namespace EasyFeedbackAPI.models
{
    public class Table
    {
        public int ID  { get; set; }
        public int ComensalesNum { get; set; }
        public int? NumMesa { get; set; }


        public ICollection<Comment> CommentsList { get; set; }

        public Table()
        {
        }
    }
}
