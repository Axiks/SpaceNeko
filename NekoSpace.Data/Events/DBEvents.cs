using Microsoft.EntityFrameworkCore;

namespace NekoSpace.Data.Events
{
    public class DBEvents
    {
        public static void Context_SavingChanges(object sender, SavingChangesEventArgs args)
        {
            Console.WriteLine($"Початок збереження змін.");
        }

        public static void Context_SavedChanges(object sender, SavedChangesEventArgs args)
        {
            Console.WriteLine($"Saved  {args.EntitiesSavedCount}  No of changes.");
        }

        public static void Context_SaveChangesFailed(object sender, SaveChangesFailedEventArgs args)
        {
            Console.WriteLine($"Збереження не вдалося через  {args.Exception} .");
        }
    }
}
