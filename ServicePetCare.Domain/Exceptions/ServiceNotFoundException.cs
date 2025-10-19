namespace ServicePetCare.Domain.Exceptions
{
    public class ServiceNotFoundException : DomainException
    {
        public ServiceNotFoundException(string? message) : base(message)
        {
        }

        public ServiceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
