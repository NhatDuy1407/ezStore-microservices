using RKSystem.Service.Core;

namespace RKSystem.UserService.WriteSide
{
    public class UserServiceManager : ServiceManager
    {
        public override int Start()
        {
            return (int)HostFactory.Run(x => x.Service<UserRequestService>());
        }
    }
}
