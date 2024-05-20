using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public record CreateRentRepsonse(Guid Id, UserDto User, BikeDto Bike, PlanDto Plan);
}
