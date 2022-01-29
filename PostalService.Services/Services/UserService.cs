using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalService.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<List<UserModel>> Get()
        {
            return await _userRepository.Get();
        }

        public async Task<UserModel> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task Remove(int id)
        {
            await _userRepository.Remove(id);
        }

        public async Task Update(int id, UserModel user)
        {
            await _userRepository.Update(id, user);
        }
    }
}
