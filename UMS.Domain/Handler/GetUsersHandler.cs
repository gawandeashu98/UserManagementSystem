using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class GetUsersHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> HandleAsync(GetUsersRequest request)
        {
            return await _userRepository.GetUsersAsync(request);
        }
    }
}
