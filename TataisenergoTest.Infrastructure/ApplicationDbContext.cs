using Microsoft.EntityFrameworkCore;
using TataisenergoTest.Infrastructure.Models;

namespace TataisenergoTest.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>(builder =>
            {
                builder.ToTable("Messages");
                builder.HasKey(m => m.MessageId);
                builder.Property(m => m.MessageId).HasColumnName("id");
                builder.Property(m => m.Content).HasColumnName("content");
                builder.Property(m => m.CreatedAt).HasColumnName("created_at");
            });
            modelBuilder.Entity<EncryptSetting>(builder =>
            {
                builder.ToTable("Encrypt_Settings");
                builder.HasNoKey();
                builder.Property(s => s.OldValue).HasColumnName("old_value");
                builder.Property(s => s.NewValue).HasColumnName("new_value");
            });
        }

        public DbSet<Message> Messages { get; set; }
        
        public DbSet<EncryptSetting> EncryptSettings { get; set; }
    }
}