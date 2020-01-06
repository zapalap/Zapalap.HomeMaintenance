using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zapalap.HomeMaintenance.Infrastructure.RequestResult
{
    public class RequestResult<TValue> where TValue : class
    {
        public TValue Value { get; private set; }
        public string Error { get; private set; }
        public bool IsSuccess { get; private set; }

        private RequestResult(TValue value, string error, bool isSuccess)
        {
            Value = value;
            Error = error;
            IsSuccess = isSuccess;
        }

        public static RequestResult<TValue> Success(TValue value) => new RequestResult<TValue>(value, string.Empty, true);
        public static RequestResult<TValue> Fail(string error) => new RequestResult<TValue>(null, string.Empty, true);
    }
}
