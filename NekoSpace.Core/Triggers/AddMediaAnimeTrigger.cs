using AutoMapper;
using EntityFrameworkCore.Triggered;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;

namespace NekoSpace.Core.Triggers
{
    public class AddMediaAnimeTrigger : IAfterSaveTrigger<AnimeEntity>
    {
        IElasticSearchRepository<ElasticSearchAnimeModel> _elasticSearchRepository;
        private IMapper _mapper;

        public AddMediaAnimeTrigger()
        {
            //_elasticSearchRepository = elasticSearchRepository;

            //AutoMapper Config
            /*var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnimeEntity, ElasticSearchAnimeModel>()
                .ForMember(dest => dest.DBId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDatePeriod, opt => opt.MapFrom(src => src.Aired))
                .ForMember(dest => dest.Premiere, opt => opt.MapFrom(src => src.Premier));

                cfg.CreateMap<TextVariantSubItemEntity, ESMediaBasicTitleModel>()
                .ForMember(dest => dest.IsNative, opt => opt.MapFrom(src => src.IsMain));

                cfg.CreateMap<PremierEntity, ESPremiereModel>();

            });
            *//*#if DEBUG
            configuration.AssertConfigurationIsValid();
            #endif*//*
            _mapper = configuration.CreateMapper();*/
        }

        public Task AfterSave(ITriggerContext<AnimeEntity> context, CancellationToken cancellationToken)
        {
            /*var aa = 10;

            if (context.ChangeType == ChangeType.Added)
            {
                AnimeEntity animeEntity = context.Entity;
                //Mapps
                ElasticSearchAnimeModel animeModel = _mapper.Map<ElasticSearchAnimeModel>(animeEntity);

                // Тут ми робимо логіку добавлення
                _elasticSearchRepository.AddAsync(animeModel);

            }*/

            return Task.CompletedTask;
        } 


        //Maps 

    }
}
