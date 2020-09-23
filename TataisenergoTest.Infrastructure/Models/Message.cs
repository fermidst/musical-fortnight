using System;

namespace TataisenergoTest.Infrastructure.Models
{
    public class Message
    {
        public long MessageId { get; set; }

        public string Content { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}