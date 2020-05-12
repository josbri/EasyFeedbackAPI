using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Repositories;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IServicioRepository _servicioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IServicioRepository servicioRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _servicioRepository = servicioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentResponse> CreateAsync(Comment comment)
        {
            try
            {
                _commentRepository.Add(comment);

                var servicio = await _servicioRepository.FindFirstByConditionAsync(s => s.ID == comment.ServicioID);

                if (servicio != null)
                {
                    servicio.UpdateAverages(comment.RatingFood, comment.RatingService);
                     _servicioRepository.Update(servicio);
                }

                await _unitOfWork.CompleteAsync();

                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"There was an error creating the comment: {ex.Message}");
            }
        }
    }
}
