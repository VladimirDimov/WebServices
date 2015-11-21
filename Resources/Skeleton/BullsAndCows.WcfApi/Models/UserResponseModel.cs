using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WcfApi.Models
{
    public class UserResponseModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public static Expression<Func<User, UserResponseModel>> FromModel
        {
            get
            {
                return user => new UserResponseModel
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
        }

    }
}