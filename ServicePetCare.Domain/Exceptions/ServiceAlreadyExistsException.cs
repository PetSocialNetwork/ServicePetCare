namespace ServicePetCare.Domain.Exceptions
{
    public class ServiceAlreadyExistsException : DomainException
    {
        public ServiceAlreadyExistsException(string? message) : base(message)
        {
        }

        public ServiceAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
