using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TataisenergoTest.Infrastructure;
using TataisenergoTest.Infrastructure.Models;

namespace TataisenergoTest.Web.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> EncryptMessage(string content)
        {
            var encryptPairs =
                await _dbContext.EncryptSettings.ToDictionaryAsync(setting => setting.OldValue,
                    setting => setting.NewValue);

            // case-sensitive encryption, please, provide encrypt settings for all cases of letter
            var encryptedChars = content.Select(c => encryptPairs.ContainsKey(c) ? encryptPairs[c] : c);
            var result = string.Concat(encryptedChars);

            _dbContext.Messages.Add(new Message
            {
                Content = content, CreatedAt = DateTime.UtcNow
            });
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}