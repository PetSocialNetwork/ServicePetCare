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
            return await Entities.Where(p => p.ProfileId == profileId).ToListAsync(cancellationToken);
        }
    }
}
