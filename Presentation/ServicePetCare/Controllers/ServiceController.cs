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
    public class ServiceController : ControllerBase
    {
        private readonly TypeService _typeService;
        private readonly PetCareService _petCareService;
        private readonly IMapper _mapper;
        public ServiceController(PetCareService petCareService,
            TypeService typeService,
            IMapper mapper)
        {
            _petCareService = petCareService
                ?? throw new ArgumentException(nameof(petCareService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _typeService = typeService
                ?? throw new ArgumentNullException(nameof(typeService));
        }

        /// <summary>
        /// Добавляет услугу для пользователя
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ServiceResponse> AddServiceAsync
            ([FromBody] AddServiceRequest request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request);
            var serviceType = await _typeService.GetServiceTypeByIdAsync(request.ServiceTypeId, cancellationToken);
            service.ServiceType = serviceType;
            var pet = await _petCareService.AddServiceAsync(service, cancellationToken);     
            return _mapper.Map<ServiceResponse>(pet);
        }

        /// <summary>
        /// Добавляет услугу для пользователя
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task UpdateServiceAsync
            ([FromBody] UpdateServiceRequest request, CancellationToken cancellationToken)
        {
            await _petCareService.UpdateServiceAsync
                (request.Id, request.Description, request.Price, cancellationToken);
        }

        /// <summary>
        /// Удаляет услушу по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор услуги</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task DeleteServiceAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _petCareService.DeleteServiceAsync(id, cancellationToken);
        }

        /// <summary>
        /// Возвращает услуги по идентификатору 
        /// </summary>
        /// <param name="serviceId">Идентификатор услуги</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ServiceResponse> GetServiceByIdAsync
            ([FromQuery] Guid serviceId, CancellationToken cancellationToken)
        {
            var service = await _petCareService.GetServiceByIdAsync(serviceId, cancellationToken);
            return _mapper.Map<ServiceResponse>(service);
        }

        /// <summary>
        /// Возвращает все услуги по идентификатору пользователя
        /// </summary>
        /// <param name="profileId">Идентификатор профиля пользователя</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<ServiceResponse>> GetServiceByProfileIdAsync
            ([FromBody] Guid profileId, CancellationToken cancellationToken)
        {
            var services = await _petCareService.GetServiceByProfileIdAsync(profileId, cancellationToken);
            return _mapper.Map<List<ServiceResponse>>(services);
        }
    }
}
