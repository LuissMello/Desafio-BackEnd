using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Request
{
    public record FinishRentRequest(Guid RentId, DateTime Date);
}
