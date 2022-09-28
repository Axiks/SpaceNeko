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
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.Type)
                .HasColumnName("Type")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.AiringStatus)
                .HasColumnName("AiringStatus")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.AgeRating)
                .HasColumnName("AgeRating")
                .HasConversion<string>();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.Source)
                .HasColumnName("Source")
                .HasConversion<string>()
                .HasDefaultValue(Source.Undefined);

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.NumEpisodes)
                .HasColumnName("NumEpisodes")
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<Anime>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();


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
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Ignore(x => x.MediaId);

            modelBuilder.
                Entity<AnimeTitle>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.AnimeId)
                .HasColumnName("AnimeId")
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<AnimeTitle>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            //      Synopsis       >>

            modelBuilder.
                Entity<AnimeSynopsis>()
                .ToTable("AnimeSynopsis");

            modelBuilder.
                Entity<AnimeSynopsis>()
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.From)
                .HasColumnName("From")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Ignore(x => x.MediaId);
            
            modelBuilder.
                Entity<AnimeSynopsis>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.AnimeId)
                .HasColumnName("AnimeId")
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<AnimeSynopsis>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            //      Genre     >>

            modelBuilder.
               Entity<Genre>()
               .ToTable("Genres");

            modelBuilder.
                Entity<Genre>()
                .HasKey(x => x.Id);

            modelBuilder.
               Entity<Genre>()
               .Property(x => x.Id)
               .HasColumnName("Id");

            modelBuilder.
               Entity<Genre>()
               .Property(x => x.Name)
               .HasColumnName("Name")
               .IsRequired();

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

            //      Premier     >>

            modelBuilder.
               Entity<Premier>()
               .Property(x => x.Year)
               .HasColumnName("Year")
               .IsRequired();

            modelBuilder.
               Entity<Premier>()
               .Property(x => x.Sezon)
               .HasColumnName("Sezon")
               .IsRequired();

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

            modelBuilder.
               Entity<Aired>()
               .Property(x => x.From)
               .HasColumnName("From")
               .IsRequired();

            modelBuilder.
               Entity<Aired>()
               .Property(x => x.To)
               .HasColumnName("To");

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

            modelBuilder.
               Entity<Image>()
               .Property(x => x.Original)
               .HasColumnName("Original")
               .IsRequired();

            modelBuilder.
               Entity<Image>()
               .Property(x => x.Large)
               .HasColumnName("Large");

            modelBuilder.
               Entity<Image>()
               .Property(x => x.Medium)
               .HasColumnName("Medium");

            modelBuilder.
               Entity<Image>()
               .Property(x => x.Small)
               .HasColumnName("Small");

            modelBuilder.
               Entity<Image>()
               .Property(x => x.From)
               .HasColumnName("From")
               .IsRequired();

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

            modelBuilder.
                Entity<Manga>()
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<Manga>()
                .Property(x => x.ChaptersCount)
                .HasColumnName("ChaptersCount")
                .IsRequired();

            modelBuilder.
                Entity<Manga>()
                .Property(x => x.Publishing)
                .HasColumnName("Publishing")
                .IsRequired();

            modelBuilder.
                Entity<Manga>()
                .Property(x => x.Volumes)
                .HasColumnName("Volumes")
                .IsRequired();

            modelBuilder.
                Entity<Manga>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            modelBuilder.
                Entity<Manga>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

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
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.From)
                .HasColumnName("From")
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Ignore(x => x.MediaId);

            modelBuilder.
                Entity<MangaTitle>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.MangaId)
                .HasColumnName("MangaId")
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<MangaTitle>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            //      MangaSynopsis       >>

            modelBuilder.
                Entity<MangaSynopsis>()
                .ToTable("MangaSynopsis");

            modelBuilder.
                Entity<MangaSynopsis>()
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.From)
                .HasColumnName("From")
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Ignore(x => x.MediaId);

            modelBuilder.
                Entity<MangaSynopsis>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.MangaId)
                .HasColumnName("MangaId")
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<MangaSynopsis>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
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

            modelBuilder.
                Entity<Character>()
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<Character>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<Character>()
                .Property(x => x.CreatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

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
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.From)
                .HasColumnName("From")
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Ignore(x => x.MediaId);

            modelBuilder.
                Entity<CharacterNames>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.CharacterId)
                .HasColumnName("CharacterId")
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<CharacterNames>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            //      Character About    >>
            modelBuilder.
                Entity<CharacterAbout>()
                .ToTable("CharacterTitles");

            modelBuilder.
                Entity<CharacterAbout>()
                .HasKey(x => x.Id);

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.Body)
                .HasColumnName("Body")
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.Language)
                .HasColumnName("Language")
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.From)
                .HasColumnName("From")
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Ignore(x => x.MediaId);

            modelBuilder.
                Entity<CharacterAbout>()
                .Ignore(x => x.Media);

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.IsMain)
                .HasColumnName("IsMain")
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.CharacterId)
                .HasColumnName("CharacterId")
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

            modelBuilder.
                Entity<CharacterAbout>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValueSql("NOW()::timestamp")
                .IsRequired();

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

            // Seeding data

            Guid GuidAdminRole = SeedRoles(modelBuilder);
            Guid GuidAdminUser = SeedAdminUser(modelBuilder);
            SeedUserRoles(GuidAdminRole, GuidAdminUser, modelBuilder);

        }

        private Guid SeedAdminUser(ModelBuilder builder)
        {
            Guid GuidAdminUser = Guid.NewGuid();
            NekoUser user = new NekoUser()
            {
                Id = GuidAdminUser.ToString(),
                UserName = "Admin",
                Email = "admin@example.local",
                LockoutEnabled = false,
            };

            PasswordHasher<NekoUser> passwordHasher = new PasswordHasher<NekoUser>();
            passwordHasher.HashPassword(user, "Pass123!!!");

            builder.Entity<NekoUser>().HasData(user);

            return GuidAdminUser;
        }

        private Guid SeedRoles(ModelBuilder builder)
        {
            Guid GuidAdminRole = Guid.NewGuid();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = GuidAdminRole.ToString(), Name = Role.Administrator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Administrator.ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Moderator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Moderator.ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Creator.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Creator.ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.User.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.User.ToString() },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = Role.Guest.ToString(), ConcurrencyStamp = "1", NormalizedName = Role.Guest.ToString() }
                );
            return GuidAdminRole;
        }

        private void SeedUserRoles(Guid GuidAdminRole, Guid GuidAdminUser, ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = GuidAdminRole.ToString(), UserId = GuidAdminUser.ToString() }
                );
        }
    }
}
