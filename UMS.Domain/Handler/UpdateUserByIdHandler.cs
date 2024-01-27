﻿using AutoMapper;
using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.Repositories;

namespace UMS.Domain.Handler
{
    public class UpdateUserByIdHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserByIdHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int?> HandleAsync(UpdateUserByIdRequest request)
        {
            var userToUpdate = _mapper.Map<User>(request);
            return await _userRepository.UpdateUserByIdAsync(userToUpdate);
        }
    }
}
