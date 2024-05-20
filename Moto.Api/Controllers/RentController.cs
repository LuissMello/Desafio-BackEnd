using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Application.Abstractions;
using Moto.Domain.Dtos;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;
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

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        [ProducesResponseType((typeof(CreateRentRepsonse)),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRentRequest request)
        {
            _logger.LogInformation("Iniciando cadastro de locação");

            RentEntity rentEntity;

            try
            {
                rentEntity = await _rentServices.CreateAsync(request);
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

            CreateRentRepsonse response = new(rentEntity.Id,
                                            new UserDto(rentEntity.User.Id, rentEntity.User.Name, rentEntity.User.Cnpj),
                                            new BikeDto(rentEntity.Bike.Id, rentEntity.Bike.Year, rentEntity.Bike.Plate, rentEntity.Bike.Model),
                                            new PlanDto(rentEntity.Plan.Id, rentEntity.Plan.Days, rentEntity.Plan.Fee, rentEntity.Plan.Price));


            _logger.LogInformation("Locação cadastrada com sucesso");

            return Ok(response);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("finish")]
        [ProducesResponseType(typeof(FinishRentResponse), StatusCodes.Status200OK)]
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
