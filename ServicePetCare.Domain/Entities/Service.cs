using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Entities
{
    public class Service : IEntity
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; init; }
        public ServiceType ServiceType { get; set; }
        protected Service() { }
    }
}
