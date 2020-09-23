using Microsoft.EntityFrameworkCore;
using TataisenergoTest.Infrastructure.Models;

namespace TataisenergoTest.Infrastructure
{
    public interface IApplicationContext
    {
        DbSet<Message> Messages { get; set; }
        
        DbSet<EncryptSetting> EncryptSettings { get; set; }
    }
}