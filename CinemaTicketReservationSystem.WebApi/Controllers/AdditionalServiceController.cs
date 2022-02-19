using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ManagerRole")]
    [ApiController]
    public class AdditionalServiceController : ControllerBase
    {
        private readonly IAdditionalServiceManagement _additionalServiceManagement;
        private readonly IMapper _mapper;

        public AdditionalServiceController(
            IAdditionalServiceManagement additionalServiceManagement,
            IMapper mapper)
        {
            _additionalServiceManagement = additionalServiceManagement;
            _mapper = mapper;
        }

        [HttpPost("{cinemaId}")]
        public async Task<IActionResult> AddAdditionalService(
            [FromRoute] AddAdditionalServiceRequestWrapper addAdditionalServiceRequestWrapper)
        {
            var additionalServiceResult = await _additionalServiceManagement.AddAdditionalService(
                addAdditionalServiceRequestWrapper.CinemaId,
                _mapper.Map<AdditionalServiceModel>(addAdditionalServiceRequestWrapper.AdditionalServiceRequest));

            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
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
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
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
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}/cinema")]
        public async Task<IActionResult> GetAdditionalServicesByCinemaId(
            [FromRoute] CinemaRequestWrapper cinemaRequestWrapper)
        {
            var servicesResult =
                await _additionalServiceManagement.GetAdditionalServicesByCinemaId(cinemaRequestWrapper.Id);
            var response = _mapper.Map<AdditionalServiceGetAllResponse>(servicesResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}