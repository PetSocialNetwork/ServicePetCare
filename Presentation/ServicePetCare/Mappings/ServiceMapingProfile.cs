using AutoMapper;
using ServicePetCare.Domain.Entities;
using ServicePetCare.WebApi.Models.Requests;
using ServicePetCare.WebApi.Models.Responses;

namespace ServicePetCare.WebApi.Mappings
{
    public class ServiceMapingProfile : Profile
    {
        public ServiceMapingProfile()
        {
            CreateMap<AddServiceRequest, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(src => src.ProfileId))
                .ForMember(dest => dest.ServiceTypeId, opt => opt.MapFrom(src => src.ServiceTypeId));

            CreateMap<Service, ServiceResponse>()
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType));
            CreateMap<ServiceType, ServiceTypeResponse>();
        }
    }
}
