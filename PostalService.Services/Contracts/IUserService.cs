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
        Task Update(UserModel user);
        Task Remove(UserModel user);
    }
}
