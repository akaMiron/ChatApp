using AutoMapper;
using CA.Common.ViewModels;
using CA.Domain.Entities;

namespace CA.Common.Util
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Message, MessageViewModel>();
            CreateMap<MessageViewModel, Message>();
        }

        public static void Run()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();
            });
        }
    }
}
