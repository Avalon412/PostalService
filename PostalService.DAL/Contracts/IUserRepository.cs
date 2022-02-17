using System.Collections.Generic;
using System.Threading.Tasks;
using PostalService.DAL.Models;

namespace PostalService.DAL.Contracts
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Get();
        Task<UserModel> Get(int id);
        Task<UserModel> Create(UserModel user);
        Task Update(UserModel user);
        Task Remove(UserModel user);
    }
}
