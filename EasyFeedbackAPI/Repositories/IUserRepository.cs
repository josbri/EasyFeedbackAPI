using EasyFeedbackAPI.models;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public  interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> FindByCognitoId(string cognitoId);
    }
}