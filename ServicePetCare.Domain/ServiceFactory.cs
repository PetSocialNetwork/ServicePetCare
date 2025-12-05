using ServicePetCare.Domain.Entities;

namespace ServicePetCare.Domain
{
    public class ServiceFactory : IServiceFactory
    {
        public ServiceBase CreateService(Guid id, Guid serviceId)
        {
            //не нравится что тут пишем конкретный тип
            return new DogWalking(id, serviceId);
        }
    }
}

public interface IServiceFactory
{
    public ServiceBase CreateService(Guid id, Guid serviceId);
}


public class DogWalkingFactory : IServiceFactory
{
    //что тут возвращается ServiceBase а не весь продукт
    public ServiceBase CreateService(Guid id, Guid serviceId)
    {
        return new DogWalking(id, serviceId);
    }
}

//доделать провайдера
