using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Exceptions;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Services
{
    public class DogWalkingService
    {
        private readonly IDogWalkingServiceRepository _dogWalkingServiceRepository;
        public DogWalkingService(IDogWalkingServiceRepository dogWalkingServiceRepository)
        {
            _dogWalkingServiceRepository = dogWalkingServiceRepository
                ?? throw new ArgumentException(nameof(dogWalkingServiceRepository));
        }

        public async Task<DogWalking> GetDogWalkingByServiceId
            (Guid serviceId, CancellationToken cancellationToken)
        {
            return await _dogWalkingServiceRepository
                .GetDogWalkingByServiceId(serviceId, cancellationToken);
        }

        public async Task UpdateDogWalkingAsync
           (DogWalking dogWalking, CancellationToken cancellationToken)
        {
            var existedDogWalking = await _dogWalkingServiceRepository.FindDogWalkingAsync(dogWalking.Id, cancellationToken)
                ?? throw new ServiceNotFoundException("Услуги не существует.");

            existedDogWalking.WalkDurationMinutes = dogWalking.WalkDurationMinutes;
            existedDogWalking.MaxDogs = dogWalking.MaxDogs;

            await _dogWalkingServiceRepository.Update(existedDogWalking, cancellationToken);
        }
    }
}
