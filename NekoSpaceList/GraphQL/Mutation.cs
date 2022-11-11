using AnimeDB;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.General;
using NekoSpace.API.GraphQL.AnimeNameControll;
using NekoSpace.API.GraphQL.Seeding;
using NekoSpace.API.GraphQL.TranslationProposalDecision;
using NekoSpace.API.GraphQL.TranslationProposal;
using NekoSpace.Data.Models.User;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using System.Security.Claims;
using NekoSpace.API.GraphQL.SetMainTitle;
using NekoSpace.API.GraphQL.AnimeTitleItem;
using NekoSpace.API.GraphQL.Search;
using NekoSpace.API.GraphQL.Users;
using NekoSpace.API.GraphQL.UserLibraryEntry;

namespace NekoSpace.API.GraphQL
{
    public class Mutation
    {
        [Authorize(Roles = new[] { Roles.AdministratorRole })]
        public async Task<IEnumerable<Anime>> TestAsync([Service] IDBSeed<Anime> dBSeed)
        {
            return dBSeed.RunSeed(); 
        }

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
        public async Task<CreateTranslationProposalPayload> CreateTranslationProposalAsync(CreateTranslationProposalInput input, ClaimsPrincipal claimsPrincipal, [ScopedService] ApplicationDbContext context)
        {

            Guid animeId = input.AnimeId;

            string userStringId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userId = Guid.Parse(userStringId);

            var animeItem = context.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == animeId);

            if (animeItem != null)
            {
                AnimeTitle animeTitle = new AnimeTitle();
                animeTitle.AnimeId = animeId;
                animeTitle.Body = input.Proposition;
                animeTitle.CreatorUserId = userId;
                animeTitle.IsMain = false;
                animeTitle.IsOriginal = false;
                animeTitle.IsAcceptProposal = null;
                animeTitle.Language = input.Language;
                animeTitle.From = ItemFrom.User;

                animeTitle.UpdatedAt = DateTime.UtcNow;
                animeTitle.CreatedAt = DateTime.UtcNow;

                // Якщо користувач є Адміном, Модератором, чи креатором, його варіант прийняти автоматично
                if (claimsPrincipal.IsInRole(Roles.AdministratorRole) || claimsPrincipal.IsInRole(Roles.ModeratorRole) || claimsPrincipal.IsInRole(Roles.CreatorRole))
                {
                    animeTitle.IsAcceptProposal = true;

                    // Якщо даний варіант є першим, у конкретній мові - зробити його основним
                    var query = from p in context.AnimeTitles
                                where p.AnimeId == animeId && p.Language == input.Language && p.IsMain == true
                                select new
                                {
                                    p.Id
                                };
                    var countElements = query.Count();
                    if (countElements == 0)
                    {
                        animeTitle.IsMain = true;
                    }
                }

                animeItem.Titles.Add(animeTitle);
                //var succes = animeItem.Titles.Add(animeTitle);

                if (await context.SaveChangesAsync() > 0)
                {
                    return new CreateTranslationProposalPayload(true);
                }
            }

            return new CreateTranslationProposalPayload(false);
        }


        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole, Roles.CreatorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<SetDecisionTranslationProposalPayload> SetDecisionTranslationProposalAsync(SetDecisionTranslationProposalInput input, [ScopedService] ApplicationDbContext context)
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

            if (animeTitleItem.IsAcceptProposal is not null && animeTitleItem.IsAcceptProposal == true)
            {
                // Якщо даний варіант є першим, у конкретній мові - зробити його основним
                var query = from p in context.AnimeTitles
                            where p.AnimeId == animeTitleItem.AnimeId && p.Language == animeTitleItem.Language && p.IsMain == true
                            select new
                            {
                                p.Id
                            };

                var countElements = query.Count();
                if (countElements == 0)
                {
                    animeTitleItem.IsMain = true;
                }
            }

            context.SaveChangesAsync();

            return new SetDecisionTranslationProposalPayload(animeTitleItem);
        }


        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole, Roles.CreatorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<SetMainTitleInputPayload> SetMainTitleInput(SetMainTitleInput input, [ScopedService] ApplicationDbContext context)
        {
            //var animeTest = context.Animes.Include(x=> x.Titles).Single(item => item.Id == Guid.Parse("ff70f09a-5106-4fa8-95c6-31606ce609cc"));

            // Знахоми конкретно цей переклад
            var animeTitleItem = context.AnimeTitles.FirstOrDefault(item => item.Id == input.TitleId);
            if (animeTitleItem == null) return new SetMainTitleInputPayload(null, "Error: Could not find this option. Did you enter the ID correctly?");

            // Перевіряємо чи це пийнята пропозиця
            if (animeTitleItem.IsAcceptProposal != true) return new SetMainTitleInputPayload(null, "Error: The option must be confirmed");

            // Знаходимо аніме якому належить варіант перекладу
            var anime = context.Animes.Include(x => x.Titles).Single(item => item.Id == animeTitleItem.MediaId);
            if (anime == null) return new SetMainTitleInputPayload(null, "Error: It was not possible to find the anime to which this option belongs");

            // Знаходимо усі варіанти перекладів для даного аніме з конкретною мовою
            var animeTitles = anime.Titles.Where(item => item.Language == animeTitleItem.Language);

            // Перевіряємо чи варіантів перекладу є більше ніж 2
            if (animeTitles.Count() < 2)
            {
                return new SetMainTitleInputPayload(null, "Error: It is necessary to have another translation option in this language");
            }

            // Змінєюмо його Main
            if (input.isMain == true)
            {
                // Змінємо теперішній Main на false
                var animeTitleItemMainTrue = animeTitles.FirstOrDefault(item => item.IsMain == true);
                animeTitleItemMainTrue.IsMain = false;

                // Добавляємо конкретно даному true
                var animeTitleItemCurrent = animeTitleItem.IsMain = true;
            }
            else
            {
                // Цьому конкретно змінюємо на false
                var animeTitleItemCurrent = animeTitleItem.IsMain = false;

                // А іншому дному на true,
                var otherAnimeTitle = animeTitles.FirstOrDefault(item => item.Id != animeTitleItem.Id); // Знаходимо другий варіант
                otherAnimeTitle.IsMain = true;
            }

            if (context.SaveChanges() > 0) return new SetMainTitleInputPayload(animeTitleItem, null);

            return new SetMainTitleInputPayload(null, "Unknown error");
        }

        [Authorize(Roles = new[] { Roles.AdministratorRole, Roles.ModeratorRole, Roles.CreatorRole })]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AnimeTypeItemPayload> UpdateAnimeTitle(AnimeTypeItemInput input, [ScopedService] ApplicationDbContext context)
        {
            // Знахоми конкретно цей варіант
            var animeTitleItem = context.AnimeTitles.FirstOrDefault(item => item.Id == input.TitleId);
            if (animeTitleItem == null) return new AnimeTypeItemPayload(null, "Error: Could not find this option. Did you enter the ID correctly?");

            //Модифіковуємо при необхідності
            if (input.IsOriginal is not null) animeTitleItem.IsOriginal = (bool)input.IsOriginal;
            if (input.Body is not null) animeTitleItem.Body = input.Body;
            if (input.IsHiden is not null) animeTitleItem.IsHidden = (bool)input.IsHiden;

            // Зберігаємо

            if (context.SaveChanges() > 0) return new AnimeTypeItemPayload(animeTitleItem, null);

            return new AnimeTypeItemPayload(null, "Unknown error");
        }

        [Authorize]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<UserPayload> UpdateUser(UserInput input, [ScopedService] ApplicationDbContext context, [Service] UserManager<NekoUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            string userStringId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.Single(item => item.Id == userStringId);

            if (input.about is not null) user.About = input.about;

            context.SaveChanges();

            return new UserPayload(user);
        }

        [Authorize]
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<UserLibraryEntryPayload> UpdateUserLibraryEntry(UserLibraryEntryInput input, [ScopedService] ApplicationDbContext context, ClaimsPrincipal claimsPrincipal)
        {
            string userStringId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            // Знаходимо користувача у бд
            var authUser = context.Users
                .Include(x => x.RatingAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.FavoriteAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.AnimeViewingStatuses).ThenInclude(x => x.Anime)
                .Single(item => item.Id == userStringId);
            if (authUser == null) return new UserLibraryEntryPayload(null, "Error: Could not find User");

            // Знаходимо аніме
            var animeItem = context.Animes.Single(item => item.Id == input.animeId);
            if (animeItem == null) return new UserLibraryEntryPayload(null, "Error: Could not find Anime");

            if (input.isFavorite is not null)
            {
                // Перевіряємо чи таке поєднання існує
                var currentLink = context.UserFavoriteAnime.SingleOrDefault(item => item.UserId == authUser.Id && item.AnimeId == animeItem.Id);
                var currentLinkExists = currentLink != null;

                if (input.isFavorite.Value)
                {
                    if(currentLinkExists) return new UserLibraryEntryPayload(null, "Error: This anime was already in favorites");
                    // Створюємо коннект
                    var conn = new UserFavoriteAnime
                    {
                        User = authUser,
                        Anime = animeItem
                    };
                    // Добавлюємо
                    authUser.FavoriteAnimes.Add(conn);
                }
                else
                {
                    if (!currentLinkExists) return new UserLibraryEntryPayload(null, "Error: This anime was not in favorites");
                    animeItem.FavoriteInUsers.Remove(currentLink);
                }
            }

            if (input.ratingValue is not null)
            {
                // Many to one через таблицю
                //Перевіряємо чи користувач уже ставив оцінки цьому аніме
                var userAnimeRatingItem = authUser.RatingAnimes.SingleOrDefault(x => x.AnimeId == animeItem.Id);

                // Добавляємо оцінку, якщо не існує
                if (userAnimeRatingItem == null)
                {
                    // Створюємо об`єкт коннекту
                    var conn = new UserRatingAnime
                    {
                        User = authUser,
                        Anime = animeItem,
                        RatingValue = input.ratingValue ?? 0
                    };
                    authUser.RatingAnimes.Add(conn);
                }
                else
                {
                    // Оновлюємо значення
                    userAnimeRatingItem.RatingValue = input.ratingValue ?? 0;
                }

            }

            if(input.viewStatus is not null)
            {
                // Many to one через таблицю
                //Перевіряємо чи користувач уже ставив статус цьому аніме
                var userAnimeViewStatusItem = authUser.AnimeViewingStatuses.SingleOrDefault(x => x.AnimeId == animeItem.Id);

                // Добавляємо оцінку, якщо не існує
                if (userAnimeViewStatusItem == null)
                {
                    // Створюємо об`єкт коннекту
                    var conn = new UserAnimeViewingStatus
                    {
                        User = authUser,
                        Anime = animeItem,
                        Status = input.viewStatus ?? UserViewStatus.PlanToWatch
                    };
                    authUser.AnimeViewingStatuses.Add(conn);
                }
                else
                {
                    // Оновлюємо значення
                    userAnimeViewStatusItem.Status = input.viewStatus ?? UserViewStatus.PlanToWatch;
                }
            }

            // Зберігаємо
            if (context.SaveChanges() > 0) return new UserLibraryEntryPayload(authUser, null);

            return new UserLibraryEntryPayload(authUser, "No changes have occurred");

        }
    }
}
