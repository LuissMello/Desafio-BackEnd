using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Request
{
    public record CreateBikeRequest(int Year, string Plate, string Model);
}
