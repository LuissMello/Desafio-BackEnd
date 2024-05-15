using MassTransit;
using Moto.Domain.Contracts;
using Moto.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Application.Events
{
    public sealed class BikeCreatedConsumer : IConsumer<BikeCreatedEvent>
    {
        public BikeCreatedConsumer()
        {
        }

        public Task Consume(ConsumeContext<BikeCreatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
