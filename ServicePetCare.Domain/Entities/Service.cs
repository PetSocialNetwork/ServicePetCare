using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Entities
{
    public class Service : IEntity
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; init; }
        public Guid ServiceTypeId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public ServiceType ServiceType { get; set; }
        public DogWalking DogWalkingService { get; set; }
    }
}
