using System.Data.Entity;
using CA.Common.Auth;
using CA.Domain.Entities;
using Ninject.Modules;
using Ninject.Web.Common;
using Repository.Abstract;
using Repository.Concrete;

namespace CA.Common.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
        //    Bind<DbContext>().ToSelf().InRequestScope();
            //    Bind(typeof(GenericRepository<>)).ToSelf().InRequestScope();
            //Bind<Entities>().To<DbContext>().InRequestScope();

            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            Bind<IMessageRepository>().To<MessageRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IUserRoleRepository>().To<UserRoleRepository>();

            Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
            //Bind<IUserProvider>().To<UserProvider>();
        }
    }
}
