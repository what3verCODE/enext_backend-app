using System.Collections.Generic;

namespace Domain.Entity.Messaging
{
    public class ChatEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ChatType Type { get; set; }
        
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}