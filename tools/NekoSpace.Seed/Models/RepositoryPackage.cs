using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models.DriverConfig;

namespace NekoSpace.Seed.Models
{
    public class RepositoryPackage<T> where T : MediaEntity
    {
        public required IRepository<T> repository { get; set; }

        public required string Name { get; set; }
        public required bool IsInitial { get; set; }
        public List<string> AllowedFields { get; }
        //public required RepositoryConfiguration<T> repositoryConfiguration { get; set; }
        
        public List<string> GetAllAvaibleFields()
        {
            List<string> fields = new List<string>();
            Type typeParameterType = typeof(T);
            foreach (var f in typeParameterType.GetFields().Where(f => f.IsPublic))
            {
                fields.Add(f.Name);
            }
            return fields;
        }

        public bool AddAllowedField(string field)
        {
            if(!AllowedFields.Contains(field)) return false;
            AllowedFields.Add(field);
            return true;
        }

        public void RemoveAllowedField(string field)
        {
            if (!AllowedFields.Contains(field)) return;
            AllowedFields.Remove(field);
        }
    }
}
