using ServicePetCare.Domain.Entities;

namespace ServicePetCare.Domain.Interfaces
{
    public interface IDogWalkingServiceRepository : IRepositoryEF<DogWalking>
    {
        Task<DogWalking?> FindDogWalkingAsync(Guid id, CancellationToken cancellationToken);
        Task<DogWalking> GetDogWalkingByServiceId(Guid serviceId, CancellationToken cancellationToken);
    }
}
