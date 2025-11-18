using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Entities
{
    public class Service : IEntity
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; init; }
        public Guid ServiceTypeId { get; set; } // Храним только ID
        public ServiceType ServiceType { get; set; }
        protected Service() { }
    }
}
