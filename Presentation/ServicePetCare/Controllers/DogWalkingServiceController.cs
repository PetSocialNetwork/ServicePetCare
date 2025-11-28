using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePetCare.Domain.Entities;
using ServicePetCare.Domain.Services;
using ServicePetCare.WebApi.Models.Requests;
using ServicePetCare.WebApi.Models.Responses;

namespace ServicePetCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogWalkingServiceController : ControllerBase
    {
        private readonly DogWalkingService _petWalkingService;
        private readonly IMapper _mapper;
        public DogWalkingServiceController(DogWalkingService petWalkingService,
            IMapper mapper)
        {
            _petWalkingService = petWalkingService
                ?? throw new ArgumentException(nameof(petWalkingService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Возвращает тип услуги прогулки с собаками по ее идентификатору основной услуги
        /// </summary>
        /// <param name="serviceId">Идентификатор типа услуги</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<DogWalkingServiceResponse> GetDogWalkingByServiceIdAsync
            ([FromQuery] Guid serviceId, CancellationToken cancellationToken)
        {
            var service = await _petWalkingService.GetDogWalkingByServiceId(serviceId, cancellationToken);
            return _mapper.Map<DogWalkingServiceResponse>(service);
        }

        /// <summary>
        /// Обновляет услугу прогулки с собаками
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task UpdateDogWalkingAsync
           ([FromBody] UpdateDogWalkingRequest request, CancellationToken cancellationToken)
        {
            var dogWalking = _mapper.Map<DogWalking>(request);
            await _petWalkingService.UpdateDogWalkingAsync(dogWalking, cancellationToken);
        }
    }
}
