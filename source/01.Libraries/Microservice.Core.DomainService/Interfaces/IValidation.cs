namespace Microservice.Core.DomainService.Interfaces
{
    public interface IValidation
    {
        bool Validate(IValidationContext validationContext);
    }
}
