﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dtos.Response
{
    public record CreatePlanResponse(Guid Id, int Days, decimal Price, decimal Fee);
}
