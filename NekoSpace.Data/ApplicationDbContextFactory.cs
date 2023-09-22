using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpace.ElasticSearch;

namespace NekoSpace.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Server=postgres_db;Database=anilist_db;Username=neko;Password=mya", b => b.MigrationsAssembly("NekoSpace.Data"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}