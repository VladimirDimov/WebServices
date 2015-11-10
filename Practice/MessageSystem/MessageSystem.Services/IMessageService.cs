namespace MessageSystem.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        ICollection<Message> Get();
    }
}
