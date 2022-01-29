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
        Task Update(int id, UserModel user);
        Task Remove(int id);
    }
}
