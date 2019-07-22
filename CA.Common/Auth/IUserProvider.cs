using CA.Domain.Entities;

namespace CA.Common.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
