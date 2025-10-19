using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Interfaces;

namespace ServicePetCare.DataEntityFramework.Repositories
{
    public class ServiceTypeRepository : EFRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
