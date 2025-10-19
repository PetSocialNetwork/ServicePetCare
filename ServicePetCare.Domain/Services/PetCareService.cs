using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Exceptions;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Services
{
    public class PetCareService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public PetCareService(IServiceRepository serviceRepository,
            IServiceTypeRepository serviceTypeRepository)
        {
            _serviceRepository = serviceRepository
                ?? throw new ArgumentException(nameof(serviceRepository));
            _serviceTypeRepository = serviceTypeRepository
                ?? throw new ArgumentException(nameof(serviceTypeRepository));
        }

        public async Task<Service> AddServiceAsync
            (Service service, CancellationToken cancellationToken)
        {
            await _serviceRepository.Add(service, cancellationToken);
            return service;
        }

        public async Task<Service> GetServiceByIdAsync
            (Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await _serviceRepository.GetById(id, cancellationToken);
            }
            catch (InvalidOperationException)
            {
                throw new ServiceNotFoundException("Услуги не существует.");
            }
        }

        public async Task DeleteServiceAsync
            (Guid id, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.FindServiceAsync(id, cancellationToken)
                ?? throw new ServiceNotFoundException("Услуги не существует.");

            await _serviceRepository.Delete(service, cancellationToken);
        }

        public async Task<List<Service>> GetServiceByProfileIdAsync
            (Guid userId, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetServicesByProfileIdAsync(userId, cancellationToken);
        }

        public async Task<ServiceType> GetServiceTypeByIdAsync
          (Guid id, CancellationToken cancellationToken)
        {
            return await _serviceTypeRepository.GetById(id, cancellationToken);
        }

        public async Task<List<ServiceType>> GetServiceTypesAsync
            (CancellationToken cancellationToken)
        {
            return await _serviceTypeRepository.GetAll(cancellationToken);
        }
    }
}