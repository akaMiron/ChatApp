using AutoMapper;
using CA.Common.ViewModels;
using CA.Domain.Entities;

namespace CA.Common.Mapper
{
    public class CommonMapper : Profile
    {

        public CommonMapper()
        {
            CreateMap<User, UserView>();
            CreateMap<UserView, User>();

            CreateMap<MessageView, Message>().ForMember(dest => dest.Message1, opt => opt.MapFrom(src => src.Message));
            CreateMap<Message, MessageView>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message1));

        }
    }
}
