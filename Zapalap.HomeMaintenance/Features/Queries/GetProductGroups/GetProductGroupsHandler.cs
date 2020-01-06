using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Data;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestResult;

namespace Zapalap.HomeMaintenance.Features.Queries.GetProductGroups
{
    public class GetProductGroupsHandler : IRequestHandler<GetProductGroups, RequestResult<IEnumerable<ProductGroupDto>>>
    {
        private readonly AppDbContext Db;

        public GetProductGroupsHandler(AppDbContext db)
        {
            Db = db;
        }

        public Task<RequestResult<IEnumerable<ProductGroupDto>>> Handle(GetProductGroups request, CancellationToken cancellationToken)
        {
            var exisitingProductGroups = Db.ProductGroups.ToList();

            var dtos = exisitingProductGroups.Select(p => new ProductGroupDto { Id = p.Id, Name = p.Name, Description = p.Description });

            return Task.FromResult(RequestResult<IEnumerable<ProductGroupDto>>.Success(dtos));
        }
    }
}
