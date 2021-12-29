using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class AdditionalServiceController : ControllerBase
    {
        private readonly IAdditionalServiceManagement _additionalServiceManagement;
        private readonly IMapper _mapper;

        public AdditionalServiceController(IAdditionalServiceManagement additionalServiceManagement, IMapper mapper)
        {
            _additionalServiceManagement = additionalServiceManagement;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalService(
            Guid cinemaId, AdditionalServiceRequest additionalServiceRequest)
        {
            var additionalServiceResult = await _additionalServiceManagement.AddAdditionalService(
                cinemaId,
                _mapper.Map<AdditionalServiceModel>(additionalServiceRequest));

            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdditionalService(
            Guid id, Guid cinemaId, AdditionalServiceRequest additionalServiceRequest)
        {
            var additionalServiceResult = await _additionalServiceManagement.UpdateAdditionalService(
                id, cinemaId, _mapper.Map<AdditionalServiceModel>(additionalServiceRequest));

            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCinema(Guid id)
        {
            var additionalServiceResult = await _additionalServiceManagement.RemoveAdditionalService(id);
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
        public async Task<IActionResult> GetCinemaById(Guid id)
        {
            var additionalServiceResult = await _additionalServiceManagement.GetAdditionalServiceById(id);
            var response = _mapper.Map<AdditionalServiceResponse>(additionalServiceResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            var additionalServicesResult = await _additionalServiceManagement.GetAdditionalServices();
            var response = _mapper.Map<AdditionalServiceGetAllResponse>(additionalServicesResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}