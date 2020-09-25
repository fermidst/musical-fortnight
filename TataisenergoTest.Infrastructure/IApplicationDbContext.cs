using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TataisenergoTest.Infrastructure.Models;

namespace TataisenergoTest.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Message> Messages { get; set; }
        
        DbSet<EncryptSetting> EncryptSettings { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}