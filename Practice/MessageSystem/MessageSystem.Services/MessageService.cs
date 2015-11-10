namespace MessageSystem.Services
{
    using System;
    using System.Collections.Generic;

    public class MessageService : IMessageService
    {
        public ICollection<Message> Get()
        {
            return new List<Message>()
            {
                new Message{Text = "Some text one", DateSend = DateTime.Now},
                new Message{Text = "Some text two", DateSend = DateTime.Now},
                new Message{Text = "Some text three", DateSend = DateTime.Now}
            };
        }


        public void Add(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
