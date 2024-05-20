using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moto.Application.Abstractions;
using Moto.Application.Services;
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
    public class PlanController : ControllerBase
    {
        private readonly IPlanServices _planServices;
        private readonly ILogger<PlanController> _logger;

        public PlanController(IPlanServices planServices, ILogger<PlanController> logger)
        {
            _planServices = planServices;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        [ProducesResponseType((typeof(CreatePlanResponse)), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePlanRequest request)
        {
            _logger.LogInformation("Iniciando cadastro de plano");

            PlanEntity planEntity;

            try
            {
                planEntity = await _planServices.CreateAsync(request);
            }
            catch (PlanAlreadyRegisteredException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            CreatePlanResponse response = new(planEntity.Id, planEntity.Days, planEntity.Price, planEntity.Fee);

            _logger.LogInformation("Plano cadastrado com sucesso");

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdatePlanRequest request)
        {
            _logger.LogInformation("Iniciando atualização de plano");

            PlanEntity planEntity;

            try
            {
                planEntity = await _planServices.UpdateAsync(request.planId, request);
            }
            catch (PlanNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PlanAlreadyRegisteredException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            UpdatePlanResponse response = new(planEntity.Id, planEntity.Days, planEntity.Price, planEntity.Fee);

            _logger.LogInformation("Plano atualizado com sucesso");

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{planID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid planId)
        {
            _logger.LogInformation("Iniciando exclusão de plano");

            try
            {
                await _planServices.Delete(planId);
            }
            catch (PlanNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            _logger.LogInformation("Plano excluido com sucesso");

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list")]
        [ProducesResponseType(typeof(List<PlanEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAll()
        {
            _logger.LogInformation("Iniciando listagem de planos");

            List<PlanEntity> plans;

            try
            {
                plans = await _planServices.ListAllAsync();

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

            ListPlansResponse response = new(plans);

            return Ok(response);
        }
    }
}
