using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Repositories;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService(IServicioRepository servicioRepository, IUnitOfWork unitOfWork)
        {
            _servicioRepository = servicioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Servicio>> FindByRestaurantIdAsync(int id)
        {
            return await _servicioRepository.FindByRestaurantId(id);
        }
        public async Task<ServicioResponse> CreateAsync(Servicio servicio)
        {
            try
            {
                _servicioRepository.Add(servicio);
                await _unitOfWork.CompleteAsync();

                return new ServicioResponse(servicio);
            }
            catch (Exception ex)
            {
                return new ServicioResponse($"There was an error creating the service: {ex.Message}");
            }
        }

        public async Task<ServicioResponse> DeleteAsync(int id)
        {
            var existingServicio = await _servicioRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingServicio == null)
            {
                return new ServicioResponse("User not found");
            }
            try
            {
                _servicioRepository.Remove(existingServicio);
                await _unitOfWork.CompleteAsync();

                return new ServicioResponse(existingServicio);
            }
            catch (Exception ex)
            {
                return new ServicioResponse($"An error occurred when deleting the servicio: {ex.Message}");
            }

        }


        public async Task<ServicioResponse> UpdateAsync(int id, Servicio servicio)
        {
            var existingServicio = await _servicioRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingServicio == null)
            {
                return new ServicioResponse("Servicio not found");
            }

            existingServicio = servicio;

            try
            {
                _servicioRepository.Update(existingServicio);
                await _unitOfWork.CompleteAsync();

                return new ServicioResponse(existingServicio);
            }
            catch (Exception ex)
            {
                return new ServicioResponse($"An error occurred when updating the servicio: {ex.Message}");
            }

        }
    }
}
