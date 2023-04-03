﻿using ManamiAnimeOfflineRepository;
using ManamiAnimeOfflineRepository.Constans;
using ManamiAnimeOfflineRepository.Constans.Costumes;
using ManamiAnimeOfflineRepository.Models;
using ManamiAnimeOfflineRepository.Models.Costumes;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpace.Seed.Driver
{
    public class MamiAnimeDriver : ISelectMediaByMALId<AnimeEntity>, ISelectMediaAll<AnimeEntity>
    {
        private IEnumerable<RTO<AnimeEntity>> _manamiAnimes;

        public MamiAnimeDriver()
        {
            MamiDatabase manamiAnimeRepository = new MamiDatabase(@"Models/Temp/ManamiRepository", true);
            _manamiAnimes = PullAllManamiAnimes(manamiAnimeRepository);
        }

        public IEnumerable<RTO<AnimeEntity>> GetAll()
        {
            return _manamiAnimes;
        }

        public RTO<AnimeEntity> GetByMALId(long MALId)
        {
            // var anime = context.Animes.Include(x => x.Titles).Single(item => item.Id == animeTitleItem.MediaId);
            RTO<AnimeEntity> animeObj = _manamiAnimes.SingleOrDefault(x => x.contain.AnotherService.MyAnimeList == MALId);
            return animeObj;
        }

        private IEnumerable<RTO<AnimeEntity>> PullAllManamiAnimes(MamiDatabase manamiAnimeRepository)
        {
            List<ManamiAnime> manamiAnimes = manamiAnimeRepository.GetAllAnime();

            List<RTO<AnimeEntity>> rtoAnimes = new List<RTO<AnimeEntity>>();


            foreach (ManamiAnime manamiAnime in manamiAnimes)
            {
                rtoAnimes.Add(PullManamiAnime(manamiAnime));
            }

            return rtoAnimes;
        }

        private RTO<AnimeEntity> PullManamiAnime(ManamiAnime manamiAnime)
        {
            ////////////
            AnimeEntity anime = new AnimeEntity();

            List<AnimeTitleEntity> animeTitles = new List<AnimeTitleEntity>();

            AnimeTitleEntity animeTitle = new AnimeTitleEntity();
            animeTitle.Body = manamiAnime.title;
            animeTitle.IsOriginal = true;
            animeTitle.IsMain = true;
            animeTitle.From = ItemFrom.ExternalSource;
            animeTitle.Language = Language.EN;
            animeTitles.Add(animeTitle);

            Console.WriteLine("Assert");

            foreach (string synomim in manamiAnime.synonyms)
            {
                animeTitle = new AnimeTitleEntity();
                animeTitle.Body = synomim;
                animeTitle.IsOriginal = false;
                animeTitle.IsMain = false;
                animeTitle.From = ItemFrom.ExternalSource;
                animeTitle.Language = Language.und;
                //animeTitle.LanguageDetectionBySystem = false;
                //Console.WriteLine("Assert");
                animeTitles.Add(animeTitle);
            }

            anime.Titles = animeTitles;

            ImageEntity poster = new ImageEntity();
            poster.Original = manamiAnime.picture;
            poster.Small = manamiAnime.thumbnail;
            poster.From = ItemFrom.ExternalSource;

            List<AnimePosterEntity> animePosterConnections = new List<AnimePosterEntity>() {
                    new AnimePosterEntity()
                    {
                        Anime = anime,
                        Poster = poster
                    }
                };
            anime.Posters = animePosterConnections;

            anime.NumEpisodes = manamiAnime.episodes;

            AiringStatus airingStatus;
            switch (manamiAnime.status)
            {
                case Status.FINISHED:
                    {
                        airingStatus = AiringStatus.FinishedAiring;
                        break;
                    }
                case Status.UPCOMING:
                    {
                        airingStatus = AiringStatus.CurrentlyAiring;
                        break;
                    }
                case Status.ONGOING:
                    {
                        airingStatus = AiringStatus.NotYetAired;
                        break;
                    }
                default:
                    {
                        airingStatus = AiringStatus.Unknown;
                        break;
                    }
            }
            anime.AiringStatus = airingStatus;

            //manamiAnime.animeSeason
            Sezon sezon = Sezon.Undefined;
            switch (manamiAnime.animeSeason.season)
            {
                case Season.WINTER:
                    sezon = Sezon.Winter;
                    break;

                case Season.SPRING:
                    sezon = Sezon.Spring;
                    break;

                case Season.SUMMER:
                    sezon = Sezon.Summer;
                    break;

                case Season.FALL:
                    sezon = Sezon.Autumn;
                    break;
            }

            anime.Premier = new PremierEntity
            {
                Year = manamiAnime.animeSeason.year,
                Sezon = sezon
            };

            AnimeType animeType = AnimeType.EveryType;
            switch (manamiAnime.type)
            {
                case ManamiType.TV:
                    animeType = AnimeType.TV;
                    break;
                case ManamiType.OVA:
                    animeType = AnimeType.OVA;
                    break;
                case ManamiType.MOVIE:
                    animeType = AnimeType.Movie;
                    break;
                case ManamiType.SPECIAL:
                    animeType = AnimeType.Special;
                    break;
                case ManamiType.ONA:
                    animeType = AnimeType.ONA;
                    break;
            }
            anime.Type = animeType;

            AnotherAnimeServiceEntity anotherAnimeServices = new AnotherAnimeServiceEntity();
            foreach (SourceLink sourceLink in manamiAnime.sourceLinks)
            {
                switch (sourceLink.resource)
                {
                    case (Resource.AnilistCo):
                        anotherAnimeServices.AnilistId = Int32.Parse(sourceLink.Id);
                        break;
                    case (Resource.AnidbNet):
                        anotherAnimeServices.AnimeDBId = Int32.Parse(sourceLink.Id);
                        break;
                    case (Resource.NotityMoe):
                        anotherAnimeServices.NotifyId = sourceLink.Id;
                        break;
                    case (Resource.KitsuIo):
                        anotherAnimeServices.KitsuId = Int32.Parse(sourceLink.Id);
                        break;
                    case (Resource.AnisearchCom):
                        anotherAnimeServices.AniSearchId = Int32.Parse(sourceLink.Id);
                        break;
                    case (Resource.AnimeplanetCom):
                        anotherAnimeServices.AnimePlanetId = sourceLink.Id;
                        break;
                    case (Resource.LivechartMe):
                        anotherAnimeServices.LivechartMeId = Int32.Parse(sourceLink.Id);
                        break;
                    case (Resource.MyanimelistNet):
                        anotherAnimeServices.MyAnimeList = Int32.Parse(sourceLink.Id);
                        break;
                }
            }
            anime.AnotherService = anotherAnimeServices;

            List<Media2MediaLink> anime2MediaLinks = new List<Media2MediaLink>();

            var mamaiRelations = manamiAnime.relations;
            foreach (string relationUrl in mamaiRelations)
            {
                UrlSiteComponent siteComponent = GetSiteComponent(relationUrl);
                ResourceEnum resourceEnum;
                // Parse url
                switch (siteComponent.hostpart)
                {
                    case ("anidb.net"):
                        resourceEnum = ResourceEnum.AnidbNet;
                        break;
                    case ("anilist.co"):
                        resourceEnum = ResourceEnum.AnilistCo;
                        break;
                    case ("anime-planet.com"):
                        resourceEnum = ResourceEnum.AnimeplanetCom;
                        break;
                    case ("anisearch.com"):
                        resourceEnum = ResourceEnum.AnisearchCom;
                        break;
                    case ("kitsu.io"):
                        resourceEnum = ResourceEnum.KitsuIo;
                        break;
                    case ("livechart.me"):
                        resourceEnum = ResourceEnum.LivechartMe;
                        break;
                    case ("myanimelist.net"):
                        resourceEnum = ResourceEnum.MyanimelistNet;
                        break;
                    case ("notify.moe"):
                        resourceEnum = ResourceEnum.NotityMoe;
                        break;
                    default:
                        resourceEnum = ResourceEnum.Undefined;
                        break;
                }
                Media2MediaLink Anime2MediaLink = new Media2MediaLink(MediaTypeEnum.ANIME,RelationTypeEnum.Undefined, resourceEnum,siteComponent.id);
                anime2MediaLinks.Add(Anime2MediaLink);

            }

            RTO<AnimeEntity> animeRTO = new RTO<AnimeEntity>(anime)
            {
                Media2MediaLinks = anime2MediaLinks
            };

            return animeRTO;
        }

        private UrlSiteComponent GetSiteComponent(string url)
        {
            Uri myUri = new Uri(url);
            // Get host part (host name or address and port). Returns "server:8080".
            string hostpart = myUri.Authority;

            // Get path components. Trailing separators. Returns { "/", "func2/", "sunFunc2" }.
            string[] pathsegments = myUri.Segments;
            string id = pathsegments.Last();

            UrlSiteComponent urlSiteComponent = new UrlSiteComponent(hostpart, id);

            return urlSiteComponent;
        }

        private record UrlSiteComponent(string hostpart, string id);

    }
}