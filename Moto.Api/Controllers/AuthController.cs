using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Moto.Application.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Moto.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class AuthController : ControllerBase
    {
        private readonly SymmetricSecurityKey _securityKey;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        private const int TOKEN_EXPIRE_TIME_IN_HOURS = 5;
        public AuthController(IConfiguration configuration, IUserServices userServices, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Secret")["Key"]));
            _userServices = userServices;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Token([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Iniciando geração do token");

            UserEntity? user = await _userServices.GetByCnpjAsync(request.Cnpj);

            if (user is null)
                return NotFound("Usuário não encontrado");

            if (user.Password != request.Password)
                return NotFound("Usuário não encontrado");

            DateTime expireTime = DateTime.UtcNow.AddHours(TOKEN_EXPIRE_TIME_IN_HOURS);

            string token = GenerateToken(user.Role.ToString(), expireTime);

            return Ok(new { AccessToken = token, ExpireTime = expireTime });
        }

        private string GenerateToken(string role, DateTime expireTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, role) });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = expireTime,
                SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}