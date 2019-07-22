
namespace CA.Common.Mapper
{
    public static class MapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.AddProfile<CommonMapper>();
            });
        }
    }
}
