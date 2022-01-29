using PostalService.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalService.Services.Contracts
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
