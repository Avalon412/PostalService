using PostalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Contracts
{
    public interface IUserService
    {
        Task<List<UserModel>> Get();
        Task<UserModel> Get(int id);
        Task<UserModel> Create(UserModel user);
        Task Update(int id, UserModel user);
        Task Remove(int id);
    }
}
