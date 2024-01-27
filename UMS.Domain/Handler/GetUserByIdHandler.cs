using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class GetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandleAsync(GetUserByIdRequest request)
        {
            return await _userRepository.GetUserByIdAsync(request.UserId);
        }
    }
}
