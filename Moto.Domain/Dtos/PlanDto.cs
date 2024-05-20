using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos
{
    public record PlanDto(Guid Id, int Days, decimal Fee, decimal Price);
}
