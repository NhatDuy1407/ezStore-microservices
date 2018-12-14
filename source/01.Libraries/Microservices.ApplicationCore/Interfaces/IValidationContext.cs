namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IValidationContext
    {
        void AddValidationError(string erorrMessage);

        string FormatValidationError();
    }
}
