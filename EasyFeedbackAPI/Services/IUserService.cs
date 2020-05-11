using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public interface IUserService 
    {

        Task<User> FindByCognitoIdAsync(string cognitoId);
        Task<UserResponse> CreateAsync(User user);

        Task<UserResponse> UpdateAsync(int id, User user);

        Task<UserResponse> DeleteAsync(int id);
    }
}
