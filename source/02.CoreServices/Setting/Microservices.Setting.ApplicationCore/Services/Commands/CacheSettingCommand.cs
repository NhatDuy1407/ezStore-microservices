using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.Setting.ApplicationCore.Services.Commands
{
    public class CacheSettingCommand : ICommand
    {
        public bool Validate(IValidationContext validationContext)
        {
            return true;
        }
    }
}
