using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Abstract.General
{
    public class ErrorResultDTO
    {
        public ErrorResultDTO(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
