using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}