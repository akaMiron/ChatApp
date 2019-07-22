using CA.Domain.Entities;
using Repository.Abstract;
using System.Data.Entity;

namespace Repository.Concrete
{
    class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}
