using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zapalap.HomeMaintenance.Features.Commands.CreateProductGroup;
using Zapalap.HomeMaintenance.Features.Dto;
using Zapalap.HomeMaintenance.Features.Queries.GetProductGroups;

namespace Zapalap.HomeMaintenance.Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IMediator Mediator;

        public ProductGroupsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductGroupDto>>> GetProductGroups()
        {
            var result = await Mediator.Send(new GetProductGroups());

            if (result.IsSuccess)
                return result.Value.ToList();

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductGroupDto>> PostProductGroup(CreateProductGroup request)
        {
            if (request == null)
                return BadRequest();

            var result = await Mediator.Send(request);

            if (result.IsSuccess)
                return result.Value;

            return BadRequest(result);
        }
    }
}