﻿using NekoSpace.API.GraphQL.TranslationProposal;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.AnimeNameControll
{
    public record UpdateTranslationNamePayload(AnimeTitle? animeTitle);
}