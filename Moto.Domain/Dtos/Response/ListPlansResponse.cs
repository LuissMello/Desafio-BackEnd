using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public record ListPlansResponse()
    {
        public ListPlansResponse(List<PlanEntity> plans) : this()
        {
            this.Plans = [];

            foreach (var plan in plans)
                this.Plans.Add(new PlanDto(plan.Id, plan.Days, plan.Fee, plan.Price));
        }

        public List<PlanDto> Plans { get; set; }
    }
}
