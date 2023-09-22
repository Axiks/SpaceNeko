using NekoSpace.Repository.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Repository.Contracts.Interfaces
{
    public interface IInterconnectionExtensions
    {
        public Dictionary<Guid, List<InterconnectionLinkModel>> GetAllInterconnection();
        public Dictionary<Guid, List<InterconnectionLinkModel>> GetInterconnectionFromService(string serviceName);
        public Guid? FindMediaIdByAnotherService(InterconnectionLinkModel interconnectionLinkModel);
        public Guid? FindMediaIdByAnotherServiceList(List<InterconnectionLinkModel> interconnectionLinkModelList);
    }
}
