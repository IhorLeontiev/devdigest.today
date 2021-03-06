using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Logging;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public interface ISettingsRepository
    {
        Task<DAL.Language> GetLanguage(string code);
    }

    public class SettingsRepository : ISettingsRepository
    {
        private readonly DatabaseContext _database;
        private ILogger _logger;

        public SettingsRepository(DatabaseContext database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public async Task<DAL.Language> GetLanguage(string code) =>
            await _database.Language.FirstOrDefaultAsync(o => o.Code == code);
    }
}