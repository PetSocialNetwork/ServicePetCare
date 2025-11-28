using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePetCare.Domain.Services;
using ServicePetCare.WebApi.Models.Responses;

namespace ServicePetCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly TypeService _typeService;
        private readonly IMapper _mapper;
        public ServiceTypeController(TypeService typeService,
            IMapper mapper)
        {
            _typeService = typeService
                ?? throw new ArgumentException(nameof(typeService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
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
            var petProfile = await _typeService.GetServiceTypeByIdAsync(id, cancellationToken);
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
            var petProfiles = await _typeService.GetServiceTypesAsync(cancellationToken);
            return _mapper.Map<List<ServiceTypeResponse>>(petProfiles);
        }
    }
}
