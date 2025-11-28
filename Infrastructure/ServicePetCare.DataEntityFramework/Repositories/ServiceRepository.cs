using Microsoft.EntityFrameworkCore;
using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.DataEntityFramework.Repositories
{
    public class ServiceRepository : EFRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Service?> FindServiceAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<List<Service>> GetServicesByProfileIdAsync(Guid profileId, CancellationToken cancellationToken)
        {
            return await Entities.Where(p => p.ProfileId == profileId)
                .Include(s => s.ServiceType)
                .ToListAsync(cancellationToken);
        }

        public async Task<Service> GetServiceByIdAsync(Guid serviceId, CancellationToken cancellationToken)
        {
            return await Entities.Where(p => p.Id == serviceId)
                .Include(s => s.ServiceType)
                .SingleAsync();
        }

        public async Task<bool> CheckServiceExistsAsync(Guid serviceTypeId, Guid profileId, CancellationToken cancellationToken)
        {
            return await Entities
                .AnyAsync(p => p.ServiceTypeId == serviceTypeId && p.ProfileId == profileId, cancellationToken);
        }
    }
}
