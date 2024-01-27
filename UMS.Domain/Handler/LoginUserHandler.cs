using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class LoginUserHandler
    {
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandleAsync(LoginUserRequest request)
        {
            return await _userRepository.LoginUserAsyncAsync(request);
        }
    }
}
