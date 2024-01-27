using AutoMapper;
using UMS.Messages.Entities;
using UMS.Messages.Requests;

namespace UMS.Domain.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserByIdRequest, User>();
        }
    }
}
