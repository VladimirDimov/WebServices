namespace MmessageService
{
    using System;
    using System.Collections.Generic;

    public class MessageService : IMessageService
    {
        private ICollection<Message> messages = new List<Message>();

        public MessageService()
        {
            this.messages.Add(new Message
            {
                Text = "asd",
                User = new User { Name = "Pesho" },
                PostDate = DateTime.Now
            });
        }

        public IEnumerable<Message> GetMessages()
        {
            return this.messages;
        }

        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }
    }
}
