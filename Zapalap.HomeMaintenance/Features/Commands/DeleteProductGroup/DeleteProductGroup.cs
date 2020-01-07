using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestBase;

namespace Zapalap.HomeMaintenance.Features.Commands.DeleteProductGroup
{
    public class DeleteProductGroup : RequestBase<ProductGroupDto>
    {
        public int ProductGroupId { get; set; }
    }
}
