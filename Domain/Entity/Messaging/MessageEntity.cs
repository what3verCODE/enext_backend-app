using System;

namespace Domain.Entity.Messaging
{
    public class MessageEntity
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }
        public DateTime WrittenAt { get; set; }
        public MessageStatus Status { get; set; }
        
        public UserEntity Sender { get; set; }

        public MessageEntity()
        {
            Status = MessageStatus.Sent;
        }
    }
}