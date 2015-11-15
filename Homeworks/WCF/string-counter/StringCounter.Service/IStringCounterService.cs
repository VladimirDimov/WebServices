namespace StringCounter.Service
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IStringCounterService
    {
        [OperationContract]
        [WebInvoke(Method = "Get")]
        int Count(string text, string requestedString);
    }
}
