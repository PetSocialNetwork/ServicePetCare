using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Entities
{
    public class DogWalking : ServiceBase, IEntity
    {
        public Guid Id { get; init; }
        public Guid ServiceId { get; set; }
        public int? MaxDogs { get; set; }              
        public int? WalkDurationMinutes { get; set; }
        public Service Service { get; set; }
        public DogWalking(Guid id, Guid serviceId)
        {
            Id = id;
            ServiceId = serviceId;
        }
        protected DogWalking() { }
    }
}
