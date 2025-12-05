using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Enums;
using ServicePetCare.Domain.Exceptions;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Services
{
    public class PetCareService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IDogWalkingServiceRepository _dogWalkingServiceRepository;
        public PetCareService(IServiceRepository serviceRepository,
            IDogWalkingServiceRepository dogWalkingServiceRepository)
        {
            _serviceRepository = serviceRepository
                ?? throw new ArgumentException(nameof(serviceRepository));
            _dogWalkingServiceRepository = dogWalkingServiceRepository
                ?? throw new ArgumentException(nameof(dogWalkingServiceRepository));
        }

        public async Task<Service> AddServiceAsync
            (Service service, CancellationToken cancellationToken)
        {
            var isExistsService = await _serviceRepository
                .CheckServiceExistsAsync(service.ServiceTypeId, service.ProfileId, cancellationToken);

            if (isExistsService)
            {
                throw new ServiceAlreadyExistsException("Нельзя добавить уже существующую услугу");
            }

            await _serviceRepository.Add(service, cancellationToken);

            switch (service.ServiceTypeId)
            {
                case var id when id == ServiceTypes.DogWalking:
                    var dogService = new DogWalking(Guid.NewGuid(), service.Id);
                    await _dogWalkingServiceRepository.Add(dogService, cancellationToken);
                    break;
            }

            return service;
        }

        public async Task UpdateServiceAsync
            (Guid id, string? description, decimal? price, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.FindServiceAsync(id, cancellationToken)
                ?? throw new ServiceNotFoundException("Услуги не существует.");

            service.Description = description;
            service.Price = price;

            await _serviceRepository.Update(service, cancellationToken);
        }

        public async Task DeleteServiceAsync
            (Guid id, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.FindServiceAsync(id, cancellationToken)
                ?? throw new ServiceNotFoundException("Услуги не существует.");

            await _serviceRepository.Delete(service, cancellationToken);
        }

        public async Task<Service> GetServiceByIdAsync
         (Guid serviceId, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetServiceByIdAsync(serviceId, cancellationToken);
        }

        public async Task<List<Service>> GetServiceByProfileIdAsync
            (Guid userId, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetServicesByProfileIdAsync(userId, cancellationToken);
        }
    }
}