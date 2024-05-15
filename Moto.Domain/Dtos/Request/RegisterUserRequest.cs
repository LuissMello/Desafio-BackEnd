using Moto.Domain.Enums;

namespace Moto.Domain.Dtos.Request
{
    public record RegisterUserRequest(string Name, string Cnpj, DateTime BirthDate, Role Role, string Password, string Cnh, CnhType CnhType);
}
