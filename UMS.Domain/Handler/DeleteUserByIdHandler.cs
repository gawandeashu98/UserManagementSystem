using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class DeleteUserByIdHandler
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> HandleAsync(DeleteUserByIdRequest request)
        {
            return await _userRepository.DeleteUserByIdAsync(request.UserId);
        }
    }
}
