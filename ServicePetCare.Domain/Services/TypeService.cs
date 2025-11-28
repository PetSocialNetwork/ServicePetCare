using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.Domain.Services
{
    public class TypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public TypeService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository
                ?? throw new ArgumentException(nameof(serviceTypeRepository));
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
