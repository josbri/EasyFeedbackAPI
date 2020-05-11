using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class SettingsRepository : RepositoryBase<Settings>, ISettingsRepository
    {
        public SettingsRepository(EasyFeedbackContext context) : base(context)
        {
        }
    }
}
