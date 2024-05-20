using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public record CreateBikeResponse(Guid Id, int Year, string Plate, string Model);
}
