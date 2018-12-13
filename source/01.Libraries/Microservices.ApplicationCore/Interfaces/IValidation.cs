namespace Microservices.ApplicationCore.Interfaces
{
    public interface IValidation
    {
        bool Validate(IValidationContext validationContext);
    }
}
