using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos
{
    public record UserDto(Guid Id, string Name, string Cnpj);
}
