using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using static NekoSpaceList.Models.General.GeneralModel;

namespace AnimeDB
{
    public class ApplicationDbContext : IdentityDbContext<NekoUser>
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeTitle> AnimeTitles { get; set; }
        public DbSet<AnimeSynopsis> AnimeSynopsises { get; set; }
        public DbSet<AnimeCharacter> AnimeCharacters { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<MangaTitle> MangaTitles { get; set; }
        public DbSet<MangaSynopsis> MangaSynopsises { get; set; }
        public DbSet<MangaCharacter> MangaCharacters { get; set; }
        public DbSet<CharacterNames> CharacterNames { get; set; }
        public DbSet<CharacterAbout> CharacterAbouts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Published> Publisheds { get; set; }
        public DbSet<Aired> Aireds { get; set; }
        public DbSet<Premier> Premiers { get; set; }
        public DbSet<AnimeGenre> AnimeGenre { get; set; }
        public DbSet<AnimePoster> AnimePoster { get; set; }
        public DbSet<AnimeCover> AnimeCover { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterPoster> CharacterPoster { get; set; }
        public DbSet<CharacterCover> CharacterCover { get; set; }
        public DbSet<UserFavoriteAnime> UserFavoriteAnime { get; set; }
        public DbSet<UserRatingAnime> UserRatingAnime { get; set; }
        public DbSet<UserAnimeViewingStatus> UserAnimeViewingStatus { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // For identity user
            //      Anime       >>

            modelBuilder.
                Entity<Anime>()
                .ToTable("Animes");

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.Type)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.AiringStatus)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.AgeRating)
                .HasConversion<string>();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.Source)
                .HasConversion<string>();


            //      Relation    //

            modelBuilder.
                Entity<Anime>()
                .HasMany(t => t.Titles)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Anime>()
                .HasMany(t => t.Synopsises)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            //      AnimeTitle       >>

            modelBuilder.
                Entity<AnimeTitle>()
                .ToTable("AnimeTitle");

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>();

            //      Synopsis       >>

            modelBuilder.
                Entity<AnimeSynopsis>()
                .ToTable("AnimeSynopsis");

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>();

            //      Genre     >>

            modelBuilder.
               Entity<Genre>()
               .ToTable("Genres");

            // Many to many

            //      Relation Genres    //
            modelBuilder.
                Entity<AnimeGenre>()
                .HasKey(t => new { t.AnimeId, t.GenreId });

            modelBuilder.
                Entity<Anime>()
                .HasMany(t => t.Genres)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Genre>()
                .HasMany(t => t.Animes)
                .WithOne(t => t.Genre)
                .HasForeignKey(t => t.GenreId)
                .HasPrincipalKey(t => t.Id);

            //      Relation Characters    //
            modelBuilder.
                Entity<AnimeCharacter>()
                .HasKey(t => new { t.AnimeId, t.CharacterId });

            modelBuilder.
                Entity<Anime>()
                .HasMany(t => t.Characters)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Character>()
                .HasMany(t => t.Animes)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Relation    //

            modelBuilder
                .Entity<AnotherCharacterService>()
                .ToTable("Characters");

            modelBuilder.
                Entity<Character>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherCharacterService>(x => x.Id);

            //      Premier     >>

            //      Beetwin Table       //

            modelBuilder.
                Entity<Premier>()
                .ToTable("Animes");

            //      Relation    //

            modelBuilder.
                Entity<Anime>()
                .HasOne(x => x.Premier)
                .WithOne()
                .HasForeignKey<Premier>(x => x.Id);

            //      Aired     >>


            //      Beetwin Table       //

            modelBuilder.
                Entity<Aired>()
                .ToTable("Animes");

            //      Relation    //

            modelBuilder.
                Entity<Anime>()
                .HasOne(x => x.Aired)
                .WithOne()
                .HasForeignKey<Aired>(x => x.Id);

            //      Images      //

            modelBuilder.
                Entity<Image>()
                .ToTable("Images");

            //      Relation        //

            modelBuilder
                .Entity<AnimePoster>()
                .HasKey(t => new { t.PosterId, t.AnimeId });

            modelBuilder
                .Entity<Anime>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<AnimeCover>()
                .HasKey(t => new { t.CoverId, t.AnimeId });

            modelBuilder
                .Entity<Anime>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            //      AnotherAnimeService     //
            modelBuilder
                .Entity<AnotherAnimeService>()
                .ToTable("Animes");

            modelBuilder
                .Entity<Anime>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherAnimeService>(x => x.Id);

            //      Manga       >>

            modelBuilder.
                Entity<Manga>()
                .ToTable("Mangas");


            //      Relation    //

            modelBuilder.
                Entity<Manga>()
                .HasMany(t => t.Titles)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Manga>()
                .HasMany(t => t.Synopsises)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            //      MangaTitle       >>

            modelBuilder.
                Entity<MangaTitle>()
                .ToTable("MangaTitles");

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            //      MangaSynopsis       >>

            modelBuilder.
                Entity<MangaSynopsis>()
                .ToTable("MangaSynopsis");

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.MangaId)
                .HasColumnName("MangaId")
                .IsRequired();

            //      Posters  AND Covers     >>

            //      Relation        //

            modelBuilder
                .Entity<MangaPoster>()
                .HasKey(t => new { t.PosterId, t.MangaId });

            modelBuilder
                .Entity<Manga>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<MangaCover>()
                .HasKey(t => new { t.CoverId, t.MangaId });

            modelBuilder
                .Entity<Manga>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            //      Genres     >>

            //      Relation     //
            modelBuilder.
                Entity<MangaGenre>()
                .HasKey(t => new { t.MangaId, t.GenreId });

            modelBuilder.
                Entity<Manga>()
                .HasMany(t => t.Genres)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Genre>()
                .HasMany(t => t.Mangas)
                .WithOne(t => t.Genre)
                .HasForeignKey(t => t.GenreId)
                .HasPrincipalKey(t => t.Id);

            //      Relation Mangas Persons    //
            modelBuilder.
                Entity<MangaCharacter>()
                .HasKey(t => new { t.MangaId, t.CharacterId });

            modelBuilder.
                Entity<Manga>()
                .HasMany(t => t.Characters)
                .WithOne(t => t.Manga)
                .HasForeignKey(t => t.MangaId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Character>()
                .HasMany(t => t.Mangas)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Published     //
            modelBuilder
                .Entity<Published>()
                .ToTable("Mangas");

            modelBuilder
                .Entity<Manga>()
                .HasOne(x => x.Published)
                .WithOne()
                .HasForeignKey<Published>(x => x.Id);

            //      AnotherMangaService     //
            modelBuilder
                .Entity<AnotherMangaService>()
                .ToTable("Mangas");

            modelBuilder
                .Entity<Manga>()
                .HasOne(x => x.AnotherService)
                .WithOne()
                .HasForeignKey<AnotherMangaService>(x => x.Id);

            //      Character       >>

            modelBuilder.
                Entity<Character>()
                .ToTable("Characters");

            //      Relation    //

            modelBuilder.
                Entity<Character>()
                .HasMany(t => t.Names)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.
                Entity<Character>()
                .HasMany(t => t.Abouts)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            //      Character Names    >>
            modelBuilder.
                Entity<CharacterNames>()
                .ToTable("CharacterNames");

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();


            //      Character About    >>
            modelBuilder.
                Entity<CharacterAbout>()
                .ToTable("CharacterTitles");

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>();


            //      Images Relation      //

            modelBuilder
                .Entity<CharacterPoster>()
                .HasKey(t => new { t.PosterId, t.CharacterId });

            modelBuilder
                .Entity<Character>()
                .HasMany(t => t.Posters)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<CharacterCover>()
                .HasKey(t => new { t.CoverId, t.CharacterId });

            modelBuilder
                .Entity<Character>()
                .HasMany(t => t.Covers)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId)
                .HasPrincipalKey(t => t.Id);

            // NekoUser

            // Favorite anime
            modelBuilder.
                Entity<UserFavoriteAnime>()
                .ToTable("UserFavoriteAnime");

            modelBuilder.
                Entity<UserFavoriteAnime>()
                .HasKey(t => new { t.UserId, t.AnimeId });

            /// Relations M-M

            modelBuilder
                .Entity<NekoUser>()
                .HasMany(t => t.FavoriteAnimes)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<Anime>()
                .HasMany(t => t.FavoriteInUsers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            // Rating anime
            modelBuilder.
                Entity<UserRatingAnime>()
                .ToTable("UserRatingAnime");

            modelBuilder.
                Entity<UserRatingAnime>()
                .HasKey(t => new { t.UserId, t.AnimeId });


            /// Relations M - M
            
            modelBuilder
                .Entity<NekoUser>()
                .HasMany(t => t.RatingAnimes)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<Anime>()
                .HasMany(t => t.RatingInUsers)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .HasPrincipalKey(t => t.Id);

            // Anime Viewing Status

            // Rating anime
            modelBuilder.
                Entity<UserAnimeViewingStatus>()
                .ToTable("UserAnimeViewingStatus");

            modelBuilder.
                Entity<UserAnimeViewingStatus>()
                .HasKey(t => new { t.UserId, t.AnimeId });


            /// Relations
            modelBuilder
                .Entity<NekoUser>()
                .HasMany(t => t.AnimeViewingStatuses)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<Anime>()
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
            NekoUser user = new NekoUser()
            {
                Id = GuidAdminUser.ToString(),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.local",
                NormalizedEmail = "ADMIN@EXAMPLE.LOCAL",
                PasswordHash = "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==",
                LockoutEnabled = false,
            };

            /*PasswordHasher<NekoUser> passwordHasher = new PasswordHasher<NekoUser>();
            passwordHasher.HashPassword(user, "Pass123!!!");*/

            builder.Entity<NekoUser>().HasData(user);

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
