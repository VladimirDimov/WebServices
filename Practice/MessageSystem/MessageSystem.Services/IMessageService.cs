namespace MessageSystem.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web; // Needed for [WebGet]

    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        [WebGet(UriTemplate = "message/all", ResponseFormat = WebMessageFormat.Xml)]
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        ICollection<Message> Get();

        [OperationContract]
        [WebInvoke(Method = "Post")]
        void Add(Message message);
    }
}
