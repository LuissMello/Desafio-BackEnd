using Asp.Versioning;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Api.Extensions;
using Moto.Application.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;

namespace Moto.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            _logger.LogInformation("Iniciando cadastro de usuario");
            
            UserEntity? registeredUser;

            try
            {
                registeredUser = await _userServices.ResisterAsync(request);
            }
            catch (UserAlreadyRegisteredException ex)
            {
                return Conflict(ex.Message);
            }
            catch (InvalidDocumentTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            UserResponse response = new(registeredUser.Name, registeredUser.Cnpj, registeredUser.Cnh, registeredUser.Id, registeredUser.CnhType);

            _logger.LogInformation("Usuário cadastrado com sucesso");

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(UserEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            _logger.LogInformation("Iniciando busca de usuario");
            var user = await _userServices.GetByIdAsync(userId);

            if (user is null)
                return NotFound();

            UserResponse response = new(user.Name, user.Cnpj, user.Cnh, user.Id, user.CnhType);

            _logger.LogInformation("Usuario retornado com sucesso");
            return Ok(new { User = response });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list")]
        [ProducesResponseType(typeof(List<UserEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Iniciando listagem de usuarios");
            var users = await _userServices.GetAllAsync();

            return Ok(new { Users = users });
        }
    }
}
