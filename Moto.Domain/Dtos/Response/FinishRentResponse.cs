using Moto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public sealed record FinishRentResponse(decimal Price, DateTime StartDate, DateTime EndDate);
}