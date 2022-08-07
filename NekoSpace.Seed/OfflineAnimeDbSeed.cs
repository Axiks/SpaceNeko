using ManamiAnimeOfflineRepository;
using ManamiAnimeOfflineRepository.Constans;
using ManamiAnimeOfflineRepository.Constans.Costumes;
using ManamiAnimeOfflineRepository.Models;
using ManamiAnimeOfflineRepository.Models.Costumes;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpace.Seed
{
    public class OfflineAnimeDbSeed : IDBSeed<Anime>
    {
        public OfflineAnimeDbSeed()
        {
        }

        public IEnumerable<Anime> RunSeed()
        {
            return GetManamiAnimes();
        }

        public IEnumerable<Anime> Search()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Anime> GetManamiAnimes()
        {
            ManamiAnimeRepository manamiAnimeRepository = new ManamiAnimeRepository(@"ManamiFolder", true);

            List<ManamiAnime> manamiAnimes = manamiAnimeRepository.GetAllAnime();
            List<Anime> animes = new List<Anime>();
            

            foreach (ManamiAnime manamiAnime in manamiAnimes)
            {
                Anime anime = new Anime();

                List<AnimeTitle> animeTitles = new List<AnimeTitle>();

                AnimeTitle animeTitle = new AnimeTitle();
                animeTitle.Body = manamiAnime.title;
                animeTitle.IsOriginal = true;
                animeTitle.IsMain = true;
                animeTitle.From = ItemFrom.ExternalSource;
                animeTitle.Language = Languages.EN;
                animeTitles.Add(animeTitle);

                foreach (string synomim in manamiAnime.synonyms)
                {
                    animeTitle = new AnimeTitle();
                    animeTitle.Body = synomim;
                    animeTitle.IsOriginal = false;
                    animeTitle.IsMain = false;
                    animeTitle.From = ItemFrom.ExternalSource;
                    animeTitle.Language = Languages.und;
                    animeTitles.Add(animeTitle);
                }

                anime.Titles = animeTitles;

                Image poster = new Image();
                poster.Original = manamiAnime.picture;
                poster.Small = manamiAnime.thumbnail;
                poster.From = ItemFrom.ExternalSource;

                List<AnimePoster> animePosterConnections = new List<AnimePoster>() {
                    new AnimePoster()
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
                            airingStatus = AiringStatus.UNKNOWN;
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

                anime.Premier = new Premier
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

                AnotherAnimeService anotherAnimeServices = new AnotherAnimeService();
                foreach(SourceLink sourceLink in manamiAnime.sourceLinks)
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
                            anime.MalId = Int32.Parse(sourceLink.Id);
                            anotherAnimeServices.MyAnimeList = Int32.Parse(sourceLink.Id);
                            break;
                    }
                }
                anime.AnotherService = anotherAnimeServices;

                animes.Add(anime);
            }

            return animes;
        }
    }
}
