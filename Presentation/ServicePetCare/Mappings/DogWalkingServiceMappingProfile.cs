using AutoMapper;
using ServicePetCare.Domain.Entities;
using ServicePetCare.WebApi.Models.Requests;
using ServicePetCare.WebApi.Models.Responses;

namespace ServicePetCare.WebApi.Mappings
{
    public class DogWalkingServiceMappingProfile : Profile
    {
        public DogWalkingServiceMappingProfile()
        {
            CreateMap<DogWalking, DogWalkingServiceResponse>();
            CreateMap<UpdateDogWalkingRequest, DogWalking>();
        }
    }
}
