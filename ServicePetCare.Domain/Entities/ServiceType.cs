using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Entities
{
    public class ServiceType : IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; }
        protected ServiceType() { }
    }
}
