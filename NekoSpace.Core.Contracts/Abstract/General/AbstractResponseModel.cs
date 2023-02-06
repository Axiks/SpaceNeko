using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Abstract.General
{
    public abstract class AbstractResponseModel<T>
    {
        public T? Result { get; }
        public string? Error { get; }

        protected AbstractResponseModel(T? result, string? error)
        {
            Result = result;
            Error = error;
        }
    }
}
