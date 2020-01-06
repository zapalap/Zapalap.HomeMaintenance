using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Data;
using Zapalap.HomeMaintenance.Data.Entities;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestResult;

namespace Zapalap.HomeMaintenance.Features.Commands.CreateProductGroup
{
    public class CreateProductGroupHandler : IRequestHandler<CreateProductGroup, RequestResult<ProductGroupDto>>
    {
        private readonly AppDbContext Db;

        public CreateProductGroupHandler(AppDbContext db)
        {
            Db = db;
        }

        public Task<RequestResult<ProductGroupDto>> Handle(CreateProductGroup request, CancellationToken cancellationToken)
        {
            var newProductGroup = new ProductGroup
            {
                Name = request.Name,
                Description = request.Description
            };

            Db.Add(newProductGroup);

            var dto = new ProductGroupDto
            {
                Id = newProductGroup.Id,
                Name = newProductGroup.Name,
                Description = newProductGroup.Description
            };

            return Task.FromResult(RequestResult<ProductGroupDto>.Success(dto));
        }
    }
}
