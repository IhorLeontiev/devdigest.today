using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public interface ISocialRepository
    {
        Task<IReadOnlyCollection<FacebookPage>> GetFacebookPages(int categoryId);
        Task<IReadOnlyCollection<FacebookPage>> GetFacebookPages();
        Task<IReadOnlyCollection<Channel>> GetTelegramChannels(int categoryId);
        Task<IReadOnlyCollection<Channel>> GetTelegramChannels();
        Task<IReadOnlyCollection<TwitterAccount>> GetTwitterAccountsChannels(int categoryId);
        Task<IReadOnlyCollection<TwitterAccount>> GetTwitterAccounts();
    }

    public class SocialRepository : ISocialRepository
    {
        private readonly DatabaseContext _database;

        public SocialRepository(DatabaseContext database) => _database = database;

        public async Task<IReadOnlyCollection<FacebookPage>> GetFacebookPages(int categoryId) =>
            await _database.FacebookPage.Where(o => o.CategoryId == categoryId).ToListAsync();

        public async Task<IReadOnlyCollection<Channel>> GetTelegramChannels(int categoryId) =>
            await _database.Channel.Where(o => o.CategoryId == categoryId).ToListAsync();

        public async Task<IReadOnlyCollection<Channel>> GetTelegramChannels() =>
            await _database.Channel.ToListAsync();

        public async Task<IReadOnlyCollection<TwitterAccount>> GetTwitterAccountsChannels(int categoryId)
            => await _database.TwitterAccount.ToListAsync();

        public async Task<IReadOnlyCollection<TwitterAccount>> GetTwitterAccounts() => await _database.TwitterAccount.ToListAsync();

        public async Task<IReadOnlyCollection<FacebookPage>> GetFacebookPages() =>
            await _database.FacebookPage.ToListAsync();
    }
}