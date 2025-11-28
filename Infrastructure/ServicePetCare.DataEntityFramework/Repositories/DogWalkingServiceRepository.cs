using Microsoft.EntityFrameworkCore;
using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.DataEntityFramework.Repositories
{
    public class DogWalkingServiceRepository : EFRepository<DogWalking>, IDogWalkingServiceRepository
    {
        public DogWalkingServiceRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<DogWalking?> FindDogWalkingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<DogWalking> GetDogWalkingByServiceId(Guid serviceId, CancellationToken cancellationToken)
        { 
            return await Entities.SingleAsync(it => it.ServiceId == serviceId, cancellationToken);
        }
    }
}
