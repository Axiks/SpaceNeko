using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Interfaces;
using NekoSpaceList.Models.CharacterModels;

namespace NekoSpace.Data.Repository
{
    public class CharacterRepository : EFBasicAbstractRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
