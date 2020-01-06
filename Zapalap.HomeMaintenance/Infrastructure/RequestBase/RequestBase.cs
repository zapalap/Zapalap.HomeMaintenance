using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zapalap.HomeMaintenance.Infrastructure.RequestResult;

namespace Zapalap.HomeMaintenance.Infrastructure.RequestBase
{
    public class RequestBase<TValue> : IRequest<RequestResult<TValue>> where TValue : class
    {
    }
}
