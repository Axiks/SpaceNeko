using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository.Contracts.Models;

namespace NekoSpace.Seed
{
    public partial class AbstractMediaRepositoryDriver<T, E> where T : MediaEntity where E : ElasticSearchMediaBasicModel
    {
        public class InterconnectionMediaLink
        {
            private Dictionary<Guid, List<InterconnectionLinkModel>> InterconnectionLinksDb;

            public InterconnectionMediaLink()
            {
                InterconnectionLinksDb = new Dictionary<Guid, List<InterconnectionLinkModel>>();
            }

            public void AddLink(Guid mediaDbId, InterconnectionLinkModel interconnectionLink)
            {
                bool HasKey = InterconnectionLinksDb.ContainsKey(mediaDbId);
                if (HasKey)
                {
                    List<InterconnectionLinkModel> links = InterconnectionLinksDb[mediaDbId];
                    if (!links.Contains(interconnectionLink)) links.Add(interconnectionLink);
                    InterconnectionLinksDb[mediaDbId] = links; //?
                }
                else
                {
                    InterconnectionLinksDb.Add(mediaDbId, new List<InterconnectionLinkModel> { interconnectionLink });
                }

            }

            public Guid GetDBIdByLink(InterconnectionLinkModel interconnectionLink)
            {
                var myKey = InterconnectionLinksDb.FirstOrDefault(x => x.Value.Contains(interconnectionLink)).Key;
                return myKey;
            }

            public List<InterconnectionLinkModel> GetLinksByDBId(Guid Id)
            {
                return InterconnectionLinksDb[Id];
            }

            public List<InterconnectionLinkModel> GetLinksByLink(InterconnectionLinkModel interconnectionLink)
            {
                var myValue = InterconnectionLinksDb.FirstOrDefault(x => x.Value.Contains(interconnectionLink)).Value;
                return myValue;
            }

            public List<string> GetAllIdFromService(string serviceName)
            {
                var myValue = InterconnectionLinksDb.SelectMany(x => x.Value.Where(n => n.ServiceName == serviceName).Select(o => o.Id)).ToList();
                return myValue;
            }

        }
    }
}
