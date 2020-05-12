using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EasyFeedbackContext context) : base(context) { }

        public async Task<User> FindByCognitoId(string cognitoId)
        {
            return await _context.Set<User>().Include(u => u.UsersRestaurants)
                .ThenInclude(ur => ur.Restaurant).AsNoTracking().FirstOrDefaultAsync(u => u.CognitoID == cognitoId);
        }

    }
}
