using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Data;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Infrastructure.RequestResult;

namespace Zapalap.HomeMaintenance.Features.Commands.DeleteProductGroup
{
    public class DeleteProductGroupHandler : IRequestHandler<DeleteProductGroup, RequestResult<ProductGroupDto>>
    {
        private readonly AppDbContext Db;

        public DeleteProductGroupHandler(AppDbContext db)
        {
            Db = db;
        }

        public async Task<RequestResult<ProductGroupDto>> Handle(DeleteProductGroup request, CancellationToken cancellationToken)
        {
            var existingProductGroup = Db.ProductGroups.FirstOrDefault(g => g.Id == request.ProductGroupId);

            if (existingProductGroup == null)
                return RequestResult<ProductGroupDto>.Fail("Product group was not found");

            Db.Remove(existingProductGroup);
            await Db.SaveChangesAsync();

            // TODO: Return something more sane
            return RequestResult<ProductGroupDto>.Success(new ProductGroupDto { Id = request.ProductGroupId });
        }
    }
}
