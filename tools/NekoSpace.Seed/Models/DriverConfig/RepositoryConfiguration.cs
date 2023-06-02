namespace NekoSpace.Seed.Models.DriverConfig
{
    public class RepositoryConfiguration
    {
        public string Name { get; }
        public bool IsInitial { get; }
        public IDictionary<string, int> PriorityFields { get; }

        public RepositoryConfiguration(string name, bool isInitial, IDictionary<string, int> priorityField)
        {
            Name = name;
            IsInitial = isInitial;
            PriorityFields = priorityField;
        }
    }
}