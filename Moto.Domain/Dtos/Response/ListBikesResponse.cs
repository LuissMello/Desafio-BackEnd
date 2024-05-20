using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public record ListBikesResponse()
    {
        public ListBikesResponse(List<BikeEntity> bikes) : this()
        {
            Bikes = [];

            foreach (var bike in bikes)
                Bikes.Add(new BikeDto(bike.Id, bike.Year, bike.Plate, bike.Model));
        }

        public List<BikeDto> Bikes { get; set; }
    }
}
