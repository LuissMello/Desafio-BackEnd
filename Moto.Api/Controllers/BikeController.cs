using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Application.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;

namespace Moto.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeServices _bikeServices;
        private readonly ILogger<BikeController> _logger;

        public BikeController(IBikeServices bikeServices, ILogger<BikeController> logger)
        {
            _bikeServices = bikeServices;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        [ProducesResponseType(typeof(BikeEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBikeRequest request)
        {
            _logger.LogInformation("Iniciando criação de moto");

            try
            {
                await _bikeServices.CreateAsync(request);
            }
            catch (BikeAlreadyRegisteredException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Moto criada com sucesso");

            return Created();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list/{plate}")]
        [ProducesResponseType(typeof(List<BikeEntity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(string plate = "")
        {
            _logger.LogInformation("Iniciando listagem de motos");
            List<BikeEntity> bikes = [];

            try
            {
                bikes = await _bikeServices.ListAsync(plate);

            }
            catch (BikeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(bikes);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("update/{bikeId}/{plate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid bikeId, string plate)
        {
            _logger.LogInformation("Iniciando atualização de moto");
            try
            {
                await _bikeServices.UpdateAsync(bikeId, plate);
            }
            catch (BikeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Atualização finalizada com sucesso");

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{bikeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid bikeId)
        {
            _logger.LogInformation("Iniciando exclusão de moto");

            try
            {
                await _bikeServices.DeleteAsync(bikeId);
            }
            catch (BikeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BikeRentedException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Moto excluida com sucesso");

            return NoContent();
        }
    }
}