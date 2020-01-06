using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestBase;

namespace Zapalap.HomeMaintenance.Features.Queries.GetProductGroups
{
    public class GetProductGroups : RequestBase<IEnumerable<ProductGroupDto>>
    {
    }
}
