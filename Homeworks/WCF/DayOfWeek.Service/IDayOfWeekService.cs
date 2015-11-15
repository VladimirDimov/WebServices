namespace DayOfWeek.Service
{
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]    
    public interface IDayOfWeekService
    {
        [OperationContract]
        [WebGet]
        string Today();     
    }
}
