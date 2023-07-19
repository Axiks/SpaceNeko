using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.Character;
using NekoSpace.Data.Contracts.Entities.General;
using NekoSpace.Data.Contracts.Entities.Manga;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Data.Models.User;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpace.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<AnimeEntity> Animes { get; set; }
        public DbSet<AnimeTitleEntity> AnimeTitles { get; set; }
        public DbSet<AnimeSynopsisEntity> AnimeSynopsises { get; set; }
        public DbSet<AnimeCharacterEntity> AnimeCharacters { get; set; }
        public DbSet<MangaEntity> Mangas { get; set; }
        public DbSet<MangaTitleEntity> MangaTitles { get; set; }
        public DbSet<MangaSynopsisEntity> MangaSynopsises { get; set; }
        public DbSet<MangaCharacterEntity> MangaCharacters { get; set; }
        public DbSet<CharacterNamesEntity> CharacterNames { get; set; }
        public DbSet<CharacterAboutEntity> CharacterAbouts { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PublishedEntity> Publisheds { get; set; }
        public DbSet<AiredEntity> Aireds { get; set; }
        public DbSet<PremierEntity> Premiers { get; set; }
        public DbSet<AnimeGenreEntity> AnimeGenre { get; set; }
        public DbSet<AnimePosterEntity> AnimePoster { get; set; }
        public DbSet<AnimeCoverEntity> AnimeCover { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }
        public DbSet<CharacterPosterEntity> CharacterPoster { get; set; }
        public DbSet<CharacterCoverEntity> CharacterCover { get; set; }
        public DbSet<UserFavoriteAnimeEntity> UserFavoriteAnime { get; set; }
        public DbSet<UserRatingAnimeEntity> UserRatingAnime { get; set; }
        public DbSet<UserAnimeViewingStatusEntity> UserAnimeViewingStatus { get; set; }
        //public DbSet<AssociatedServiceEntity> AssociatedService { get; set; }

        #region ContextConstructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        #endregion
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // For identity user
            //      Anime       >>

            modelBuilder.
                Entity<AnimeEntity>()
                .ToTable("Animes");

            modelBuilder.
                Entity<AnimeEntity>()
                .Property(x => x.Type)
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeEntity>()
                .Property(x => x.AiringStatus)
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeEntity>()
                .Property(x => x.AgeRating)
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeEntity>()
                .Property(x => x.Source)
                .HasConversion<string>();


            //      Relation    //

            modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(t => t.Titles)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

          /*  modelBuilder.
                Entity<AnimeTitleEntity>()
                .HasOne(t => t.Anime)
                .WithMany(t => t.Titles)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);*/


            modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(t => t.Synopsises)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            /*modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(t => t.AnotherService)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);*/
            /*modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(a => a.AnotherService)
                .WithOne()
                .HasForeignKey(el => el.MediaEntityId);*/
/*            modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(a => a.AssociatedService)
                .WithOne(a=> a.AnimeEntity)
                .HasForeignKey(a => a.AnimeId)
                .HasPrincipalKey(a => a.Id);*/

            //      AnimeTitle       >>

            modelBuilder.
                Entity<AnimeTitleEntity>()
                .ToTable("AnimeTitle");

            modelBuilder.
                Entity<AnimeTitleEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeTitleEntity>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>();

            /*modelBuilder.
               Entity<AnimeTitleEntity>()
               .Ignore(x => x.AnimeId);

            modelBuilder.
               Entity<AnimeTitleEntity>()
               .Ignore(x => x.Anime);*/

            // configures one-to-many relationship

            /*modelBuilder.
                Entity<AnimeTitleEntity>()
                .HasOne(t => t.Anime)
                .WithMany(c => c.Titles)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);*/

            /*modelBuilder.Entity<AnimeTitleEntity>()
                .HasOne(e => e.Anime)
                .WithMany(c => c.Titles);*/

            /*modelBuilder.
                 Entity<AnimeEntity>()
                 .HasMany(t => t.Titles)
                 .WithOne(t => t.Anime)
                 .HasForeignKey(t => t.AnimeId)
                 .HasPrincipalKey(t => t.Id);*/

            //      Synopsis       >>

            modelBuilder.
                Entity<AnimeSynopsisEntity>()
                .ToTable("AnimeSynopsis");

            modelBuilder.
                Entity<AnimeSynopsisEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeSynopsisEntity>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>();

            //      Genre     >>

            modelBuilder.
               Entity<GenreEntity>()
               .ToTable("Genres");

            // Many to many

            //      Relation Genres    //
            modelBuilder.
                Entity<AnimeGenreEntity>()
                .HasKey(t => new { t.AnimeId, t.GenreId });

            modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(t => t.Genres)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<GenreEntity>()
                .HasMany(t => t.Animes)
                .WithOne(t => t.Genre)
                .HasForeignKey(t => t.GenreId)
                .HasPrincipalKey(t => t.Id);

            //      Relation Characters    //
            modelBuilder.
                Entity<AnimeCharacterEntity>()
                .HasKey(t => new { t.AnimeId, t.CharacterId });

            modelBuilder.
                Entity<AnimeEntity>()
                .HasMany(t => t.Characters)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(t => t.Animes)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Relation    //

            /*modelBuilder
                .Entity<AnotherCharacterServiceEntity>()
                .ToTable("Characters");
*/
            /*modelBuilder.
                Entity<CharacterEntity>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherCharacterServiceEntity>(x => x.Id);*/
            /*modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(t => t.AnotherService)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);*/

            /*modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(a => a.AnotherService)
                .WithOne()
                .HasForeignKey(el => el.MediaEntityId)
                .HasPrincipalKey(t => t.Id);*/


            modelBuilder.
               Entity<AssociatedServiceEntity>()
               .ToTable("AssociatedService")
               .HasKey(k => k.Id);

            //      Premier     >>

            //      Beetwin Table       //

            modelBuilder.
                Entity<PremierEntity>()
                .ToTable("Animes");

            //      Relation    //

            modelBuilder.
                Entity<AnimeEntity>()
                .HasOne(x => x.Premier)
                .WithOne()
                .HasForeignKey<PremierEntity>(x => x.Id);

            //      Aired     >>


            //      Beetwin Table       //

            modelBuilder.
                Entity<AiredEntity>()
                .ToTable("Animes");

            //      Relation    //

            modelBuilder.
                Entity<AnimeEntity>()
                .HasOne(x => x.Aired)
                .WithOne()
                .HasForeignKey<AiredEntity>(x => x.Id);

            //      Images      //

            modelBuilder.
                Entity<ImageEntity>()
                .ToTable("Images");

            //      Relation        //

            modelBuilder
                .Entity<AnimePosterEntity>()
                .HasKey(t => new { t.PosterId, t.AnimeId });

            modelBuilder
                .Entity<AnimeEntity>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<AnimeCoverEntity>()
                .HasKey(t => new { t.CoverId, t.AnimeId });

            modelBuilder
                .Entity<AnimeEntity>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            //      AnotherAnimeService     //

            /*modelBuilder
                .Entity<AnotherAnimeServiceEntity>()
                .ToTable("Animes");

            modelBuilder
                .Entity<AnimeEntity>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherAnimeServiceEntity>(x => x.Id);*/

            //      New AnotherAnimeService     //
            /*modelBuilder
                .Entity<MediaEntity>()
                .HasMany(e => e.AnotherService)
                .WithOne(e => e.Media)
                .HasForeignKey(e => e.MediaId);*/


            //      Manga       >>

            modelBuilder.
                Entity<MangaEntity>()
                .ToTable("Mangas");


            //      Relation    //

            modelBuilder.
                Entity<MangaEntity>()
                .HasMany(t => t.Titles)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<MangaEntity>()
                .HasMany(t => t.Synopsises)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            //      MangaTitle       >>

            modelBuilder.
                Entity<MangaTitleEntity>()
                .ToTable("MangaTitles");

            modelBuilder.
                Entity<MangaTitleEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            //      MangaSynopsis       >>

            modelBuilder.
                Entity<MangaSynopsisEntity>()
                .ToTable("MangaSynopsis");

            modelBuilder.
                Entity<MangaSynopsisEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsisEntity>()
                .Property(x => x.MangaId)
                .HasColumnName("MangaId")
                .IsRequired();

            //      Posters  AND Covers     >>

            //      Relation        //

            modelBuilder
                .Entity<MangaPosterEntity>()
                .HasKey(t => new { t.PosterId, t.MangaId });

            modelBuilder
                .Entity<MangaEntity>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<MangaCoverEntity>()
                .HasKey(t => new { t.CoverId, t.MangaId });

            modelBuilder
                .Entity<MangaEntity>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            //      Genres     >>

            //      Relation     //
            modelBuilder.
                Entity<MangaGenreEntity>()
                .HasKey(t => new { t.MangaId, t.GenreId });

            modelBuilder.
                Entity<MangaEntity>()
                .HasMany(t => t.Genres)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<GenreEntity>()
                .HasMany(t => t.Mangas)
                .WithOne(t => t.Genre)
                .HasForeignKey(t => t.GenreId)
                .HasPrincipalKey(t => t.Id);

            //      Relation Mangas Persons    //
            modelBuilder.
                Entity<MangaCharacterEntity>()
                .HasKey(t => new { t.MangaId, t.CharacterId });

            modelBuilder.
                Entity<MangaEntity>()
                .HasMany(t => t.Characters)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(t => t.Mangas)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Published     //
            modelBuilder
                .Entity<PublishedEntity>()
                .ToTable("Mangas");

            modelBuilder
                .Entity<MangaEntity>()
                .HasOne(x => x.Published)
                .WithOne()
                .HasForeignKey<PublishedEntity>(x => x.Id);

            //      AnotherMangaService     //
            /*modelBuilder
                .Entity<AnotherMangaServiceEntity>()
                .ToTable("Mangas");*/

            /*modelBuilder
                .Entity<MangaEntity>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherMangaServiceEntity>(x => x.Id);*/

            /*modelBuilder.
                Entity<MangaEntity>()
                .HasMany(t => t.AnotherService)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);*/

            /*modelBuilder.
                Entity<MangaEntity>()
                .HasMany(a => a.AnotherService)
                .WithOne()
                .HasForeignKey(el => el.MediaEntityId);*/

            modelBuilder.
                Entity<MediaEntity>()
                .HasMany(a => a.AssociatedService)
                .WithOne(a => a.Media)
                .HasForeignKey(a => a.MediaId)
                .HasPrincipalKey(a => a.Id);

            //      Character       >>

            modelBuilder.
                Entity<CharacterEntity>()
                .ToTable("Characters");

            //      Relation    //

            modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(t => t.Names)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(t => t.Abouts)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Character Names    >>
            modelBuilder.
                Entity<CharacterNamesEntity>()
                .ToTable("CharacterNames");

            modelBuilder.
                Entity<CharacterNamesEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();


            //      Character About    >>
            modelBuilder.
                Entity<CharacterAboutEntity>()
                .ToTable("CharacterTitles");

            modelBuilder.
                Entity<CharacterAboutEntity>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();


            //      Images Relation      //

            modelBuilder
                .Entity<CharacterPosterEntity>()
                .HasKey(t => new { t.PosterId, t.CharacterId });

            modelBuilder
                .Entity<CharacterEntity>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<CharacterCoverEntity>()
                .HasKey(t => new { t.CoverId, t.CharacterId });

            modelBuilder
                .Entity<CharacterEntity>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

/*            modelBuilder.
                Entity<CharacterEntity>()
                .HasMany(a => a.AssociatedService)
                .WithOne(a => a.CharacterEntity)
                .HasForeignKey(a => a.CharacterId)
                .HasPrincipalKey(a => a.Id);*/

            // UserEntity

            // Favorite anime
            modelBuilder.
                Entity<UserFavoriteAnimeEntity>()
                .ToTable("UserFavoriteAnime");

            modelBuilder.
                Entity<UserFavoriteAnimeEntity>()
                .HasKey(t => new { t.UserId, t.AnimeId });

            /// Relations M-M

            modelBuilder
                .Entity<UserEntity>()
                .HasMany(t => t.FavoriteAnimes)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<AnimeEntity>()
                .HasMany(t => t.FavoriteInUsers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            // Rating anime
            modelBuilder.
                Entity<UserRatingAnimeEntity>()
                .ToTable("UserRatingAnime");

            modelBuilder.
                Entity<UserRatingAnimeEntity>()
                .HasKey(t => new { t.UserId, t.AnimeId });


            /// Relations M - M

            modelBuilder
                .Entity<UserEntity>()
                .HasMany(t => t.RatingAnimes)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<AnimeEntity>()
                .HasMany(t => t.RatingInUsers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            // Anime Viewing Status

            // Rating anime
            modelBuilder.
                Entity<UserAnimeViewingStatusEntity>()
                .ToTable("UserAnimeViewingStatus");

            modelBuilder.
                Entity<UserAnimeViewingStatusEntity>()
                .HasKey(t => new { t.UserId, t.AnimeId });


            /// Relations
            modelBuilder
                .Entity<UserEntity>()
                .HasMany(t => t.AnimeViewingStatuses)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<AnimeEntity>()
                .HasMany(t => t.ViewingStatusInUsers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);


            // Seeding data
            Guid GuidAdminRole = SeedRoles(modelBuilder);
            Guid GuidAdminUser = SeedAdminUser(modelBuilder);
            SetAdminUserRoles(GuidAdminRole, GuidAdminUser, modelBuilder);

        }

        private Guid SeedAdminUser(ModelBuilder builder)
        {
            Guid GuidAdminUser = Guid.NewGuid();
            UserEntity user = new UserEntity()
            {
                Id = GuidAdminUser.ToString(),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.local",
                NormalizedEmail = "ADMIN@EXAMPLE.LOCAL",
                PasswordHash = "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==",
                LockoutEnabled = false,
            };

            /*PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
            passwordHasher.HashPassword(user, "Pass123!!!");*/

            builder.Entity<UserEntity>().HasData(user);

            return GuidAdminUser;
        }

        private Guid SeedRoles(ModelBuilder builder)
        {
            Guid GuidAdminRole = Guid.NewGuid();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = GuidAdminRole.ToString(), Name = Role.Administrator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Administrator.ToString().ToUpper() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Moderator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Moderator.ToString().ToUpper() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Creator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Creator.ToString().ToUpper() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.User.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.User.ToString().ToUpper() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Guest.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Guest.ToString().ToUpper() }
                );
            return GuidAdminRole;
        }

        private void SetAdminUserRoles(Guid GuidAdminRole, Guid GuidAdminUser, ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = GuidAdminRole.ToString(), UserId = GuidAdminUser.ToString() }
                );
        }
    }
}
