using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TataisenergoTest.Infrastructure;
using TataisenergoTest.Infrastructure.Models;

namespace TataisenergoTest.Web.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(ApplicationContext context, ILogger<MessageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> EncryptMessage(string content)
        {
            var encryptPairs =
                _context.EncryptSettings.ToDictionary(setting => setting.OldValue, setting => setting.NewValue);

            var result = new StringBuilder(content);
            
            // todo: probably should be refactored, high cyclomatic complexity
            for (var i = 0; i < result.Length; i++)
            {
                if (char.IsUpper(result[i]))
                {
                    if (encryptPairs.TryGetValue(char.ToLower(result[i]), out var newValue))
                    {
                        result[i] = char.ToUpper(newValue);
                    }
                    else
                    {
                        _logger.LogError($"there is no new value for old value: {result[i]}");
                    }
                }
                else
                {
                    if (encryptPairs.TryGetValue(char.ToLower(result[i]), out var newValue))
                    {
                        result[i] = newValue;
                    }
                    else
                    {
                        _logger.LogError($"there is no new value for old value: {result[i]}");
                    }
                }
            }

            _context.Messages.Add(new Message
            {
                Content = content, CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            return result.ToString();
        }
    }
}