namespace MmessageService
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        IEnumerable<Message> GetMessages();

        [OperationContract]
        void AddMessage(Message message);
    }
}
