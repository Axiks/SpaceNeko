using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;

namespace NekoSpace.API.Contracts.Models.User.Library.Update
{
    public class UpdateUserLibraryResult : AbstractResultDTO<object?>
    {
        public UpdateUserLibraryResult(bool? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
