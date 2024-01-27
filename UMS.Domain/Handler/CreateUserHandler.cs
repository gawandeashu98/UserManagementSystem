using AutoMapper;
using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> HandleAsync(CreateUserRequest request)
        {
            var newUser = _mapper.Map<User>(request);
            return await _userRepository.CreateUserAsync(newUser);
        }
    }
}
