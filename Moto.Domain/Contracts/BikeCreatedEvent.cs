using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Contracts
{
    public record BikeCreatedEvent(Guid Id, int Year, string Plate, string Model);
}
