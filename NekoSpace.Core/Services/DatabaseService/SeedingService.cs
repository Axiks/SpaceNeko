using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Helpers;
using NekoSpace.Common.Enums;
using NekoSpace.Data;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository;
using NekoSpace.Seed;
using NekoSpace.Seed.Driver;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using Nest;

namespace NekoSpace.Core.Services.DatabaseService;
public class SeedingService : ISeedingService
{
    private IMapper _mapper;
    private AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel> _animeRepository;

    public SeedingService(AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel> animeRepository, IMapper mapper)
    {
        _animeRepository= animeRepository;
        _mapper = mapper;
    }

    public void RunAsync()
    {
        SeedAnsibleService seedAnsibleService = new SeedAnsibleService(_animeRepository, _mapper);
        seedAnsibleService.RunSeed();
    }

}
