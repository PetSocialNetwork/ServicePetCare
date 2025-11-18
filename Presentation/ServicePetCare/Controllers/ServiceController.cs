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
        private readonly PetCareService _petCareService;
        private readonly IMapper _mapper;
        public ServiceController(PetCareService petCareService, 
            IMapper mapper)
        {
            _petCareService = petCareService
                ?? throw new ArgumentException(nameof(petCareService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
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
            var pet = await _petCareService.AddServiceAsync(service, cancellationToken);     
            return _mapper.Map<ServiceResponse>(pet);
        }

        /// <summary>
        /// Возвращает услугу по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор услуги</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ServiceResponse> GetServiceByIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var petProfile = await _petCareService.GetServiceByIdAsync(id, cancellationToken);
            return _mapper.Map<ServiceResponse>(petProfile);
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
            var petProfiles = await _petCareService.GetServiceByProfileIdAsync(profileId, cancellationToken);
            return _mapper.Map<List<ServiceResponse>>(petProfiles);
        }

        /// <summary>
        /// Возвращает тип услуги по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа услуги</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ServiceTypeResponse> GetServiceTypeByIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var petProfile = await _petCareService.GetServiceTypeByIdAsync(id, cancellationToken);
            return _mapper.Map<ServiceTypeResponse>(petProfile);
        }

        /// <summary>
        /// Возвращает все типы услуг
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<ServiceTypeResponse>> GetServiceTypesAsync
            (CancellationToken cancellationToken)
        {
            var petProfiles = await _petCareService.GetServiceTypesAsync(cancellationToken);
            return _mapper.Map<List<ServiceTypeResponse>>(petProfiles);
        }
    }
}
