using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Message { get; set; }
    }
}
