using BullsAndCows.WcfApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BullsAndCows.WcfApi
{
    [ServiceContract]
    public interface IUsersService
    {

        [OperationContract]
        [WebGet(UriTemplate = "")]
        ICollection<UserResponseModel> GetUsersByPage(int page, int pageSize);

        [OperationContract]
        [WebGet(UriTemplate = "/{id}")]
        UserResponseModel GetUserDetail(string id);
    }
}
