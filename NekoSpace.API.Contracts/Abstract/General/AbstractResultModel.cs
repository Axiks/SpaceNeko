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
        public ErrorResultDTO? Error { get; }

        protected AbstractResultModel(T? result, ErrorResultDTO? error)
        {
            Result = result;
            Error = error;
        }
    }
}
