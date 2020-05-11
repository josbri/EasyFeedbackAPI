using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services.Communication
{
    public class CommentResponse : BaseResponse
    {
        public Comment Comment { get; private set; }

        private CommentResponse(bool success, string message, Comment comment) : base(success, message)
        {
            Comment = comment;
        }

        public CommentResponse(Comment comment) : this(true, string.Empty, comment) { }

        public CommentResponse(string message) : this(false, message, null) { }
    }
}
