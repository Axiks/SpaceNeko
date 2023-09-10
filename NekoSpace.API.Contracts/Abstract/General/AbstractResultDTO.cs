using Microsoft.AspNetCore.Mvc;

namespace NekoSpace.API.Contracts.Abstract.General
{
    public abstract class AbstractResultDTO<T> where T : class
    {
        public T? Result { get; }
        public ProblemDetails? Error { get; }

        protected AbstractResultDTO(T? result = null, ProblemDetails? error = null)
        {
            Result = result;
            Error = error;
        }
    }
}
