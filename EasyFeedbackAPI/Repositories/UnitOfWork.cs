using EasyFeedbackAPI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Class created to avoid data inconsistency. All the Add, Remove and Update functions will use this same UoW.

        private readonly EasyFeedbackContext _context;

        public UnitOfWork(EasyFeedbackContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
