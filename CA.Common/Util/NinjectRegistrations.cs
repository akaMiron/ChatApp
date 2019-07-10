
using Ninject.Modules;
using Repository.Abstract;
using Repository.Concrete;

namespace CA.Common.Util
{
    public class NinjectRegistrations : NinjectModule

    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            Bind<IMessageRepository>().To<MessageRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
