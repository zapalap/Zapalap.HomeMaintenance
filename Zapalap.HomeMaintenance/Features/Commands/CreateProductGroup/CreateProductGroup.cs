using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Data.Entities;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestBase;

namespace Zapalap.HomeMaintenance.Features.Commands.CreateProductGroup
{
    public class CreateProductGroup : RequestBase<ProductGroupDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
