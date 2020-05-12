using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public interface ICommentService
    {
        Task<CommentResponse> CreateAsync(Comment comment);
    }
}
