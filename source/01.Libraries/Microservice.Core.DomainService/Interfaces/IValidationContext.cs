namespace Microservice.Core.DomainService.Interfaces
{
    public interface IValidationContext
    {
        void AddValidationError(string erorrMessage);

        string FormatValidationError();
    }
}
