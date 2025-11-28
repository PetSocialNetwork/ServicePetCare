using ServicePetCare.Domain.Entities;

namespace ServicePetCare.Domain.Interfaces
{
    public interface IServiceRepository : IRepositoryEF<Service>
    {
        Task<Service?> FindServiceAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Service>> GetServicesByProfileIdAsync(Guid profileId, CancellationToken cancellationToken);
        Task<Service> GetServiceByIdAsync(Guid serviceId, CancellationToken cancellationToken);
        Task<bool> CheckServiceExistsAsync(Guid serviceTypeId, Guid profileId, CancellationToken cancellationToken);
    }
}
