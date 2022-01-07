using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class AdditionalServiceController : ControllerBase
    {
        private readonly IAdditionalServiceManagement _additionalServiceManagement;
        private readonly IMapper _mapper;
        private readonly ILogger<AdditionalServiceController> _logger;

        public AdditionalServiceController(
            IAdditionalServiceManagement additionalServiceManagement,
            IMapper mapper,
            ILogger<AdditionalServiceController> logger)
        {
            _additionalServiceManagement = additionalServiceManagement;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalService(
            [FromRoute] AddAdditionalServiceRequestWrapper addAdditionalServiceRequestWrapper)
        {
            var additionalServiceResult = await _additionalServiceManagement.AddAdditionalService(
                addAdditionalServiceRequestWrapper.CinemaId,
                _mapper.Map<AdditionalServiceModel>(addAdditionalServiceRequestWrapper.AdditionalServiceRequest));

            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdditionalService(
            [FromRoute] UpdateAdditionalServiceRequestWrapper updateAdditionalServiceRequestWrapper)
        {
            var additionalServiceResult = await _additionalServiceManagement.UpdateAdditionalService(
                updateAdditionalServiceRequestWrapper.Id,
                _mapper.Map<AdditionalServiceModel>(updateAdditionalServiceRequestWrapper.AdditionalServiceRequest));

            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAdditionalService(
            [FromRoute] AdditionalServiceRequestWrapper additionalServiceRequestWrapper)
        {
            var additionalServiceResult =
                await _additionalServiceManagement.RemoveAdditionalService(additionalServiceRequestWrapper.Id);
            var response = _mapper.Map<AdditionalServiceRemoveResponse>(additionalServiceResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdditionalServiceById(
            [FromRoute] AdditionalServiceRequestWrapper additionalServiceRequestWrapper)
        {
            var additionalServiceResult =
                await _additionalServiceManagement.GetAdditionalServiceById(additionalServiceRequestWrapper.Id);
            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdditionalServices()
        {
            var additionalServicesResult = await _additionalServiceManagement.GetAdditionalServices();
            var response = _mapper.Map<AdditionalServiceGetAllResponse>(additionalServicesResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}