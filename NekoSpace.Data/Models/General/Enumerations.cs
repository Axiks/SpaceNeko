namespace NekoSpaceList.Models.General
{
    public enum Languages
    {
        UK, PL, EN, JA, und
    }

    public enum AnimeType
    {
        EveryType,
        TV,
        OVA,
        Movie,
        Special,
        ONA,
        Music,
        Unknown
    }

    public enum AiringStatus
    {
        FinishedAiring,
        CurrentlyAiring,
        NotYetAired,
        Unknown
    }

    public enum AgeRating
    {
        g,
        pg,
        pg13,
        r17,
        r,
        rx,
        Unknown
    }

    public enum Source
    {
        Other,
        Original,
        Manga,
        ForKomaManga,
        WebManga,
        DigitalManga,
        Novel,
        LightNovel,
        VisualNovel,
        Game,
        CardGame,
        Book,
        PictureBook,
        Radio,
        Music,
        Undefined
    }

    public enum Sezon
    {
        Winter,
        Spring,
        Summer,
        Autumn,
        Undefined
    }

    public enum ItemFrom
    {
        System,
        User,
        ExternalSource
    }

    public enum MangaType
    {
        EveryType,
        Manga,
        Novel,
        OneShot,
        Doujinshi,
        Manhwa,
        Manhua
    }

    public enum MangaStatus
    {
        EveryStatus,
        Reding,
        Completed,
        Upcoming
    }

    public enum Role
    {
        Administrator,
        Moderator,
        Creator,
        User,
        Guest
    }
}
