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
        private readonly ApplicationContext _context;

        public MessageService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> EncryptMessage(string content)
        {
            var encryptPairs =
                await _context.EncryptSettings.ToDictionaryAsync(setting => setting.OldValue,
                    setting => setting.NewValue);

            // case-sensitive encryption, please, provide encrypt settings for all cases of letter
            var encryptedChars = content.Select(c => encryptPairs.ContainsKey(c) ? encryptPairs[c] : c);
            var result = string.Concat(encryptedChars);

            _context.Messages.Add(new Message
            {
                Content = content, CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            return result;
        }
    }
}