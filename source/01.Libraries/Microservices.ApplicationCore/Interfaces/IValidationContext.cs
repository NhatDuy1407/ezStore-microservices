namespace Microservices.ApplicationCore.Interfaces
{
    public interface IValidationContext
    {
        void AddValidationError(string erorrMessage);

        string FormatValidationError();
    }
}
