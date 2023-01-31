﻿//using JikanDotNet;
using NekoSpace.Data.Contracts.Entities.Enumerations;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;
using System.Text.RegularExpressions;
using static NekoSpaceList.Models.General.GeneralModel;
using JikanDN = JikanDotNet;

namespace NekoSpace.Seed.Driver
{
    public class MalAnimeDriver : ISelectMediaByMALId<Anime>
    {
        public RTO<Anime> GetByMALId(long Id)
        {
            return getMalAnimeById(Id);
        }

        private RTO<Anime> getMalAnimeById(long MalId)
        {
            Anime anime = new Anime();
            // Initialize JikanWrapper
            JikanDN.IJikan jikan = new JikanDN.Jikan();

            // Send request for "Cowboy Bebop" anime
            var cowboyBebop = jikan.GetAnimeFullDataAsync(MalId).Result;

            // Мапим новими даними нашу модель
            AnimeTitle title = new AnimeTitle();
                title.Body = cowboyBebop.Data.Title;
                title.IsOriginal = true;
                title.IsMain = true;
                title.Language = Languages.EN;

            AnimeTitle titleEng = new AnimeTitle();
                titleEng.Body = cowboyBebop.Data.TitleEnglish;
                titleEng.IsOriginal = false;
                titleEng.IsMain = false;
                titleEng.Language = Languages.EN;

            AnimeTitle titleJp = new AnimeTitle();
                titleJp.Body = cowboyBebop.Data.TitleJapanese;
                titleJp.IsOriginal = true;
                titleJp.IsMain = true;
                titleJp.Language = Languages.JA;

            ICollection<AnimeTitle> animeTitles = new List<AnimeTitle>()
            {
                title,
                titleJp,
                titleEng
            };

            var JdnTitles = cowboyBebop.Data.Titles;
            foreach (var JdnTitle in JdnTitles)
            {
                AnimeTitle titleAlt = new AnimeTitle();
                titleAlt.Body = JdnTitle.Title;
                titleAlt.IsOriginal = false;
                titleAlt.IsMain = false;

                switch (JdnTitle.Type)
                {
                    case ("Eng"):
                        titleAlt.Language = Languages.EN;
                        break;
                    case ("Jp"):
                        titleAlt.Language = Languages.JA;
                        break;
                    default:
                        titleAlt.Language = Languages.und;
                        break;
                }
                animeTitles.Add(titleAlt);

            }

            var JdnTitlesSyn = cowboyBebop.Data.TitleSynonyms;
            foreach (var JdnTitle in JdnTitlesSyn)
            {
                AnimeTitle titleAlt = new AnimeTitle();
                titleAlt.Body = JdnTitle;
                titleAlt.IsOriginal = false;
                titleAlt.IsMain = false;
                titleAlt.Language = Languages.und;
                animeTitles.Add(titleAlt);
            }

            anime.Titles = animeTitles;

            AnimeType animeType = new AnimeType();
            switch (cowboyBebop.Data.Type)
            {
                case ("TV"):
                    animeType = AnimeType.TV;
                    break;
                case ("Movie"):
                    animeType = AnimeType.Movie;
                    break;
                case ("OVA"):
                    animeType = AnimeType.OVA;
                    break;
                case ("Special"):
                    animeType = AnimeType.Special;
                    break;
                case ("ONA"):
                    animeType = AnimeType.ONA;
                    break;
                case ("Music"):
                    animeType = AnimeType.Music;
                    break;
                case ("EveryType"):
                    animeType = AnimeType.EveryType;
                    break;
                default:
                    animeType = AnimeType.Unknown;
                    break;
            }
            anime.Type = animeType;


            AgeRating ageRating = new AgeRating();
            switch (cowboyBebop.Data.Rating)
            {
                case ("EveryRating"):
                    ageRating = AgeRating.g;
                    break;
                case ("G"):
                    ageRating = AgeRating.g;
                    break;
                case ("PG"):
                    ageRating = AgeRating.pg;
                    break;
                case ("PG13"):
                    ageRating = AgeRating.pg13;
                    break;
                case ("R17"):
                    ageRating = AgeRating.r17;
                    break;
                case ("R"):
                    ageRating = AgeRating.r;
                    break;
                case ("RX"):
                    ageRating = AgeRating.rx;
                    break;
                default :
                    ageRating = AgeRating.Unknown;
                    break;
            }
            anime.AgeRating = ageRating;

            AiringStatus airingStatus = new AiringStatus();
            switch (cowboyBebop.Data.Status)
            {
                case ("Finished Airing"):
                    airingStatus = AiringStatus.FinishedAiring;
                    break;
                case ("Currently Airing"):
                    airingStatus = AiringStatus.CurrentlyAiring;
                    break;
                case ("Not Yet Aired"):
                    airingStatus = AiringStatus.NotYetAired;
                    break;
            }
            anime.AiringStatus = airingStatus;

            Source sorce = new Source();
            switch (cowboyBebop.Data.Source)
            {
                case ("Other"):
                    sorce = Source.Other;
                    break;
                case ("Original"):
                    sorce = Source.Original;
                    break;
                case ("Manga"):
                    sorce = Source.Manga;
                    break;
                case ("ForKomaManga"):
                    sorce = Source.ForKomaManga;
                    break;
                case ("WebManga"):
                    sorce = Source.WebManga;
                    break;
                case ("DigitalManga"):
                    sorce = Source.DigitalManga;
                    break;
                case ("Novel"):
                    sorce = Source.Novel;
                    break;
                case ("LightNovel"):
                    sorce = Source.LightNovel;
                    break;
                case ("VisualNovel"):
                    sorce = Source.VisualNovel;
                    break;
                case ("Game"):
                    sorce = Source.Game;
                    break;
                case ("CardGame"):
                    sorce = Source.CardGame;
                    break;
                case ("Book"):
                    sorce = Source.Book;
                    break;
                case ("PictureBook"):
                    sorce = Source.PictureBook;
                    break;
                case ("Radio"):
                    sorce = Source.Radio;
                    break;
                case ("Music"):
                    sorce = Source.Music;
                    break;
                default:
                    sorce = Source.Undefined;
                    break;
            }
            anime.Source = sorce;

            var onlyNumString = Regex.Match(cowboyBebop.Data.Duration, @"\d+").Value;
            anime.EpisodesDurationSeconds = int.Parse(onlyNumString);

            anime.NumEpisodes = cowboyBebop.Data.Episodes;

            Image animePosterImage = new Image();
            animePosterImage.Small = cowboyBebop.Data.Images.JPG.SmallImageUrl;
            animePosterImage.Medium = cowboyBebop.Data.Images.JPG.MediumImageUrl;
            animePosterImage.Original = cowboyBebop.Data.Images.JPG.MaximumImageUrl;

            AnimePoster animePoster = new AnimePoster();
            // Wow -\|_|/-
            animePoster.Poster = animePosterImage;
            animePoster.Anime = anime;

            anime.Posters = new List<AnimePoster>()
            {
                animePoster
            };

            anime.AnotherService = new AnotherAnimeService
            {
                MyAnimeList = (int)cowboyBebop.Data.MalId
            };

            Aired aired = new Aired()
            {
                From = cowboyBebop.Data.Aired.From,
                To = cowboyBebop.Data.Aired.To,
            };
            anime.Aired = aired;

            anime.Synopsises = new List<AnimeSynopsis>
            {
                new AnimeSynopsis
                {
                    Body = cowboyBebop.Data.Synopsis,
                    Language = Languages.EN,
                    IsOriginal = true,
                    IsMain = true
                }
            };

            // Створити жанр, якщо не існує
            // Добавити у список
            List<Genre> genres = new List<Genre>();
            List<JikanDN.MalUrl> JDNGenres = cowboyBebop.Data.Genres.ToList();

            /*JikanDN.MalUrl jj = JDNGenres[0];
            JikanDN.MalUrl jj2 = JDNGenres[1];

            for (int i = 0; i< JDNGenres.Count; i++)
            {
                var JDNGenre = JDNGenres[i];
                var test = JDNGenre.Name;
                //var genreInLocalDb = genres.Single(x => x.Name == JDNGenres[i].Name);
            }*/

            foreach (JikanDN.MalUrl JDNGenre in JDNGenres)
            {

                // var genreInLocalDb = genres.Single(x => x.Name == JDNGenre.Name);
                var genreInLocalDb = genres.SingleOrDefault(x => x.Name == JDNGenre.Name);

                if (genreInLocalDb != null)
                {
                    // Add genre
                    genreInLocalDb = new Genre() { Name = JDNGenre.Name };
                    genres.Add(genreInLocalDb);
                }
                // Connect genre
                AnimeGenre animeGenre = new AnimeGenre
                {
                    Anime = anime,
                    Genre = genreInLocalDb
                };
                anime.Genres = new List<AnimeGenre>() {
                    animeGenre
                };
            }

            // Link module
            // Character to Anime
            List<Media2MediaLink> character2mediaLinks = new List<Media2MediaLink>();

            var RelationsList = cowboyBebop.Data.Relations;
            foreach (var relation in RelationsList)
            {
                RelationTypeEnum relationType;

                switch (relation.Relation)
                {
                    case("Side Story"):
                        relationType = RelationTypeEnum.SideStory;
                        break;
                    case ("Adaptation"):
                        relationType = RelationTypeEnum.Adaptation;
                        break;
                    case ("Sequel"):
                        relationType = RelationTypeEnum.Sequel;
                        break;
                    case ("Summary"):
                        relationType = RelationTypeEnum.Summary;
                        break;
                    case ("Alternative Version"):
                        relationType = RelationTypeEnum.AlternativeVersion;
                        break;
                    case ("Prequel"):
                        relationType = RelationTypeEnum.Prequel;
                        break;
                    case ("Alternative Setting"):
                        relationType = RelationTypeEnum.AlternativeSetting;
                        break;
                    case ("Parent Story"):
                        relationType = RelationTypeEnum.ParentStory;
                        break;
                    default:
                        relationType = RelationTypeEnum.Undefined;
                        break;
                }

                foreach (var entryObj in relation.Entry)
                {
                    MediaTypeEnum mediaTypeEnum;
                    // ?
                    var x = entryObj.Type;

                    switch (entryObj.Type)
                    {
                        case ("Anime"):
                            mediaTypeEnum = MediaTypeEnum.ANIME;
                            break;
                        case ("Manga"):
                            mediaTypeEnum = MediaTypeEnum.MANGA;
                            break;
                        case ("Character"):
                            mediaTypeEnum = MediaTypeEnum.CHARACTER;
                            break;
                        case ("Person"):
                            mediaTypeEnum = MediaTypeEnum.PERSON;
                            break;
                        default:
                            mediaTypeEnum = MediaTypeEnum.UNDEFINED;
                            break;
                    }
                    Media2MediaLink manga2MediaLink = new Media2MediaLink(mediaTypeEnum, relationType, ResourceEnum.MyanimelistNet, entryObj.MalId.ToString());

                    character2mediaLinks.Add(manga2MediaLink);
                }
            }

            RTO<Anime> animeRTO = new RTO<Anime>(anime)
            {
                Media2MediaLinks = character2mediaLinks
            };

            return animeRTO;
        }
    }
}
