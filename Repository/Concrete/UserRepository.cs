using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Domain.Entities;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Entities context) : base(context)
        {
        }

        public Entities Entities
        {
            get { return Context as Entities; }

        }
    }
}
