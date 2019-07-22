using CA.Domain.Entities;

namespace Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string email, string password);

        int GetIdByName(string name);
    }
}
