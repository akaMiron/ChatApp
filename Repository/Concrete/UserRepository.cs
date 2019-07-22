using CA.Domain.Entities;
using Repository.Abstract;
using System;
using System.Linq;

namespace Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(Entities context) : base(context)
        {
        }

        public User Login(string name, string password)
        {
            return Entities.User.FirstOrDefault(p => string.Compare(p.Name, name, StringComparison.OrdinalIgnoreCase) == 0 
                                                           && p.Password == password);
        }

        public int GetIdByName(string name)
        {
            return Entities.User
                .FirstOrDefault(u => string.Compare(u.Name, name, StringComparison.OrdinalIgnoreCase) == 0)
                .UserId;
        }

        public Entities Entities
        {
            get { return Context as Entities; }
        }
    }
}