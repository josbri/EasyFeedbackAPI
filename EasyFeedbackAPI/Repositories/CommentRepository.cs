using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(EasyFeedbackContext context) : base(context)
        {
        }
    }
}
