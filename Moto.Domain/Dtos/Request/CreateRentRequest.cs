using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Request
{
    public record CreateRentRequest(Guid UserId, Guid BikeId, Guid PlanId);
}
