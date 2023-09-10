using NekoSpace.Data.Contracts.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Repository.Contracts.Interfaces
{
    //Треба дописати
    public interface IMediaSearch<T> where T : MediaEntity
    {
        public void Find(); 
    }
}
