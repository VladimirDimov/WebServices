namespace DayOfWeek.Service
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web; // Needed for [WebGet]

    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        [WebGet]
        string Today();        
    }
}
