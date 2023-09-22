using NekoSpace.Common.Enums;
using NekoSpace.Data.Contracts.Entities.Character;
using NekoSpace.Data.Contracts.Entities.General;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using static NekoSpaceList.Models.General.GeneralModel;
using JikanDN = JikanDotNet;

namespace NekoSpace.Seed.Driver
{
    public class MalCharacterDriver : ISelectMediaById<CharacterEntity>, IGetAllCharactersByAnimeMALId
    {
        private JikanDN.IJikan jikan;

        public MalCharacterDriver()
        {
            // Initialize JikanWrapper
            jikan = new JikanDN.Jikan();
        }

        public string WorkWithServiceName => "MyAnimeList";

        public IEnumerable<RTO<CharacterEntity>> GetAllCharactersByAnimeMALId(long MALId)
        {
            var characters = new List<RTO<CharacterEntity>>();
            var animeCharactersAsync = jikan.GetAnimeCharactersAsync(MALId);

            var JCharacterList = animeCharactersAsync.Result.Data;
            Thread.Sleep(1000);

            foreach (JikanDN.AnimeCharacter JCharacter in JCharacterList)
            {
                var characterId = JCharacter.Character.MalId;
                var characterData = getMalCharacterById(characterId);

                characters.Add(characterData);
                Thread.Sleep(2000);
            }

            return characters;
        }

        public RTO<CharacterEntity> GetById(string Id)
        {
            long malId = Int32.Parse(Id);
            return getMalCharacterById(malId);
        }

        private RTO<CharacterEntity> getMalCharacterById(long MalId)
        {
            CharacterEntity character = new CharacterEntity();

            // Send request for "Spike Spiege" character
            var spikeAsync = jikan.GetCharacterFullDataAsync(MalId).Result;
            var spike = spikeAsync.Data;

            /*character.AnotherService = new AnotherCharacterServiceEntity
            {
                MyAnimeList = (int)spike.MalId
            };*/

            var malLink = new AssociatedServiceEntity {
                ServiceId = spike.MalId.ToString(),
                ServiceName = AssociatedService.MyAnimeListNet.ToString(),
            };

            character.AssociatedService.Add(malLink);

            var nameEng = new CharacterNamesEntity
            {
                Body = spike.Name,
                Language = Language.EN,
                IsAcceptProposal = true,
                IsMain = true
            };

            var nameJp = new CharacterNamesEntity
            {
                Body = spike.NameKanji,
                Language = Language.JA,
                IsAcceptProposal = true,
                IsMain = true
            };

            ICollection<CharacterNamesEntity> animeCharacters = new List<CharacterNamesEntity>()
            {
                nameEng,
                nameJp
            };

            var JdnNicknames = spike.Nicknames;
            foreach (string JdnNickname in JdnNicknames)
            {
                CharacterNamesEntity characterAlt = new CharacterNamesEntity();
                characterAlt.Body = JdnNickname;
                characterAlt.IsOriginal = false;
                characterAlt.IsMain = false;
                animeCharacters.Add(characterAlt);
            }

            var about = new CharacterAboutEntity
            {
                Body = spike.About,
                Language = Language.EN,
                IsAcceptProposal = true,
                IsMain = true

            };

            character.Abouts = new List<CharacterAboutEntity> { about };

            /*var mangaPosterImage = new PosterEntity();
            mangaPosterImage.Small = spike.Images.JPG.SmallImageUrl;
            mangaPosterImage.Medium = spike.Images.JPG.MediumImageUrl;
            mangaPosterImage.Original = spike.Images.JPG.MaximumImageUrl;

            CharacterPosterEntity charaterPoster = new CharacterPosterEntity();
            // Wow -\|_|/-
            charaterPoster.Poster = mangaPosterImage;
            charaterPoster.Character = character;

            character.Posters = new List<CharacterPosterEntity>()
            {
                charaterPoster
            };*/

            // Link module
            // Character to Anime
            List<Media2MediaLink> character2mediaLinks = new List<Media2MediaLink>();
            var AnimeographyList = spike.Animeography;

            foreach (var animeography in AnimeographyList)
            {
                var malId =  animeography.Anime.MalId;
                Media2MediaLink media2AnimeLink = new Media2MediaLink(MediaTypeEnum.ANIME, RelationTypeEnum.Undefined, ResourceEnum.MyanimelistNet, malId.ToString());
                character2mediaLinks.Add(media2AnimeLink);
            }

            // Character to Manga
            var mangaographyList = spike.Mangaography;

            foreach (var mangaography in mangaographyList)
            {
                var malId = mangaography.Manga.MalId;
                Media2MediaLink media2MangaLink = new Media2MediaLink(MediaTypeEnum.MANGA, RelationTypeEnum.Undefined, ResourceEnum.MyanimelistNet, malId.ToString());
                character2mediaLinks.Add(media2MangaLink);
            }

            RTO <CharacterEntity> characterRTO = new RTO<CharacterEntity>(character)
            {
                Media2MediaLinks = character2mediaLinks
            };

            return characterRTO;
        }
        
    }
}
