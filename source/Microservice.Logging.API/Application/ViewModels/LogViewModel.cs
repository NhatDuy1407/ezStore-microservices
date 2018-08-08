using Microservice.Logging.Persistence.Model;

namespace Microservice.Logging.API.Application.ViewModels
{
    public class LogViewModel
    {
        public LogViewModel(ExceptionLog i)
        {
            this.Content=i.Content;
        }

        public LogViewModel(AuditLog i)
        {
            this.Content = i.Content;
        }

        public string Content { get; set; }
    }
}