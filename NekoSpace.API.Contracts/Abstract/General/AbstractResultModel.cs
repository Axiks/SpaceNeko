using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Abstract.General
{
    public abstract class AbstractResultModel<T>
    {
        public T? Result { get; }
        public string? Error { get; }

        protected AbstractResultModel(T? result, string? error)
        {
            Result = result;
            Error = error;
        }
    }
}
