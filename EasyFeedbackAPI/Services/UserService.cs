using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Repositories;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> FindByCognitoIdAsync(string cognitoId)
        {
            return await _userRepository.FindFirstByConditionAsync(u => u.CognitoID == cognitoId);
        }

        public async Task<UserResponse> CreateAsync(User user)
        {
            try
            {
                _userRepository.Add(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"There was an error creating the client: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingUser == null)
            {
                return new UserResponse("User not found");
            }
            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
            }
        }

     
        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingUser == null)
            {
                return new UserResponse("User not found");
            }

            existingUser = user;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch(Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}
