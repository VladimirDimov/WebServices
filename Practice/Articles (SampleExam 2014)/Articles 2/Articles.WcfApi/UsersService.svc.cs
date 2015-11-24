using Articles.Data;
using Articles.Data.Repositories;
using Articles.Models;
using Articles.WcfApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Articles.WcfApi
{
    public class UsersService : IUsersService
    {
        private IRepository<User> usersRepo;

        public UsersService()
        {
            this.usersRepo = new GenericRepository<User>(new ArticlesDbContext());
        }

        public UserResponseModel GetUserDetail(string id)
        {
            var user = this.usersRepo.All()
                .FirstOrDefault(u => u.Id == id);

            return new UserResponseModel
            {
                Id = user.Id,
                Username = user.UserName
            };
        }

        public ICollection<UserResponseModel> GetUsersByPage(int page, int pageSize = 10)
        {
            var users = this.usersRepo.All()
                .Select(UserResponseModel.FromModel).ToList()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList<UserResponseModel>();

            return users;
        }
    }
}
