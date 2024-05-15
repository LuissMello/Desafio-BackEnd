using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Application.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moto.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [Authorize]
    public class RentController : ControllerBase
    {
        private readonly IRentServices _rentServices;
        private readonly ILogger<RentController> _logger;

        public RentController(IRentServices rentServices, ILogger<RentController> logger)
        {
            _rentServices = rentServices;
            _logger = logger;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRentRequest request)
        {
            _logger.LogInformation("Iniciando cadastro de locação");

            try
            {
                await _rentServices.CreateAsync(request);
            }
            catch (Exception ex) when (ex is BikeNotFoundException or UserNotFoundException or PlanNotFoundException)
            {
                return NotFound(ex.Message);
            }
            catch(BikeAlreadyRentedException ex)
            {
                return Conflict(ex.Message);
            }
            catch (InvalidDocumentTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Locação cadastrada com sucesso");

            return Created();
        }


        [HttpPost("finish")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Finish([FromBody] FinishRentRequest request)
        {
            _logger.LogInformation("Finalizando locação");

            FinishRentResponse response;

            try
            {
                response = await _rentServices.FinishAsync(request);
            }
            catch (RentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Locação finalizada com sucesso");

            return Ok(response);
        }
    }
}
