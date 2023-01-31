using NekoSpace.Data.Contracts.Enumerations;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.Manga;
using static NekoSpaceList.Models.General.GeneralModel;
using JikanDN = JikanDotNet;

namespace NekoSpace.Seed.Driver
{
    public class MalCharacterDriver : ISelectMediaByMALId<Character>, IGetAllCharactersByAnimeMALId
    {
        private JikanDN.IJikan jikan;

        public MalCharacterDriver()
        {
            // Initialize JikanWrapper
            jikan = new JikanDN.Jikan();
        }

        public IEnumerable<RTO<Character>> GetAllCharactersByAnimeMALId(long MALId)
        {
            var characters = new List<RTO<Character>>();
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

        public RTO<Character> GetByMALId(long Id)
        {
            return getMalCharacterById(Id);
        }

        private RTO<Character> getMalCharacterById(long MalId)
        {
            Character character = new Character();

            // Send request for "Spike Spiege" character
            var spikeAsync = jikan.GetCharacterFullDataAsync(MalId).Result;
            var spike = spikeAsync.Data;

            character.AnotherService = new AnotherCharacterService
            {
                MyAnimeList = (int)spike.MalId
            };

            var nameEng = new CharacterNames
            {
                Body = spike.Name,
                Language = Languages.EN,
                IsAcceptProposal = true,
                IsMain = true
            };

            var nameJp = new CharacterNames
            {
                Body = spike.NameKanji,
                Language = Languages.JA,
                IsAcceptProposal = true,
                IsMain = true
            };

            ICollection<CharacterNames> animeCharacters = new List<CharacterNames>()
            {
                nameEng,
                nameJp
            };

            var JdnNicknames = spike.Nicknames;
            foreach (string JdnNickname in JdnNicknames)
            {
                CharacterNames characterAlt = new CharacterNames();
                characterAlt.Body = JdnNickname;
                characterAlt.IsOriginal = false;
                characterAlt.IsMain = false;
                characterAlt.Language = Languages.und;
                animeCharacters.Add(characterAlt);
            }

            var about = new CharacterAbout
            {
                Body = spike.About,
                Language = Languages.EN,
                IsAcceptProposal = true,
                IsMain = true

            };

            character.Abouts = new List<CharacterAbout> { about };

            Image mangaPosterImage = new Image();
            mangaPosterImage.Small = spike.Images.JPG.SmallImageUrl;
            mangaPosterImage.Medium = spike.Images.JPG.MediumImageUrl;
            mangaPosterImage.Original = spike.Images.JPG.MaximumImageUrl;

            CharacterPoster charaterPoster = new CharacterPoster();
            // Wow -\|_|/-
            charaterPoster.Poster = mangaPosterImage;
            charaterPoster.Character = character;

            character.Posters = new List<CharacterPoster>()
            {
                charaterPoster
            };

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

            RTO <Character> characterRTO = new RTO<Character>(character)
            {
                Media2MediaLinks = character2mediaLinks
            };

            return characterRTO;
        }
        
    }
}
