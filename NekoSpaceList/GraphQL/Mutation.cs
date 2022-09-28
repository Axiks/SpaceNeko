using AnimeDB;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.General;
using NekoSpace.API.GraphQL.AnimeNameControll;
using NekoSpace.API.GraphQL.Seeding;
using NekoSpace.API.GraphQL.TranslationDecision;
using NekoSpace.API.GraphQL.TranslationProposal;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL
{
    public class Mutation
    {
        [Authorize(Roles = new[] { Roles.AdministratorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddSeedingPayload> RunSeedingAsync(AddSeedingInput input, [ScopedService] ApplicationDbContext context, [Service] IDBSeed<Anime> dBSeed)
        {
            if (input.InRecreateDB ?? false)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var animeRepo = context.Animes;
            var animes = dBSeed.RunSeed().ToList();

            int itemCount = animes.Count();
            int offset = input.offset ?? itemCount;
            int page = input.page ?? 1;

            while (page * offset <= itemCount)
            {
                for (int i = offset * (page - 1); i < offset * page; i++)
                {
                    animeRepo.Add(animes[i]);
                }
                page++;
                context.SaveChanges();
            }

            /*foreach (var anime in animes)
            {
                animeRepo.Add(anime);
            }
            context.SaveChanges();*/

            return new AddSeedingPayload(animeRepo.ToList());
        }

        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole, Roles.CreatorRole, Roles.UserRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddTranslationProposalPayload> AddTranslationProposalAsync(AddTranslationProposalInput input, [ScopedService] ApplicationDbContext context)
        {
            Guid animeId = input.AnimeId;

            var animeList = context.Animes.Include(x => x.Titles);
            var animeItem = animeList.FirstOrDefault(item => item.Id == animeId);

            if (animeItem != null)
            {
                AnimeTitle animeTitle = new AnimeTitle();
                animeTitle.AnimeId = animeId;
                animeTitle.Body = input.Proposition;
                animeTitle.CreatorUserId = Guid.NewGuid();
                animeTitle.IsMain = false;
                animeTitle.IsOriginal = false;
                animeTitle.IsAcceptProposal = null;
                animeTitle.Language = input.Language;
                animeTitle.From = ItemFrom.User;

                animeTitle.UpdatedAt = DateTime.UtcNow;
                animeTitle.CreatedAt = DateTime.UtcNow;

                animeItem.Titles.Add(animeTitle);

                context.SaveChangesAsync();
            }

            return new AddTranslationProposalPayload(animeItem);
        }

        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole, Roles.CreatorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddTranslationDecisionPayload> AddTranslationDecisionAsync(AddTranslationDecisionInput input, [ScopedService] ApplicationDbContext context)
        {
            var animeTitleItem = context.AnimeTitles.FirstOrDefault(item => item.Id == input.TitleId);

            switch (input.Decision)
            {
                case DecisionVariants.ACCEPT:
                    animeTitleItem.IsAcceptProposal = true;
                    break;
                case DecisionVariants.REJECT:
                    animeTitleItem.IsAcceptProposal = false;
                    break;
            }
            context.SaveChangesAsync();

            return new AddTranslationDecisionPayload(animeTitleItem);
        }

        // Update name
        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<UpdateTranslationNamePayload> UpdateTranslationNameAsync(UpdateTranslationNameInput input, [ScopedService] ApplicationDbContext context)
        {
            var animeTitleItem = context.AnimeTitles.FirstOrDefault(item => item.Id == input.Id);
            if (animeTitleItem == null) return new UpdateTranslationNamePayload(animeTitle: null);

            animeTitleItem.Body = input.Body;
            animeTitleItem.Language = input.Language;
            animeTitleItem.IsOriginal = input.IsOriginal;

            context.SaveChangesAsync();

            return new UpdateTranslationNamePayload(animeTitleItem);
        }

        // Delete name
        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<DeleteTranslationNamePayload> DeleteTranslationNameAsync(DeleteTranslationNameInput input, [ScopedService] ApplicationDbContext context)
        {
            var animeTitleItem = context.AnimeTitles.FirstOrDefault(item => item.Id == input.Id);
            context.AnimeTitles.Remove(animeTitleItem);
            context.SaveChangesAsync();

            return new DeleteTranslationNamePayload(true);
        }
    }
}
